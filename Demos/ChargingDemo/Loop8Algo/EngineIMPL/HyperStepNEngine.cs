﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    // 多段式收费
    public class HyperStepNEngine : Engine
    {
        public HyperStepNEngine(string RuleName, DateTime ValidDtime) : base(RuleName, ValidDtime)
        {

        }

        public override double CalculateIMPL(bool OKToLetGo = true)
        {
            return base.CalculateIMPL(OKToLetGo);
        }
        public override string GenerateOrderIMPL()
        {
            return base.GenerateOrderIMPL();
        }
    }
}