using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgoCore.DKStd;

namespace AlgoCore
{
    // 扩展.NET SDK 实现Time结构体的正反转化
    public static class TimeExtension
    {
        /// <summary>
        /// 正转 Time -> DateTime
        /// </summary>
        /// <param name="AnyTime">任意实例</param>
        /// <returns>DateTime</returns>
        public static DateTime FromTime2DT(this Time AnyTime)
        {
            return DateTime.Today.AddHours(AnyTime.HH).AddMinutes(AnyTime.MM).AddSeconds(AnyTime.SS);
        }

        /// <summary>
        /// 反转 DateTime <- Time
        /// </summary>
        /// <param name="AnyDTime">任意DateTime实例</param>
        /// <returns>Time结构体</returns>
        public static Time ToTime(this DateTime AnyDTime)
        {
            return new Time(AnyDTime.Hour, AnyDTime.Minute, AnyDTime.Second);
        }
    }
}
