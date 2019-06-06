using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgoCore.DKTStd;

namespace AlgoCore
{
    public class DKTStd
    {
        #region  增加函数最好是以`扩展函数`的形式增强SDK 方便调用
        internal static DateTime ParseTime2DTime(int h, int m, int s)
        {
            // 检查Time返回值是否越界
            DateTime Today = DateTime.Today;
            DateTime cTime = new DateTime(Today.Year, Today.Month, Today.Day, h, m, s);
            if (cTime > Today.AddDays(1) || cTime <= Today)
            {
                throw new Exception($"返回值是否越界: {ErrorInfo[0x7e]}");
            }
            return cTime;
        }

        public static Dictionary<byte, string> ErrorInfo = new Dictionary<byte, string>
        {
            { 0x7e , "返回值是否越界 : 时间转换函数逻辑错误" }
        };
        #endregion

        // 1.任意进制转换算法
        // 2.幽闭空间质数生成器
        // 3.微积分
        // 4.矩阵平方
        // 5.错峰算法
        // 6.倒转昆仑
        // 7.LINQ: 算法的继承
        // SDK中的 DateTime和Time之间的相互转换类
        public struct Time
        {
            public int HH { get; set; }
            public int MM { get; set; }
            public int SS { get; set; }
            public Time(int hh, int mm, int ss)
            {
                HH = hh; MM = mm; SS = ss;
                if (HH * MM * SS < 0) throw new NotImplementedException("【Time值传递】不可小于0");
            }
            /// <summary>
            /// 一个非常有用的 time.T2DT() 函数
            /// </summary>
            /// <returns>人工录入时间划段的SDK表达(DateTie)</returns>
            public DateTime T2DT()
            {
                return this.FromTime();
            }
        }
    }
    // 扩展.NET SDK 实现Time结构体的正反转化
    public static class TimeExtension
    {
        /// <summary>
        /// 正转 Time -> DateTime
        /// </summary>
        /// <param name="AnyTime">任意实例</param>
        /// <returns>DateTime</returns>
        public static DateTime FromTime(this Time AnyTime)
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
