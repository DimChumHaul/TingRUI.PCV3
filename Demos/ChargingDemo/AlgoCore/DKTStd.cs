using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoCore
{
    public class DKTStd
    {
        // 最小时间单元 :1分钟(60秒)
        internal static readonly int MinTU = 1;
        // 最大时间单元 :1440分钟(1天)
        internal static readonly int MaxTU = 1440;
        /// <summary>
        /// 我的算法和人类不一样 我会默认 使用【格林威治时间】东1区 而北京/重庆真实的日落月落 是基于东八区计算的
        /// </summary>
        protected internal static readonly bool DayOrNight 
            = (DateTime.Now - DateTime.Today).TotalSeconds >= MaxTU / 2;

        public const string InfoWarning = "时间管理器警告 : ";

        protected static IDictionary<byte, string> ErrorReason = new Dictionary<byte, string>
        {
            { 0x7e,"内核异常.WarningReason : 时间轴越界" },
        };
    }
}
