using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    public class TidalEngine : Engine
    {
        /// <summary>
        /// 潮汐收费引擎说明: 
        ///     免费时间6分钟。
        ///     停车第一个小时内按照1.5元/15分钟；超过第一个小时按照2元/15分钟。时段满收费
        /// </summary>
        /// <param name="RuleName">规则名称</param>
        /// <param name="ValidDtime">规则有效期</param>
        public TidalEngine(string RuleName, DateTime ValidDtime) : base(RuleName, ValidDtime) { }

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
