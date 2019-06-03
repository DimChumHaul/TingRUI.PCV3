using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    /* 
     * 二段式收费 :
     *  1.免费时间10分钟，第一时段（7:00:00-19:00:00）5元/20分钟；第二时段（19:00:01-6:59:59）2元/120分钟。时段满收费。
     *  2.无免费时间，第一时段（7:00:00-19:00:00）5元/20分钟；第二时段（19:00:01-6:59:59）2元/120分钟。时段满收费。
     */
    public class Seg2Engine : Engine
    {
        //public Seg2Engine(string RuleName) : base(RuleName) { }
        /// 一天中的时间段 精确到秒 但这里就用整形 .NET SDK可以完成全自动转化  
        /// 0.5天 = 720分 = 43200秒
        /// 1天   = 1440分 = 86400秒
        public Tuple<DateTime, DateTime> Segment1 { get; set; }
        public Tuple<DateTime, DateTime> Segment2 { get; set; }
        // 后续所有单元默认使用第二段收费规则 如果用户勾选则选择第一段
        public bool UseSeg2 = true;

        ///【离心机】时间轴切片Tuple说明 1.计费规则 2.计费单元 3.单元价格
        public void Centrifuge(double TTM, 太极 TaiJi)
        {
            // 1.阴阳合和
            var CUBE = TaiJi == 太极.阳 ? CubeSun : CubeMoon;
            // 2.矩阵平方
            int divides = (int)TTM / CUBE.Item2;
            double tailer = TTM % CUBE.Item2;
            // 3.辗转相除
            for (int i = 0; i < divides; i++)
            {
                TotalResult += CUBE.Item1; Tailer.Add(new Tuple<int, string, float>(CUBE.Item2, EngineToken, CUBE.Item1));
            }
            // 4.虚位以待
            Tailer.Add(new Tuple<int, string, float>((int)tailer, EngineToken + $"尾巴时间[{tailer}]分钟", CUBE.Item1));
        }

        /// <summary>
        /// 如果超过当日让用户选择 超出第一天的部分 按照何种规则计价: 第一天夜间规则还是第一(二)天白天规则 
        /// v1版本的两段式算法的逻辑为 (x / y * (times1 - 1)) + tailer1 + (z / c * (times2 - 1)) + tailer2
        /// </summary>
        /// <param name="t1">入场时间</param>
        /// <param name="t2">出场</param>
        /// <param name="LetGo">是否直接放行 转为按次计费</param>
        /// <returns></returns>
        public override void CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            // 以下算法的逻辑 建立在 `最小计费单元是分钟`的基础上 不代表不可以继续切割分钟为更小的时间单元

            if (t1.Year != t2.Year) throw new NotImplementedException("跨年算法暂时不公开...");
            if (t1 > t2) throw new InvalidOperationException("出场时间必须大于入场时间");
            if (Segment1.Item2 >= Segment2.Item1) throw new InvalidOperationException("两段式设置不允许有时间轴交集");

            // 免费停车
            double TTM = Math.Abs((t2 - t1).TotalMinutes);
            InTime = t1 > t2 ? t2 : t1;
            OutTimme = t1 < t2 ? t1 : t2;
            if ((int)TTM <= F1) return;

            #region 八阵图中枢枢纽层: 时钟自旋(1分钟) > 地球自转(1天) > 地球公转(1年) > 太阳公转(酒神代) > 银河公转(谷雨代) 
            // 阳
            if (t1 >= Segment1.Item1 && t1 <= Segment1.Item2)
            {
                if (t2 <= Segment2.Item1) // 不跨时段
                {
                    Centrifuge(TTM, 太极.阳);
                }
                else // 跨时段 
                {
                    /* 划断一个[中轴线] :左边分钟数*带入阳面指针 + 右边分钟数 * 带入阴面指针 */

                }
            }
            // 阴
            if (t1 >= Segment2.Item1 && t1 <= Segment2.Item2)
            {
                if (t2 <= Segment1.Item1.AddDays(1)) // 不跨时段(升级维度：第二天) 
                {
                    Centrifuge(TTM, 太极.阴);
                }
            }
            #endregion

            #region 八阵图外环层 - 1 / ∞ == 0.001 离心机能切割的最小时间单元 : 以太

            #endregion
        }
    }
}
