using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    public class TidalSeg2Engine : Engine
    {
        public TidalSeg2Engine(string RuleName, DateTime ValidDtime) : base(RuleName, ValidDtime) { }

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
