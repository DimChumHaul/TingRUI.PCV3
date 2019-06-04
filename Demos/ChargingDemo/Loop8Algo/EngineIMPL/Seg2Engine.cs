using ChargingDemo.Loop8Algo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region 死门 :1/(x*y + x^2*y^2 + x^3*y^3 + ....)    :生还可能为0
#endregion
#region 生门 :1/∞ == 0.001 离心机能切割的最小时间单元 :以太
#endregion

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    /* 
     * 二段式收费 :
     *  1.免费时间10分钟，第一时段（7:00:00-19:00:00）5元/20分钟；第二时段（19:00:01-6:59:59）2元/120分钟。时段满收费。
     *  2.无免费时间，第一时段（7:00:00-19:00:00）5元/20分钟；第二时段（19:00:01-6:59:59）2元/120分钟。时段满收费。
     */
    public class Seg2Engine : Engine
    {
        public Seg2Engine(string RuleName) : base(RuleName) { }
        /// 一天中的时间段 精确到秒 但这里就用整形 .NET SDK可以完成全自动转化  
        /// 0.5天 = 720分 = 43200秒
        /// 1天   = 1440分 = 86400秒
        public Tuple<DateTime, DateTime> Segment1 { get; set; }
        public Tuple<DateTime, DateTime> Segment2 { get; set; }

        /* 白天盒子 */
        public Tuple<decimal?, int> CubeSun { get; set; }
        /* 夜晚盒子 */
        public Tuple<decimal?, int> CubeMoon { get; set; }

        /* 后续所有单元默认使用第二段收费规则 如果用户勾选则选择第一段 */
        public 太极 CrossNightRule { get; set; } = 太极.阴;

        ///【离心机】时间轴切片Tuple说明 1.计费规则 2.计费单元 3.单元价格
        ///【太极】只支持【阴阳相生】换句话说只支持两段式 时间轴区间划断 不支持24小时制 
        /// 苦恼~：八阵图达不到我所理想的 *** 通用模型 *** 效果
        /// 也许是我抽象方式有问题：【还不够精准】
        public void EngineGo(double TTM, 太极 TaiJi)
        {
            // 1.阴阳合和
            var CUBE = TaiJi == 太极.阳 ? CubeSun : CubeMoon; 
            // 2.矩阵平方
            int divides = (int)TTM / CUBE.Item2;
            double tailer = TTM % CUBE.Item2;
            // 3.辗转相除
            for (int i = 0; i < divides; i++)
            {
                TotalResult += CUBE.Item1;
                Tailer.Add(new Tuple<int, string, decimal?,bool?>(CUBE.Item2, EngineToken, CUBE.Item1,false));
            }
            // 4.虚位以待
            Tailer.Add(new Tuple<int, string, decimal?, bool?>((int)tailer, EngineToken + $"尾巴时间[{tailer}]分钟", CUBE.Item1,false));
            Billing = $"停车收费:[{TotalResult}]元...算法规则({EngineToken})";
        }

        /// <summary>
        /// 如果超过当日让用户选择 超出第一天的部分 按照何种规则计价: 第一天夜间规则还是第一(二)天白天规则 
        /// v1版本的两段式算法的逻辑为 (x / y * (times1 - 1)) + tailer1 + (z / c * (times2 - 1)) + tailer2
        /// </summary>
        /// <param name="t1">入场时间</param>
        /// <param name="t2">出场</param>
        /// <param name="LetGo">是否直接放行 转为按次计费</param>
        /// <returns></returns>
        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            if (Segment1.Item2 >= Segment2.Item1) throw new InvalidOperationException("两段式设置不允许有时间轴交集");
            /* TTM 时间轴校对函数 */
            ParamCheck(t1, t2);

            // 免费停车
            double TTM = Math.Abs((t2 - t1).TotalMinutes);
            if ((int)TTM <= FreeSeg1) return -.0m;
            
            /* 基础算法的展开 */
            #region 八阵图中枢神经层 :时钟自旋(1分钟) > 地球自转(1天) > 地球公转(1年) > 太阳公转(酒神代) > 银河公转(谷雨代) 
            // &升维: 地球自转(1天)：第二天
            var TomorrowBegin = Segment1.Item1.AddDays(1);
            // 阳面
            if (t1 >= Segment1.Item1 && t1 <= Segment1.Item2)
            {
                // 不跨时段
                if (t2 <= Segment2.Item1) EngineGo(TTM, 太极.阳);
                else // 跨时段 
                {
                    var TTML1 = (Segment1.Item2 - t1).TotalMinutes;
                    EngineGo(TTML1, 太极.阳);
                    // 递归划断一个[中轴线] :左边分钟数*带入阳面指针 + 右边分钟数 * 带入阴面指针
                    var TTMR1 = (t2 - Segment2.Item1).TotalMinutes;
                    EngineGo(TTMR1, 太极.阴);
                }
            }
            // 阴面 & 不跨时段
            else if (t1 >= Segment2.Item1 && t2 <= TomorrowBegin) EngineGo(TTM, 太极.阴); 
            else // 跨时段
            {
                var TTMLeft = (t2 - TomorrowBegin).TotalMinutes;
                EngineGo(TTMLeft, CrossNightRule);
                // 递归划断一个[中轴线] :左边分钟数*带入阳面指针 + 右边分钟数 * 带入阴面指针
                var TTMRight = (TomorrowBegin - t1).TotalMinutes;
                EngineGo(TTMRight, 太极.阴);
            }
            return TotalResult;
            #endregion
        }
    }
}
