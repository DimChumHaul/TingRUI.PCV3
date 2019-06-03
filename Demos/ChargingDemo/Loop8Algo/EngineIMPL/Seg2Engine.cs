using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    /* 
     * 二段式收费 :
     * 1.免费时间10分钟，第一时段（7:00:00-19:00:00）5元/20分钟；第二时段（19:00:01-6:59:59）2元/120分钟。时段满收费。
     * 2.无免费时间，第一时段（7:00:00-19:00:00）5元/20分钟；第二时段（19:00:01-6:59:59）2元/120分钟。时段满收费。
     */
    public class Seg2Engine : Engine
    {
        public Seg2Engine(string RuleName, DateTime ValidDtime) : base(RuleName, ValidDtime) { }

        public override double CalculationPrice(bool OKToLetGo = true)
        {
            return base.CalculationPrice(OKToLetGo);
        }

        public override string GenerateOrderDetail()
        {
            return base.GenerateOrderDetail();
        }
    }
}
