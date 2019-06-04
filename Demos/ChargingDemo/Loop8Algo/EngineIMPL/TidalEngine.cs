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
        public TidalEngine(string RuleName) : base(RuleName) { }

        /* 白天盒子 */
        public Tuple<float, int> CubeH1 { get; set; } = new Tuple<float, int>(1.5f, 15);
        /* 夜晚盒子 */
        public Tuple<float, int> CubeHN { get; set; } = new Tuple<float, int>(2.0f, 15);

        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            // 以下算法的逻辑 建立在 `最小计费单元是分钟`的基础上 不代表不可以继续切割分钟为更小的时间单元
            if (t1.Year != t2.Year) throw new NotImplementedException("跨年算法暂时不公开...");
            if (t1 > t2) throw new InvalidOperationException("出场时间必须大于入场时间");
            InTime = t1 > t2 ? t2 : t1;
            OutTimme = t1 < t2 ? t1 : t2;

            double TTM = Math.Abs((t2 - t1).TotalMinutes);
            return -1.0m;
        }
    }
}
