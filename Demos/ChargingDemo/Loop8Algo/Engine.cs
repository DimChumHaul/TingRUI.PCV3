using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo
{
    // 内核碎片函数指针 交给应用层调用者注入 设计模式：函数式编程+依赖注入
    public delegate double IoC4ControversyHandlerV01(List<Tuple<DateTime,DateTime>> tParams, bool okTogo = false);
    public enum 两仪 { 阴 = 3 << 8,阳 = 7 >> 6 }

    /// <summary>
    /// 算法状态机 ：八阵图 底层用到的算法逻辑封装类
    /// </summary>
    public class Engine : IChargeEngine
    {
        public string EngineToken { get; } = $"[没有规则] - 请继承自这个类并提交你需要的规则代码在子类的方法重写中";
        public TimeSpan EngineDead { get; set; }
        public 两仪 起始时段 { get; set; } = 两仪.阳;
        public DateTime InTime { get; set; }
        public DateTime OutTimme { get; set; }
        public byte[] RuleCode { get; set; }
        #region 以下变量适用于所有规则
        public int F1 { get; set; } = 10;
        public Tuple<float, int> CubeSeg1 { get; set; } = new Tuple<float, int>(5.0f, 20);
        public Tuple<float, int> CubeSegN { get; set; } = new Tuple<float, int>(2.0f, 120);
        #endregion

        #region 算法引擎内核
        /* 算法底层所依赖的核心数据结构:【矩阵革命】微软Tuple数据结构切片儿 创建者：丁诚昊 v0.2 */ 
        public List<Tuple<int,string,float>> MatrixRevolution;
        internal protected double TotalResult { get; protected set; }
        protected internal Lazy<Dictionary<string, IoC4ControversyHandlerV01>> 争议处理办法;
        #endregion

        public Engine(string RuleName = @"ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽヽ｀ヽ、ヽ｀ヽ｀、ヽ｀｀、ヽ 、｀｀、 ｀、ヽ｀ 、｀ ヽ｀ヽ、ヽ ｀、ヽ｀｀、ヽ、｀｀、｀、ヽ｀｀、 、ヽヽ｀、｀、、ヽヽ、｀｀、 、 ヽ｀、ヽ｀｀、ヽ｀ヽ｀、、ヽ ｀ヽ 、ヽ｀｀ヽ、｀｀ヽ｀、、｀ヽ｀")
        {
            //var RuleValidaTime = DateTime.Now.AddYears(3);
            EngineDead = TimeSpan.FromSeconds(1.618);
            // 传入规则名称初始化
            if (!String.IsNullOrEmpty(RuleName)) EngineToken = RuleName;
            争议处理办法 = new Lazy<Dictionary<string, IoC4ControversyHandlerV01>>();
            争议处理办法.Value.Add("彭总的解决办法", (timesegments, OK) => 
            {
                OK = true;
                return -0.0d;
            });
        }

        /* IMPL = implementation 算法的实现 */
        public virtual double CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            return -0.0d;
        }

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
