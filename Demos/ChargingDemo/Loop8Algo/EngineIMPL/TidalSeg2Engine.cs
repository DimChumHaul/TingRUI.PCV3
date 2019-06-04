using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    public class TidalSeg2Engine : Seg2Engine
    {
        public TidalSeg2Engine(string RuleName) : base(RuleName) { }

        /* 两段式潮汐:代码混淆 */
        // 两段式潮汐: 弱水三千 只取一`瓢(两段式(潮汐时间H1着色))` 
        // 这实际上是一种 排除算法 计算的核心 1.折扣率 2.享受折扣率的事件片儿
        #region PCM = PinColorMinutes 算法的继承：先调用两段式算法计费 然后去引擎内部的Tail容器中***着色小球*** 最后带入折扣率
        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            // 时间轴校对
            
            if (Segment1.Item2 >= Segment2.Item1) throw new InvalidOperationException("两段式设置不允许有时间轴交集");
            /* TTM 时间轴校对函数 */
            ParamCheck(t1, t2);
            // 免费停车
            double TTM = Math.Abs( (t2 - t1).TotalMinutes );
            if ((int)TTM <= FreeSeg1) return -.0m;

            // 2.这里非常复杂。。。。
            
            
            return -.0m;
        }
        #endregion
    }
}
