using AlgoCore.Enum;
using System;
using static AlgoCore.DKStd;

namespace AlgoCore
{
    /// <summary>
    /// 停如意盒子：带色彩的最小时间单元
    /// 出厂盒子大小为 C5m120d
    /// </summary>
    public sealed class TingRUICube
    {
        // 停车单元
        internal decimal? PTU { get; set; } = 5.0m;
        // 单元收费
        internal double MTU { get; set; } = 120d;
        // 默认每分钟的(流量)价钱
        internal double PPM { get; private set; }
        // 规则生效时间
        public Time RuleStart { get; set; }
        // 规则结束时间
        public Time RuleEnd { get; set; }

        #region 错峰算法预留字段
        // 盒子内部的`收费`折扣率
        internal double DisRate { get; set; } = 1.0f;
        // 是否带入折扣率 进行错峰打折
        internal bool EnableRuleCuoFeng { get; private set; } = false;
        #endregion

        /// <summary>
        /// 申请一个【停如意盒子】这是一个`通用的算法模型` 可用于一切计费软件的底层核心数据结构
        /// </summary>
        /// <param name="ruleDuration">【时间划界】 规则生效的起始时间和结束时间</param>
        /// <param name="priceGroup">【计费单元】盒子高度：5元/120分钟  </param>
        internal TingRUICube((Time rStart, Time rEnd) ruleDuration,
            (decimal price, double tUnit, double disRate) priceGroup)
        {
            // 初始化【计费盒子】
            PTU = priceGroup.price;
            MTU = (int)priceGroup.tUnit;
            DisRate = priceGroup.disRate <= .0d ? 1.0d : priceGroup.disRate;
            if (DisRate <= 0.0f || DisRate >= 1.0f) throw new Exception("初始化盒子失败：折扣率不能越界[0~1.0]");
            if (PTU <= .0m) throw new Exception("初始化盒子失败: 适配最小时间单元参数1[元]错误");
            if (MTU <= .0d) throw new Exception("初始化盒子失败: 适配最小时间单元参数2[分钟]错误");

            RuleStart = ruleDuration.rStart;
            RuleEnd = ruleDuration.rEnd;

            PTU *= (decimal?)DisRate;
            PPM = (double)PTU / MTU;
        }
    }
}
