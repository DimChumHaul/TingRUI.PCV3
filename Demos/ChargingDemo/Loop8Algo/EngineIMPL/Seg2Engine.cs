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
        // 一天中的小时数
        public virtual Tuple<int, int> H1 { get; set; }
        public virtual Tuple<int, int> H2 { get; set; }
        // 后续所有单元默认使用第二段收费规则 如果用户勾选则选择第一段
        public bool UseSeg2 = true;

        public override double CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            // 以下算法的逻辑 建立在 `最小计费单元是分钟`的基础上 不代表不可以继续切割分钟为更小的时间单元
            if (t1.Year != t2.Year) throw new NotImplementedException("跨年算法暂时不公开...");
            if (t1 > t2) throw new InvalidOperationException("出场时间必须大于入场时间");
            if (H1.Item2 >= H2.Item1) throw new ArgumentException("两段式设置不允许有时间轴交集");

            var TTM = Math.Ceiling(Math.Abs((t2 - t1).TotalMinutes));
            bool isFree2Go = (int)TTM <= base.F1;
            this.TotalResult = -0.0f;
            this.InTime = t1 > t2 ? t2 : t1;
            base.OutTimme = t1 < t2 ? t1 : t2;
            // v1版本的两段式算法的逻辑为 (x / y * (times1 - 1)) + tailer1 + (z / c * (times2 - 1)) + tailer2

            // 开始计费 1.寻找起始点 
            if (isFree2Go) return TotalResult;
            if (t1.Hour >= H1.Item1 && t1.Hour <= H1.Item2)
            {
                // 白天停车
                起始时段 = 两仪.阳;
                if (UseSeg2)
                {

                }
                else
                {
                    /* 如果超过当日让用户选择 超出第一天的部分 按照何种规则计价: 第一天夜间规则还是第一(二)天白天规则 */
                }
            }
            else if (t1.Hour >= H2.Item1 && t1.Hour <= H2.Item2)
            {
                // 夜间停车 
                起始时段 = 两仪.阴;
                if (UseSeg2)
                {

                }
                else
                {

                }
                /* 如果超过当日让用户选择 超出第一天的部分 按照何种规则计价: 第一天夜间规则还是第一(二)天白天规则 */
            }
            else
            {
                // 白天和晚上各有1分钟的缓冲区
            }
            return TotalResult;
        }
    }
}
