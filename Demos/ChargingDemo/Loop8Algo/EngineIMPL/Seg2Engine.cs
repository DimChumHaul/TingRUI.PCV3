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
        public Seg2Engine(string RuleName) : base(RuleName) { }
        /// 一天中的时间段 精确到秒 但这里就用整形 .NET SDK可以完成全自动转化  
        /// 0.5天 = 720分 = 43200秒
        /// 1天   = 1440分 = 86400秒
        public Tuple<int, int> Seg1 { get; set; }
        public Tuple<int, int> Seg2 { get; set; }

        // 后续所有单元默认使用第二段收费规则 如果用户勾选则选择第一段
        public bool UseSeg2 = true;

        public void Time2Money(double TTM , 太极 SunSet = 太极.阳) 
        {
            // 1.阴阳画断
            var CUBE = SunSet == 太极.阳 ? CubeSun : CubeMoon;
            // 2.矩阵平方
            int divides = (int)TTM / CUBE.Item2;
            double tailer = TTM % CUBE.Item2;
            // 3.辗转相除
            for (int i = 0; i < divides; i++)
            {
                TotalResult += CUBE.Item1;
                /// 参数列表 1.计费单元 2.计费规则 3.单元价格
                Tailer.Add(new Tuple<int, string, float>(CUBE.Item2, EngineToken,CUBE.Item1));
            }
            // 处理【尾巴算法】只记录 不计价
            Tailer.Add(new Tuple<int, string, float>((int)tailer, EngineToken + $"尾巴时间[{tailer}]分钟", CUBE.Item1));
        }

        public override double CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            // 以下算法的逻辑 建立在 `最小计费单元是分钟`的基础上 不代表不可以继续切割分钟为更小的时间单元
            if (t1.Year != t2.Year) throw new NotImplementedException("跨年算法暂时不公开...");
            if (t1 > t2) throw new InvalidOperationException("出场时间必须大于入场时间");
            if (Seg1.Item2 >= Seg2.Item1) throw new ArgumentException("两段式设置不允许有时间轴交集");

            double TTM = Math.Abs((t2 - t1).TotalMinutes);
            bool isFree2Go = (int)TTM <= base.F1;
            TotalResult = -0.0f;
            InTime = t1 > t2 ? t2 : t1;
            OutTimme = t1 < t2 ? t1 : t2;
            // v1版本的两段式算法的逻辑为 (x / y * (times1 - 1)) + tailer1 + (z / c * (times2 - 1)) + tailer2

            // 开始计费 1.寻找起始点 
            if (isFree2Go) return TotalResult;
            // 白天停车
            if (t1.Hour >= Seg1.Item1 && t1.Hour <= Seg1.Item2)
            {
                // 不跨时段
                if (t2 <= DateTime.Today.AddHours(Seg1.Item2))
                {
                    Time2Money(TTM, 太极.阳);
                    return TotalResult ;
                }
                // 跨时段
                if (UseSeg2)
                {
                    /* 如果超过当日让用户选择 超出第一天的部分 按照何种规则计价: 第一天夜间规则还是第一(二)天白天规则 */
                }
                else
                {
                    // type == 3(1---2---1---)
                }
            }
            // 夜间停车 
            else if (t1.Hour >= Seg2.Item1 && t1.Hour <= Seg2.Item2)
            {
                // 不跨时段
                if (t2 <= DateTime.Today.AddHours(Seg2.Item2))
                {
                    Time2Money(TTM, 太极.阴);
                    return TotalResult;
                }
                // 跨时段
                if (UseSeg2)
                {
                    /* 如果超过当日让用户选择 超出第一天的部分 按照何种规则计价: 第一天夜间规则还是第一(二)天白天规则 */
                }
                else
                {
                    // type == 3(1---2---1---)
                }
            }
            else
            {
                TotalResult = 0.0d; // 白天和晚上各有1分钟的缓冲区
            }
            return TotalResult;
        }
    }
}
