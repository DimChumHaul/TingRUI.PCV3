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
    public enum 太极 { 阳 = 4 << 7 , 阴 = 6 << 8 }

    /// <summary>
    /// 算法状态机 ：八阵图 底层用到的算法逻辑封装类
    /// </summary>
    public class Engine : IChargeEngine
    {
        public string EngineToken { get; } = $"[没有规则] - 请继承自这个类并提交你需要的规则代码在子类的方法重写中";
        public TimeSpan EngineDead { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTimme { get; set; }
        public byte[] RuleCode { get; set; }

        #region 以下变量适用于所有规则
        public 太极 起始时段 { get; set; } = 太极.阳;
        public int F1 { get; set; } = 10;

        /* 白天盒子 */
        public Tuple<float, int> CubeSun { get; set; } = new Tuple<float, int>(5.0f, 20);
        /** 月光盒子 */
        public Tuple<float, int> CubeMoon { get; set; } = new Tuple<float, int>(2.0f, 120);
        #endregion

        #region 算法引擎内核
        /* 算法底层所依赖的核心数据结构:【矩阵革命】微软Tuple数据结构切片儿 创建者：丁诚昊 v0.2 */ 
        internal protected double TotalResult { get; protected set; }
        /// <summary>
        /// 参数列表 1.计费单元 2.计费规则 3.单元价格
        /// </summary>
        public List<Tuple<int,string,float>> Tailer = new List<Tuple<int, string, float>>();
        protected internal Lazy<Dictionary<string, IoC4ControversyHandler>> 争议处理办法;
        #endregion

        public Engine(string RuleName = @"ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽヽ｀ヽ、ヽ｀ヽ｀、ヽ｀｀、ヽ 、｀｀、 ｀、ヽ｀ 、｀ ヽ｀ヽ、ヽ ｀、ヽ｀｀、ヽ、｀｀、｀、ヽ｀｀、 、ヽヽ｀、｀、、ヽヽ、｀｀、 、 ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽ、｀｀ヽ｀、、｀ヽ｀")
        {
            //var RuleValidaTime = DateTime.Now.AddYears(3);
            EngineDead = TimeSpan.FromSeconds(1.618);
            // 传入规则名称初始化
            if (!String.IsNullOrEmpty(RuleName)) EngineToken = RuleName;
            争议处理办法 = new Lazy<Dictionary<string, IoC4ControversyHandler>>();
            争议处理办法.Value.Add("彭总的解决办法", (timesegments, OK) => 
            {
                OK = true;
                return -0.0d;
            });
        }

        /* IMPL = implementation 算法的实现 */
        public virtual void CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false) { }

        /* IMPL = implementation 算法的实现 */
        public virtual string OrderDetailIMPL(string orderToken)
        {
            var result = this.ToSafeJson();
            var code = Encoding.UTF8.GetBytes(result);
            RuleCode = code;

            return $"订单:[{Guid.NewGuid()}] - \n\t 停车收费: ---|{result}|--- ";
        }
    }
}
