using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    // 多段式收费
    public sealed class HyperStepNEngine : Engine
    {
        public HyperStepNEngine(string RuleName, DateTime ValidDtime) : base(RuleName) { }
        public override double CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            return -0.0d;
        }
    }
}
