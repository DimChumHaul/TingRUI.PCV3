using ServiceStack;
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
        protected internal int AllHHs { get; set; }
        /// 逗留的剩余分钟数
        protected internal int RestMMs { get; set; }
        /// 剩余秒数
        protected internal int RestSSs { get; set; }
        /// 软件部署类型
        private ConsumeType CSType { get; }

        // 关键数据结构 PreciselyToken
        /// 当日的 hh:mm:ss & 人类识别字符串
        protected internal (int HH,int MM, int SS) PreciselyPivot { get; set; }

        internal PivotTemplate(DateTime t1,DateTime t2,ConsumeType type = ConsumeType.停车收费软件)
        {
            double duration = Math.Abs((t1 - t2).TotalSeconds);
            // 统计驻留 总的小时分钟和秒数
            AllHHs = (int)duration / (MaxTU * 60);
            RestMMs = (int)duration % MaxTU;
            RestSSs = (int)duration % (MaxTU * 60);

            /* 计算出场时间位于未来当日的几点几分几秒 HH:MM:SS */
            var ttime = t2.TimeOfDay;
            PreciselyPivot = new ValueTuple<int,int,int>(ttime.Hours,ttime.Minutes,ttime.Seconds);
            // 部署类型
            CSType = type;
        }

        public override string ToString()
        {
            return $"消费类型: {CSType}".ToJson() + base.ToString();
        }
        // 最小时间单元 :1分钟(60秒)
        internal const int MinTU = 1;
        // 最大时间单元 :1440分钟(1天)
        internal const int MaxTU = 1440;
    }
}
