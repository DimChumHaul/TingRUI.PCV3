
using AlgoCore.Enum;
using ChargingDemo.Loop8Algo;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region v2.0 -【跨天算法代码段】提升时间单元为`天` 计算右边界出场时间点落在`当天`的第几段`停如意`盒子上 
#endregion


namespace AlgoCore.Loop8Algo
{
    // 内核碎片函数指针 交给应用层调用者注入 设计模式：函数式编程+依赖注入
    public delegate double ControversyHandler(List<Tuple<DateTime,DateTime>> tParams, bool okTogo = false);

    /// <summary>
    /// 算法引擎v1.0的最初设计 是借鉴诸葛亮的八阵图:
    ///     功盖三分国，名成八阵图。
    ///     江流石不转，遗恨失吞吴。
    ///     但后来我又觉得基于线性代数和物理学概念`时间`似乎更加容易理解和实现
    /// </summary>
    public class EngineV1 : IChargeEngine
    {
        #region 作业引擎需要用到的脏代码区
        public string EngineToken { get; private set; } = $"[没有规则]-请继承自这个类并提交你需要的规则代码在子类的方法重写中";
        // 引擎计算容错预留 ：1.6秒没有完成 计费API+订单流水API 则写入崩溃日志
        public const string 收费规则占位符 = "酒神代ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽヽ｀ヽ、ヽ｀ヽ｀、ヽ｀｀、ヽ 、｀｀、｀、ヽ｀ 、｀ ヽ｀ヽ、ヽ ｀、ヽ｀｀、ヽ、｀｀、｀、ヽ｀｀、 、ヽヽ｀、｀、、ヽヽ、｀｀、 、 ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽ、｀｀ヽ｀、、｀ヽ｀谷雨代";
        public TimeSpan EngineWorkTimeout { get; set; } 
        protected internal byte[] RuleCode { get; set; }
        public string Billing = "【停如意】- 错峰停车首创者 停车场管理无人值守引领者" + Environment.NewLine;
        public EngineV1(string RuleName = 收费规则占位符)
        {
            // 0.传入规则名称初始化
            if (!string.IsNullOrEmpty(RuleName))
            {
                EngineToken = RuleName;
                EngineWorkTimeout = TimeSpan.FromSeconds(1.618);
            }
            // 1-1.初始化 作业引擎【时间切片儿】容器 - Init
            Tail = new List<ValueTuple<double, decimal?, bool?>> { };
            // 1-2.初始化 规则引擎【规则盒子】容器 - Init
            TinCubes = new List<ValueTuple<DateTime, DateTime, CubeRUI>>();
        }
        #endregion 

        #region 内核引擎 - v1.0 参数区
        // 免费时长?
        public int FreeSeg1 { get; set; } = 60;
        /* 向上向下取整 ~ */
        public FloorOrCeil floorOrCeil = FloorOrCeil.Ceil;

        public decimal? TotalResult { get; protected internal set; } = -.0m;
        /* 尾巴儿容器 参数列表 1.计费单元 2.计费规则 3.单元价格 */
        public List<(double ttmUnit, decimal? unitPrice, bool? discount)> Tail { get; set; }
        /* 盒子模型 附加规则 = [二段式盒子 + 潮汐盒子 + 24H盒子 + 单次盒子 + ... 各种盒子 */
        public List<(DateTime start, DateTime end, CubeRUI RuiCube)> TinCubes { get; set; }
        // 记录作业引擎中的重要操作 转化为字符串 记录到内存中 将来写入内核日志
        public IEnumerable<string> EngineLog { get; set; }
        #endregion

        #region Algorithm's Core IMPL
        // TTM 时间轴校对函数
        public virtual bool ParamCheck(DateTime T1, DateTime T2)
        {
            var debugInfo = string.Empty; // 用作日志
            if (T1.Year != T2.Year) debugInfo = "跨年算法暂时不公开...";
            if (T1 > T2) debugInfo = "出场时间必须大于入场时间";
            debugInfo.PrintDump();
            ; 
            return string.IsNullOrWhiteSpace(debugInfo);
        }

        /// <summary>
        ///【停如意错峰算法】：作业函数: 
        ///     时间轴划界 + 含附加规则算法簇 + ⏳盒子m³模型 + "尾巴"算法 + "借元"算法
        ///     v1版本不解决`跨年`问题
        /// </summary>
        /// <param name="tStart">真正的停车起始时间 (不包含各种时间减免) 用于确认时间轴的下界 </param>
        /// <param name="tEnd">出场时间 时间轴上届 包含"借元"算法 </param>
        /// <param name="letGo">是否直接开闸放行</param>
        /// <returns>钱.订单详情列表.时间片信息组</returns>
        public decimal? EngineGo(DateTime tStart, DateTime tEnd, bool letGo = false)
        {
            if (TinCubes.Count() <= 0) throw new Exception("基准规则寻址失败...规则清单长度为0...");
            if (letGo) throw new NotImplementedException("直接开闸放行...做好日志处理和权限操作记录");
            //var PivotRight = new PivotTemplate(tStart, tEnd);

            TotalResult = -.0m;

            /* 1-2.启动引擎 开始三重扫描 */
            var PivotLeft = tStart;
            var PivotRight = DateTime.MinValue;
            while( PivotLeft < tEnd )
            {
                // 规则附加(投放盒子) * 时间片切割(矩阵平方) * 循环划界切割最小单元(for)
                for (int ruleIdx = 0; ruleIdx < TinCubes.Count(); ruleIdx++)
                {
                    // 1.转换参数
                    var Rule = TinCubes[ruleIdx];
                    CubeRUI Cube = Rule.RuiCube;

                    // 2-1.矩阵平方 分别计算 ttmN 一个盒子入场以后能够获取的所有沙砾
                    PivotRight = Cube.RuleEnd.FromTime() <= tEnd ? Cube.RuleEnd.FromTime() : tEnd;
                    PivotLeft = tStart;

                    var temp = (int)((PivotRight - PivotLeft).TotalMinutes);
                    var CubeCount = temp / Cube.MTUnit;
                    var RestTailMinutes = temp % Cube.MTUnit;
                    // 3-1.万佛朝宗(辗转相加.获取总金额)
                    for (int cNo = 0; cNo < CubeCount; cNo++)
                    {
                        // 在争议得不到解决的情况下 我先进行`精准计算` 精确到每一分钟(小数点后32位)
                        TotalResult += Cube.MTPrice * (decimal)Cube.DisRate;
                        Tail.Add((ttmInCube, Cube.MTPrice, Cube.ShouldDiscount));
                    }
                    // 4.虚位以待
                    var ControversyResult = Cube.PPM * RestTailMinutes * Cube.DisRate;
                    TotalResult += (decimal)ControversyResult;
                    Tail.Add((RestTailMinutes, (decimal)ControversyResult, Cube.ShouldDiscount));
                }
            }
            return TotalResult;
        }

        /* IMPL = implementation 算法的实现 */
        public virtual decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false) { return -.0m; }
        /* IMPL = implementation 算法的实现 */
        public virtual string GenOrderIMPL(string orderToken)
        {
            var result = this.ToSafeJson();
            var code = Encoding.UTF8.GetBytes(result);
            RuleCode = code;
            return $"订单:[{Guid.NewGuid()}] - \n\t 停车收费: ---|{result}|--- ";
        }
        #endregion
    }
}
