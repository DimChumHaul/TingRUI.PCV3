//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AlgoCore.Loop8Algo.EngineIMPL
//{
//    #region PCM = PinColorMinutes 算法的继承：先调用两段式算法计费 然后去引擎内部的Tail容器中***着色小球*** 最后带入折扣率
//    // 算法的继承
//    public class Seg2TidalEngine : Seg2Engine
//    {
//        public Seg2TidalEngine(string RuleName) : base(RuleName) { }
//        // M = Minutes 彭工给的是小时 我用分钟作单位
//        // 默认提供1小时的潮汐时间 延长潮汐时间能够提高车场收入 缓解交通压力
//        public double PCM { get; set; } = 60.0d + 0.0001;
//        public decimal? H1P { get; set; } = 1.50m;
//        // 潮汐获利金 = 所有抄袭订单切片的总活力金额
//        public decimal? TotalResultMinus { get; set; } = .0m;

//        // 折扣率 - 需要动态计算
//        private float DiscountRate = 1.0f;

//        // 两段式潮汐: 弱水三千 只取一`瓢(两段式(潮汐时间H1着色))` 
//        // 这实际上是一种【排除法】 计算逻辑是 1.折扣率 2.享受折扣率的时间片儿 两者相减得出优惠的价格
//        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
//        {
//            // 时间轴校对
//            if (Segment1.Item2 >= Segment2.Item1) throw new Exception("两段式设置不允许有时间轴交集");
//            /* TTM */
//            ParamCheck(t1, t2);
//            // 1.免费停车
//            double TTM = Math.Abs((t2 - t1).TotalMinutes);
//            if ((int)TTM <= FreeSeg1) return -.0m;

//            // 2-1.先计算原始价格
//            // 2-2.计算折扣率
//            DiscountRate = (float)(H1P / CubeSun.Item1);
//            if (DiscountRate < 0) throw new Exception("折扣率不可以为负数");
//            if (DiscountRate == 0) throw new NotImplementedException("潮汐价等于原价 折扣率恒等于1");
//            if (DiscountRate > 1.0) throw new ArgumentOutOfRangeException("折扣率大于1.0 存在风险");
//            base.CalculationIMPL(t1, t2, LetGo);
//            int NumbersOfColoredBallWhichIShouldMakeDiscountantThenMinusToGetFialResult = (int)(PCM / CubeSun.Item2);
//            var PriceToMinus = base.CubeSun.Item1 - this.H1P;
//            for (int i = 0; i < NumbersOfColoredBallWhichIShouldMakeDiscountantThenMinusToGetFialResult; i++)
//            {
//                // 总价格的价格减免 循环
//                TotalResult -= PriceToMinus;
//                TotalResultMinus += PriceToMinus;
//                // 下到Tail尾巴算法容器内部进行【计费清单】的操作
//                int n1 = Tail[i].Item1;
//                var s1 = Tail[i].Item2;
//                var p1 = Tail[i].Item3 - PriceToMinus;
//                // 核心算法 用色彩去标记小球 统计 1.折扣率 2.潮汐获利金 3.小球着色标记
//                Tail[i] = new Tuple<int, string, decimal?, bool?>(n1, s1, p1, true);
//            }
//            return TotalResult;
//        }
//    }
//    #endregion
//}
