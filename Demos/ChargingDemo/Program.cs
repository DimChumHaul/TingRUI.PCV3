using ChargingDemo.Loop8Algo;
using ChargingDemo.Loop8Algo.EngineIMPL;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo
{
    class Program
    {
        /*
        * 1.时段满收费为北京特例。所谓时段满收费就是满足一个时段的收费时长才能收费。
        * 2.比如说说2元/15分钟，就是停车每15分钟收2元，停车如果不到15分钟不能收任何费用。
        * 3.比如一辆车停了14分钟就是0元。停到15分钟收2元。停到16-29分钟仍旧是2元。停到30分钟收取4元。
        *   说明内的字母所涉及的时间、金额均不固定，可能会有任何数值出现。
        */
        static void Main(string[] args)
        {
            var random = new Random();
            var NMinutes = random.Next(1000);
            var T1 = DateTime.Now;
            var EndTime = T1.AddMinutes(NMinutes);

            IChargeEngine instance = new Seg2Engine("二段式收费", DateTime.MinValue)
            {
                // 模拟`二段式收费`
                F1 = 10,T1 = 20, T1Price = 5.0d, ANUnit = 120, ANUPrice = 2,
                StartTime = DateTime.Now, EndTime = EndTime
            };
            instance.PrintDump();
        }
    }
}