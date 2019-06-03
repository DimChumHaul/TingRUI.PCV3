using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.CalculationModule
{
    /// <summary>
    /// 适用于人类一切`计费规则`相关的计费引擎接口
    /// </summary>
    interface IChargeEngine
    {
        /// <summary>
        /// 计费规则名称
        /// </summary>
        string EngineName { get; }

        /// <summary>
        /// 计费规则引擎 必须提供一种核心算法 规则算法 与 应用层行业 是一对多的关系 
        ///     例如 酒店管理行业就默认一种计费规则：夜审机制 
        ///     再例如 停车软件 可能存在多种`基于时间轴`的计费规则 必须一一实现该接口 一种规则一个接口实现类
        /// </summary>
        /// <param name="InTime">入场时间</param>
        /// <param name="OutTime">出场时间</param>
        /// <param name="OKToLetGo">是否放行通过(完成支付)</param>
        /// <returns>浮点数:订单合计价</returns>
        double CalculationPrice(DateTime InTime, DateTime OutTime, bool OKToLetGo = false);

        /// <summary>
        /// 输出规则明细(停车消费的所有流水清单和合计价格) 优惠卷+减免 应该再增加一个API单独计算
        /// </summary>
        /// <param name="TimeSlice">时间轴切片(切片+RuleName)</param>
        /// <param name="CharingRuleName">计费规则列表 与时间轴切片应该是一对一的关系</param>
        /// <returns>输出每一种计费规则:`消费清单 + 合计金额 + 消费优惠` </returns>
        string GenerateOrderDetail(List<Tuple<DateTime,DateTime,string>> TimeSlice);
    }
}
