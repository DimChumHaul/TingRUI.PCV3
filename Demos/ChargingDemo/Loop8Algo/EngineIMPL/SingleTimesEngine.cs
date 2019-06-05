using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoCore.Loop8Algo.EngineIMPL
{
    public class SingleTimesEngine : Engine
    {
        public SingleTimesEngine(string RuleName) : base(RuleName) { }
        /* 单次停车的收费放行价格? */
        public decimal? LetGoPrice { get; protected internal set; } = 5.0m;

        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            if (LetGo) return base.LetGoPrice;
            var info = $"这里应该做相应的 操作员信息和订单记录 以及系统日志记录," + Environment.NewLine;
            info += "关门放狗 必须给钱放行~";
            throw new NotImplementedException(info);       
        }
    }
}
