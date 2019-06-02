using System;

namespace Algorithm.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("时间管理单元 Demo!");

            var t = DateTime.Now;
            var tuc = new TimeManageUnit
            {
                SegOneStartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                SegTwoStartTime = TimeSpan.FromTicks(DateTime.Now.AddSeconds(3).Ticks)
            };
            bool OK = tuc.IsTimeInSegOne(t);

            // 微软进行了 全自动的 时间戳转换10进制算法
            var v1 = t.AddMinutes(3);
            var v2 = t.AddMinutes(3.9);
            var NextHour = t.AddHours(1.5);
        }
    }
}
