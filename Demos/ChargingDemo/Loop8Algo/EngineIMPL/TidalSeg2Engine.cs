using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo.EngineIMPL
{
    public class TidalSeg2Engine : Engine
    {
        public TidalSeg2Engine(string RuleName) : base(RuleName) { }
        public override decimal? CalculationIMPL(DateTime t1, DateTime t2, bool LetGo = false)
        {
            // 已落实臻识相机样机，签署借用协议后给我司发 At 2019.06.04 14:37:00 从?发货到成都停如意
            if (LetGo) return base.LetGoPrice;
            throw new NotImplementedException("关门放狗 必须给钱放行~");
        }
    }
}
