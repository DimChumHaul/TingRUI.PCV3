using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.CalculationModule
{
    /// <summary>
    /// 算法状态机 ：八阵图 底层用到的算法逻辑封装类
    /// </summary>
    internal class Engine : IChargeEngine
    {
        public string EngineName { get; } = $"[没有规则] - 请继承自这个类并提交你需要的规则代码在子类的方法重写中";
        protected internal byte[] RuleCode { get; set; }
        protected internal DateTime RuleValideUntil { get; set; }

        #region 以下变量适用于所有规则
        /// <summary>
        /// 以下所有计费规则都以:`分钟`为`最小时间单元`
        /// 免费时间6分钟，2元/18分钟，时段满收费。
        /// </summary>
        public int F1 { get; set; } = 6;
        public int T1 { get; set; } = (int)Decimal.Zero;
        public double T1Price { get; set; } = (double)Decimal.Zero  ;
        /// after time unit per Unit Price 后续计费单元 例如 2元/18分钟  AnN = 18 
        public int ANUnit { get; set; } = 2;
        public double ANUPrice { get; set; } = 18.0d;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        #endregion

        public Engine(string RuleName , DateTime ValidDtime)
        {
            RuleValideUntil = ValidDtime == 
                DateTime.MinValue ? DateTime.Now.AddYears(3) 
                : ValidDtime;
            if (!String.IsNullOrEmpty(RuleName))
            {
                EngineName = RuleName;
            }
        }

        public virtual double CalculationPrice(DateTime InTime, DateTime OutTime, bool OKToLetGo = false)
        {
            return -0.0d;
        }

        public virtual string GenerateOrderDetail(List<Tuple<DateTime, DateTime, string>> TimeSlice)
        {
            var result = this.ToSafeJson();
            var code = Encoding.UTF8.GetBytes(result);
            this.RuleCode = code;
            return result;
        }
    }
}
