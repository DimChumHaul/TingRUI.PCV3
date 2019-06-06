using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.Loop8Algo
{
    public enum ConsumeType { 停车收费软件 , 网吧收费软件 , 酒店夜审模组 , 高速计费模组 }
    // 时间中枢轴 人类时间 从3点上网到12点 一共消费`8小时20分32秒 消费类型为【上网消费】`
    public class PivotTemplate
    {
        /// 逗留的总天数
        public int Day { get; set; }
        /// 逗留的当日剩余分钟数
        public int Minute { get; set; }
        /// 软件部署类型
        ConsumeType ConsumeType;
        /// 人类识别字符串
        public (int h,int m) HourMinutes { get; set; }
        internal PivotTemplate(DateTime t1,DateTime t2,ConsumeType type = ConsumeType.停车收费软件)
        {
            double duration = Math.Abs((t1 - t2).TotalMinutes);
            Day = (int)duration / MaxTU;
            Minute = (int)(duration % MaxTU);
            ConsumeType = type;
            HourMinutes = (Minute / 60, Minute % 60);
        }
        // 最小时间单元 :1分钟(60秒)
        internal const int MinTU = 1;
        // 最大时间单元 :1440分钟(1天)
        internal const int MaxTU = 1440;
    }
}
