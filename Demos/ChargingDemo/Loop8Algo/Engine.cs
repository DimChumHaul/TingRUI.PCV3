
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoCore.Loop8Algo
{
    // 内核碎片函数指针 交给应用层调用者注入 设计模式：函数式编程+依赖注入
    public delegate double IoC4ControversyHandler(List<Tuple<DateTime,DateTime>> tParams, bool okTogo = false);

    /// <summary>
    /// 算法状态机 ：八阵图 底层用到的算法逻辑封装类
    /// </summary>
    public class Engine : IChargeEngine
    {
        public string EngineToken { get; private set; } = $"[没有规则]-请继承自这个类并提交你需要的规则代码在子类的方法重写中";
        // 引擎计算容错预留 ：1.6秒没有完成 计费API+订单流水API 则写入崩溃日志
        public TimeSpan EngineDeadTime { get; set; } 
        public string Billing { get; protected set; }


        #region 内核引擎
        // 免费时长?
        public int FreeSeg1 { get; set; } = 60;
        public decimal? TotalResult { get; protected internal set; } = -.0m;
        /* 参数列表 1.计费单元 2.计费规则 3.单元价格 */
        public List<Tuple<int, string, decimal?,bool?>> Tail { get; set; }
        #endregion

        public Engine(string RuleName = "酒神ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽヽ｀ヽ、ヽ｀ヽ｀、ヽ｀｀、ヽ 、｀｀、｀、ヽ｀ 、｀ ヽ｀ヽ、ヽ ｀、ヽ｀｀、ヽ、｀｀、｀、ヽ｀｀、 、ヽヽ｀、｀、、ヽヽ、｀｀、 、 ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽ、｀｀ヽ｀、、｀ヽ｀谷雨")
        {
            // 传入规则名称初始化
            if (!string.IsNullOrEmpty(RuleName)) EngineToken = RuleName;
            EngineDeadTime = TimeSpan.FromSeconds(1.618);
            Tail = new List<Tuple<int, string, decimal?,bool?>>();
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

        #region 内核钩子作业函数区
        /// TTM 时间轴校对函数
        public virtual bool ParamCheck(DateTime T1, DateTime T2)
        {
            string debugInfo = string.Empty; // 用作日志
            if (T1.Year != T2.Year)
            {
                debugInfo = "跨年算法暂时不公开...";
                return false;
            }
            if (T1 > T2)
            {
                debugInfo = "出场时间必须大于入场时间";
                return false;
            }
            InTime = T1 > T2 ? T2 : T1;
            OutTimme = T1 < T2 ? T1 : T2;
            ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ;
            return true;
        }

        // 【内核算法】：立方体沙漏⏳模型
        public decimal? EngineGo(double TTM, 太极 TaiJi)  
        {
            // 1.阴阳合和
            var CUBE = TaiJi == 太极.阳 ? CubeH1 : CubeHN;
            // 2.矩阵平方
            int divides = (int)TTM / CUBE.Item2;
            double tailer = TTM % CUBE.Item2;
            // 3.辗转相除
            for (int i = 0; i < divides; i++)
            {
                TotalResult += CUBE.Item1;
                Tail.Add(new Tuple<int, string, decimal?, bool?>(CUBE.Item2, EngineToken, CUBE.Item1, false));
            }
            // 4.虚位以待
            Tail.Add(new Tuple<int, string, decimal?, bool?>((int)tailer, EngineToken + $"尾巴时间[{tailer}]分钟", CUBE.Item1, false));
            Billing = $"停车收费:[{TotalResult}]元...算法规则({EngineToken})";
            return TotalResult;
        }

        public byte[] RuleCode { get; set; }
        #endregion
    }
}
