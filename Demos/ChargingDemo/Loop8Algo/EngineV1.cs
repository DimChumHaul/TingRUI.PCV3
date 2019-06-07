
using AlgoCore.Enum;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region v2.0 -【跨天算法代码段】提升时间单元为`天` 计算右边界出场时间点落在`当天`的第几段`停如意`盒子上 
#endregion


namespace AlgoCore.Loop8Algo
{
    // 内核碎片函数指针 交给应用层调用者注入 设计模式：函数式编程+依赖注入
    public delegate double IoCControversyEvent(List<Tuple<DateTime,DateTime>> tParams, bool okTogo = false);

    /// <summary>
    /// v1.0通用计费软件算法引擎 ：
    /// 最终版本的正确抽象 == 1*.MTU最小时间单元(盒子模型) + 2*.划界机械摇臂 + 3.尾巴容器 
    /// + 4*.IoC注入争议字段处理函数指针* + 5.矩阵平方(降维) + 6.借位消元(跨年/跨酒神代)
    /// + 7*.盒子着色(错峰打折) 
    /// 德意志工业的顶层设计：七大模组 交互作业流水线
    /// </summary>
    public class EngineV1 : IChargeEngine
    {
        #region 内核引擎 - v1.0 参数区
        // 免费时长? 单位:分钟
        public int FreeTime { get; set; } = 60;
        /* 北京/成都 向上向下取整 ~ */
        public FloorOrCeil floorOrCeil = FloorOrCeil.Ceil;
        // 出入场时间
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }

        /* 盒子模型 附加规则 = [二段式盒子 + 潮汐盒子 + 24H盒子 + 单次盒子 + ... 各种盒子 */
        public List<(DateTime start, DateTime end, TingRUICube RuiCube)> TinCubes { get; set; }
        private DKSkyScorpion _scorpion;
        // 记录作业引擎中的重要操作 转化为字符串 记录到内存中 将来写入内核日志
        public IEnumerable<string> EngineLog { get; set; }
        #endregion

        public EngineV1(string RuleName,List<ValueTuple<DateTime,DateTime,TingRUICube>> RuleList)
        {
            // 0.传入规则名称初始化
            if (!string.IsNullOrEmpty(RuleName))
            {
                EngineToken = RuleName;
                EngineWorkTimeout = TimeSpan.FromSeconds(1.618);
            }
            // 1-2.初始化 规则引擎【规则盒子】容器 - Init
            TinCubes = RuleList;
        }

        #region 内核引擎 - Algorithm's Core IMPL
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
        ///【停如意错峰算法】:
        ///     丁诚昊作业蝎子 + ⏳停如意盒子m³模型 + "尾巴"算法 + "借元"算法 + 依赖注入争议函数指针
        ///     v1版本不解决`跨年`问题 以天为最大计费单元 以分钟为最小计费单元
        /// </summary>
        /// <param name="tStart">真正的停车起始时间 (不包含各种时间减免) 用于确认时间轴的下界 </param>
        /// <param name="tEnd">出场时间 时间轴上届 包含"借元"算法 </param>
        /// <param name="letGo">是否直接开闸放行</param>
        /// <returns>钱.订单详情列表.时间片信息组</returns>
        internal decimal? EngineGo(DateTime tStart, DateTime tEnd, bool letGo = false)
        {
            // 检查参数
            ParamCheck(tStart, tEnd);

            // 直接开闸放行...做好日志处理和权限操作记录
            _scorpion = new DKSkyScorpion(tStart,tEnd);
            if (letGo) 
            {
                _scorpion.TotalResult = 5.0m;
                return _scorpion.TotalResult;
            }
            if (TinCubes.Count() <= 0) throw new Exception("基准规则寻址失败...规则清单长度为0...");

            while(_scorpion.PivotLeft < tEnd && _scorpion.PivotRight < tEnd )
            {
                // 规则附加(投放盒子) * 时间片切割(矩阵平方) * 循环划界切割最小单元(for)
                for (int idx = 0; idx < TinCubes.Count(); idx++)
                {
                    // 1-1.启动时间轴引擎 开始附加基础规则
                    TingRUICube Cube = TinCubes[idx].RuiCube;
                    // 1-2.释放丁诚昊蝎子 
                    var ptu = Cube.PTU; // price per unit
                    var mtu = Cube.MTU; // minutes per unit
                    var ppm = Cube.PPM; // price per minute
                    var ruleStart = Cube.RuleStart;
                    var ruleEnd = Cube.RuleEnd;
                    var disRate = Cube.DisRate;
                    var enableDis = Cube.EnableRuleCuoFeng;
                    // 1-3.蝎子摆尾 定位单次规则内的左右手时间点 (左右手不断++)
                    _scorpion.PivotLeft  = tStart >= ruleStart.FromTime2DT() ? tStart : ruleStart.FromTime2DT();
                    _scorpion.PivotRight = tEnd <= ruleEnd.FromTime2DT() ? tEnd : ruleEnd.FromTime2DT();
                    // 2-2.矩阵平方
                    var minutes = (int)(_scorpion.PivotRight - _scorpion.PivotLeft).TotalMinutes;
                    var Counts = minutes / mtu;
                    var Rest = minutes % mtu;
                    // 3-1.循环作业获取大盒子内的小盒子个数 辗转相加 保存每一段时间片儿计费
                    for (int index = 0; index < Counts; index++)
                    {
                        // 在争议得不到解决的情况下 我先进行`精准计算` 精确到每一分钟(小数点后32位)
                        _scorpion.TotalResult += ptu * (decimal)(enableDis ? disRate : 1);
                        // 记录每一个带`色彩(规则)`的小盒子
                        _scorpion.Tail.Add((mtu,ptu,enableDis));
                    }
                    // 3-2.尾巴儿算法&容器数据结构
                    var RestMoney = ppm * Rest * (enableDis ? disRate : 1);
                    _scorpion.TotalResult += (decimal)RestMoney;
                    _scorpion.Tail.Add((Rest, (decimal)RestMoney, Cube.EnableRuleCuoFeng));
                }
                // 鞋子左右手完成所有时间片切割则跳出死循环
                _scorpion.PivotRight = _scorpion.PivotLeft = tEnd;
            }
            InTime = tStart; OutTime = tEnd;
            return _scorpion.TotalResult;
        }
        #endregion

        /* IMPL = implementation 算法的实现 */
        public virtual decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            return this.EngineGo(t1,t2, LetGo);
        }

        /* IMPL = implementation 算法的实现 */
        public virtual string GenOrderIMPL(string orderToken)
        {
            var result = this.ToSafeJson();
            var code = Encoding.UTF8.GetBytes(result);
            RuleCode = code;
            return $"订单:[{Guid.NewGuid()}] - \n\t 停车收费: ---|{result}|--- ";
        }

        #region 脏代码区
        public string EngineToken { get; private set; } = $"[没有规则]-请继承自这个类并提交你需要的规则代码在子类的方法重写中";
        
        // 引擎计算容错预留 ：1.6秒没有完成 计费API+订单流水API 则写入崩溃日志
        public TimeSpan EngineWorkTimeout { get; set; }
        protected internal byte[] RuleCode { get; set; }
        public string Billing = "【停如意】- 错峰停车首创者 停车场管理无人值守引领者" + Environment.NewLine;
        #endregion 
    }
}
