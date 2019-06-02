using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Demo
{
    internal class TimeManageUnit
    {
        internal bool IsTimeInSegOne(DateTime checkTime)
        {
            DateTime t = new DateTime(checkTime.Year, checkTime.Month, checkTime.Day, 
                this.SegOneStartTime.Hours, this.SegOneStartTime.Minutes, this.SegOneStartTime.Seconds);
            DateTime t2 = new DateTime(checkTime.Year, checkTime.Month, checkTime.Day, 
                this.SegTwoStartTime.Hours, this.SegTwoStartTime.Minutes, this.SegTwoStartTime.Seconds);
            $"checktime[{checkTime}] 宇宙时间: [{checkTime.ToUniversalTime()}] ,Unix时间戳:[{checkTime.ToUnixTime()}]".PrintDump();
            TimeSpan x = checkTime - t;
            TimeSpan x2 = checkTime.AddSeconds(3) - t2;
            return checkTime >= t && checkTime < t2;
        }

        public TimeSpan SegOneStartTime { get; set; }
        public TimeSpan SegTwoStartTime { get; set; }
    }
}
