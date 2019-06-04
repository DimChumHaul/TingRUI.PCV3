using ChargingDemo.Loop8Algo.Enum;
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

        /* 1H紫色盒子 */
        public Tuple<decimal?, int> CubeH1 { get; set; } = new Tuple<decimal?, int>(1.5m, 15);
        /* NH紫红色盒子 */
        public Tuple<decimal?, int> CubeHN { get; set; } = new Tuple<decimal?, int>(2.0m, 15);

        // 【内核算法】：立方体沙漏⏳模型
        public decimal? EngineGo(double TTM, 太极 TaiJi)
        {
            // 1.阴阳合和
            var CUBE = TaiJi == 太极.阳 ? CubeH1 : CubeHN;
            // 2.矩阵平方
            int divides = (int)TTM / CUBE.Item2;
            double tailer = TTM % CUBE.Item2;
            // 3.辗转相除
            for (int i = 0; i < divides; i++)
            {
                TotalResult += CUBE.Item1;
                Tailer.Add(new Tuple<int, string, decimal?, bool?>(CUBE.Item2, EngineToken, CUBE.Item1,false));
            }
            // 4.虚位以待
            Tailer.Add(new Tuple<int, string, decimal?, bool?>((int)tailer, EngineToken + $"尾巴时间[{tailer}]分钟", CUBE.Item1,false));
            Billing = $"停车收费:[{TotalResult}]元...算法规则({EngineToken})";
            return base.TotalResult;
        }

        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            /* TTM 时间轴校对函数 */
            ParamCheck(t1, t2);

            // 免费停车
            double TTM = Math.Abs((t2 - t1).TotalMinutes);
            if ((int)TTM <= FreeSeg1) return -.0m;

            if (TTM < 60)
            {
                //  不跨时段 矩阵引擎
               return EngineGo(TTM, 太极.阳);
            }
            else // 超过1小时
            {
                double TTMH1 = 60.0d;
                var TTMHN = TTM - TTMH1; ;
                return EngineGo(TTMH1, 太极.阳) + EngineGo(TTMHN, 太极.阴);
            }
        }
    }
}
