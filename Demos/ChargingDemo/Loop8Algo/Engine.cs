using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo
{
    // 内核碎片函数指针 交给应用层调用者注入 设计模式：函数式编程+依赖注入
    public delegate double CalcSegFunc(IEnumerable<Tuple<DateTime,DateTime>> tParams, bool okTogo = false);

    /// <summary>
    /// 算法状态机 ：八阵图 底层用到的算法逻辑封装类
    /// </summary>
    public class Engine : IChargeEngine
    {
        public string EngineName { get; } = $"[没有规则] - 请继承自这个类并提交你需要的规则代码在子类的方法重写中";
        protected internal byte[] RuleCode { get; set; }
        protected internal DateTime? RuleValideUntil { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        #region 以下变量适用于所有规则
        /// <summary>
        ///     以下所有计费规则都以:`分钟`为`最小时间单元`
        ///     免费时间6分钟，2元/18分钟，时段满收费。
        /// </summary>
        public int F1 { get; set; } = 6;
        public int T1 { get; set; } = (int)Decimal.Zero;
        public double T1Price { get; set; } = (double)Decimal.Zero;
        /// after time unit per Unit Price 后续计费单元 例如 2元/18分钟  AnN = 18 
        public int AFNUnit { get; set; } = 2;
        public double AFNUPrice { get; set; } = 18.0d;
        #endregion

        #region 算法引擎内核
        internal protected List<Tuple<DateTime, DateTime, string>> TimeSlice;
        private Int32 CurrentTPivot { get; set; }
        internal protected double AmoutTotal { get; private set; } 
        #endregion

        public Engine(string RuleName , DateTime ValidDtime)
        {
            var RuleValidaTime = DateTime.Now.AddYears(3);
            RuleValideUntil = ValidDtime == DateTime.MinValue ? RuleValidaTime : ValidDtime;

            // 传入规则名称初始化
            if (!String.IsNullOrEmpty(RuleName))
            {
                EngineName = RuleName;
            }
        }

        /* IMPL = implementation 算法的实现 */
        public virtual double CalculateIMPL(bool OKToLetGo = true)
        {
            return -0.0d;
        }

        /* IMPL = implementation 算法的实现 */
        public virtual string GenerateOrderIMPL()
        {
            var result = this.ToSafeJson();
            var code = Encoding.UTF8.GetBytes(result);
            this.RuleCode = code;
            return result;
        }
    }
}
