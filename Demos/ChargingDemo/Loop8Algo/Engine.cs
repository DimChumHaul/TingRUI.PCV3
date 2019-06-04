using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo
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
        public byte[] RuleCode { get; set; }

        #region 以下变量适用于所有规则
        // 免费时长?
        public int FreeSeg1 { get; set; } = 10;
        // 单词价格?
        public decimal? LetGoPrice { get; protected internal set; } = 5.0m;
        // 入场时间
        public DateTime InTime { get; protected internal set; }
        // 出场时间
        public DateTime OutTimme { get; protected internal set; }
        #endregion

        #region 内核引擎
        /* 参数列表 1.计费单元 2.计费规则 3.单元价格 */
        public List<Tuple<int, string, decimal?>> Tailer { get; set; }
        public string Billing { get; protected set; }
        public decimal? TotalResult { get; protected internal set; } = -.0m;
        #endregion

        public Engine(string RuleName = @"ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽヽ｀ヽ、ヽ｀ヽ｀、ヽ｀｀、ヽ 、｀｀、 ｀、ヽ｀ 、｀ ヽ｀ヽ、ヽ ｀、ヽ｀｀、ヽ、｀｀、｀、ヽ｀｀、 、ヽヽ｀、｀、、ヽヽ、｀｀、 、 ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽ、｀｀ヽ｀、、｀ヽ｀")
        {
            // 传入规则名称初始化
            if (!String.IsNullOrEmpty(RuleName)) EngineToken = RuleName;
            EngineDeadTime = TimeSpan.FromSeconds(1.618);
            Tailer = new List<Tuple<int, string, decimal?>>();
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
    }
}
