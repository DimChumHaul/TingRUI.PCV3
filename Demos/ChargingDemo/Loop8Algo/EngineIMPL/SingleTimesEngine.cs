using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    public class SingleTimesEngine : Engine
    {
        public SingleTimesEngine(string RuleName) : base(RuleName) { }

        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            if (LetGo) return base.LetGoPrice;
            var info = $"这里应该做相应的 操作员信息和订单记录 以及系统日志记录," + Environment.NewLine;
            info += "关门放狗 必须给钱放行~";
            throw new NotImplementedException(info);       
        }
    }
}
