using AlgoCore.Enum;
using System;

namespace AlgoCore
{
    /// <summary>
    /// 停如意盒子：带色彩的最小时间单元
    /// </summary>
    public sealed class CubeRUI
    {
        public 太极 阴阳界 { get; private set; } = DKTStd.DayOrNight ? 太极.阳 : 太极.阴;
        // 内核引擎的出厂盒子大小为 C5m120d
        // 停车单元
        internal decimal? LastingPrice { get; set; } = 5.0m;
        // 单元收费
        internal double LastingMinutes { get; set; } = 120d;

        // PricePerMinutes 一分钟计费价
        internal double PPM { get; private set; } 
        // DiscountRate 计价单元折扣率
        internal float? DisRate { get; set; }
        // 是否打折 默认不打折
        internal bool ShouldDiscount { get; private set; } = false;

        internal CubeRUI(Tuple<decimal, double> priceUnit, float? disRate = 1.0f)
        {
            // 初始化【计费盒子】
            LastingPrice = priceUnit.Item1;
            LastingMinutes = (int)priceUnit.Item2;

            // 检查参数
            if (disRate <= 0.0f || DisRate >= 1.0f) throw new Exception("初始化盒子失败：折扣率不能越界[0~1.0]");
            if (LastingPrice <= .0m) throw new Exception("初始化盒子失败: 适配最小时间单元参数1[元]错误");
            if (LastingMinutes <= .0d) throw new Exception("初始化盒子失败: 适配最小时间单元参数2[分钟]错误");

            // 直接带入折扣率进行计算 软件部署安装之后 如果不改变折扣率 默认认为在1.0折扣率的基础之上进行时间单元的计费运算
            // 是否打折 是根据需求来的 以下两行代码也可以放到 函数顶部去执行
            DisRate = disRate;
            LastingPrice *= (decimal?)disRate;
            PPM = (double)LastingPrice / LastingMinutes;
        }
    }
}
