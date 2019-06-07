
//using AlgoCore.Enum;
//using System;
//using System.Collections.Generic;

//#region 死门 :1/(x*y + x^2*y^2 + x^3*y^3 + ....)    :生还可能为0
//#endregion
//#region 生门 :1/∞ == 0.001 离心机能切割的最小时间单元 :以太
//#endregion

//namespace AlgoCore.Loop8Algo.EngineIMPL
//{
//    /** v1.0【时间轴切片】的设计灵感来源：电影 <雷神2:暗黑世界>
//    *      西方神话中关于时间的最小单元: `以太`的解释：
//    *      https://baike.baidu.com/item/%E4%BB%A5%E5%A4%AA/518267?fr=aladdin 
//    *      
//    * Pivot Segments: 用于存放最少1种最多N-1中计费规则 
//    * 时间轴切片: 通用计费软件中枢神经系统中的计费流水线
//    * 
//    *【算法的设计】:
//    * 携带时间轴的时间管理单元 会对地球自转的时间轴拉伸成一条直线  
//    * 这条直线的总长度为1440个MTU(最小时间单元) 俗称下刀 一刀划2段 N刀划N+1段  
//    * 一刀下去以后会生成两种规则 将`规则`统一抽象为一个【盒子(计价单元)】
//    *      例如：可口可乐流水线上的可乐代表流量 水瓶代表盒子 
//    *      3元一`种(不是一个)`盒子 10元代表`大容量盒子`
//    * 这里需要某种语言中的一种数据结构作容器 存放这些`时间轴切片儿`
//    */
//    public class Seg2Engine : EngineV1
//    {
//        public Seg2Engine(string RuleName) : base(RuleName) { }

//        /*【过夜规则】默认使用第二段收费规则 如果用户勾选则选择第一段 UI可以做成勾选框 */
//        public bool crossNightRuleChange { get; set; } = false;

//        /// <summary>如果超过当日让用户选择 超出第一天的部分 按照何种规则计价: 第一天夜间规则还是第一(二)天白天规则 
//        /// v1版本的两段式算法的逻辑为 (x / y * (times1 - 1)) + tailer1 + (z / c * (times2 - 1)) + tailer2
//        /// 
//        /// <param name="t1">入场时间</param>
//        /// <param name="t2">出场</param>
//        /// <param name="LetGo">是否直接放行 转为按次计费</param>
//        /// <returns> 停车收费原始的合计价(不包含上层规则算法打折的减免) 
//        /// </returns>
//        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
//        {
//            if (Segment1.Item2 >= Segment2.Item1) throw new InvalidOperationException("两段式设置不允许有时间轴交集");
//            /* TTM 时间轴校对函数 */
//            ParamCheck(t1, t2);

//            // 免费停车
//            double TTM = Math.Abs((t2 - t1).TotalMinutes);
//            if ((int)TTM <= FreeSeg1) return -.0m;

//            /* 基础算法的展开 */
//            #region 八阵图中枢神经层 :时钟自旋(1分钟) > 地球自转(1天) > 地球公转(1年) > 太阳公转(酒神代) > 银河公转(谷雨代) 
//            // &升维: 地球自转(1天)：第二天
//            var TomorrowBegin = Segment1.Item1.AddDays(1);
//            // 阳面
//            if (t1 >= Segment1.Item1 && t1 <= Segment1.Item2)
//            {
//                // 不跨时段
//                if (t2 <= Segment2.Item1) EngineGo(TTM, 太极.阳);
//                else // 跨时段 
//                {
//                    var TTML1 = (Segment1.Item2 - t1).TotalMinutes;
//                    EngineGo(TTML1, 太极.阳);
//                    // 递归划断一个[中轴线] :左边分钟数*带入阳面指针 + 右边分钟数 * 带入阴面指针
//                    var TTMR1 = (t2 - Segment2.Item1).TotalMinutes;
//                    EngineGo(TTMR1, 太极.阴);
//                }
//            }
//            // 阴面 & 不跨时段
//            else if (t1 >= Segment2.Item1 && t2 <= TomorrowBegin) EngineGo(TTM, 太极.阴);
//            else // 跨时段
//            {
//                var TTMLeft = (t2 - TomorrowBegin).TotalMinutes;
//                EngineGo(TTMLeft, CrossNightRule);
//                // 递归划断一个[中轴线] :左边分钟数*带入阳面指针 + 右边分钟数 * 带入阴面指针
//                var TTMRight = (TomorrowBegin - t1).TotalMinutes;
//                EngineGo(TTMRight, 太极.阴);
//            }
//            return TotalResult;
//            #endregion
//        }

//    }
//}
