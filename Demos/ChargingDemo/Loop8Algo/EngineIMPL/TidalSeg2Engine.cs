using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    public class TidalSeg2Engine : Engine
    {
        public TidalSeg2Engine(string RuleName, DateTime ValidDtime) : base(RuleName, ValidDtime)
        {

        }

        public override double CalculationPrice(DateTime InTime, DateTime OutTime, bool OKToLetGo = true)
        {
            return base.CalculationPrice(InTime, OutTime, OKToLetGo);
            {

            }
        }

        public override string GenerateOrderDetail(List<Tuple<DateTime, DateTime, string>> TimeSlice)
        {
            return base.GenerateOrderDetail(TimeSlice);
        }
    }
}
