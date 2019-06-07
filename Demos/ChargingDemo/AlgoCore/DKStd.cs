using System;
using System.Collections.Generic;

namespace AlgoCore
{
    /// <summary>
    /// DK:丁亢 的算法藏经阁
    /// </summary>
    public static class DKStd
    {
        #region  增加函数最好是以`扩展函数`的形式增强SDK 方便调用
        public static DateTime ParseTime2DTime(int h, int m, int s)
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
            { 0x7e , "返回值是否越界 : 时间转换函数逻辑错误" },
            { 0x3b , "跨年算法暂时不公开..." }
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
            public Int32 HH { get; set; }
            public Int32 MM { get; set; }
            public Int32 SS { get; set; }

            public Time(int hh, int mm, int ss)
            {
                HH = hh; MM = mm; SS = ss;
                if (HH == 0)
                    if (MM == 0)
                    {
                        SS++;
                        if(SS == 0)
                            throw new NotImplementedException("【Time值传递】三段式设置不可以都为0");
                    }
            }
            /// <summary>
            /// 一个非常有用的 time.T2DT() 函数
            /// </summary>
            /// <returns>人工录入时间划段的SDK表达(DateTie)</returns>
            public DateTime T2DT()
            {
                return this.FromTime2DT();
            }
        }
    }
    
}
