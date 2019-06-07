namespace AlgoCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //var random = new Random();
            //var NMinutes = random.Next(618,1440);
            //var T1 = DateTime.Now;
            //var T2 = T1.AddMinutes(NMinutes);
            //$"停车总时长[{NMinutes}]分钟 起始时间[{T1}],结束时间[{T2}]".PrintDump();
            //var t1Start = DateTime.Now.MakeTime(07, 00, 00);
            //var t1End = DateTime.Now.MakeTime(19, 00, 00);
            //var t2Start = t1End.AddMinutes(1);

            //// 二段式规则 测试实例
            //{
            //    /* 注意这里是第二天早上6点 有一个跨天的处理逻辑 */
            //    var t2End = t1Start.AddDays(1);
            //    {
            //        IChargeEngine instance = new Seg2Engine("二段式收费")
            //        {
            //            Segment1 = new Tuple<DateTime, DateTime>(t1Start, t1End),
            //            Segment2 = new Tuple<DateTime, DateTime>(t2Start, t2End),
            //            CubeSun = new Tuple<decimal?, int>(5.0m, 20),
            //            CubeMoon = new Tuple<decimal?, int>(2.0m, 120),
            //            CrossNightRule = Loop8Algo.Enum.太极.阴,
            //            FreeSeg1 = 10, // 免费时间10分钟 设置为0为没有免费时间
            //        };
            //        instance.CalculationIMPL(T1,T2);
            //        instance.PrintDump();
            //    }
            //}
            //// 潮汐式(Tital)规则 测试实例
            //{
            //    IChargeEngine RuleTital = new TidalEngine("潮汐收费")
            //    {
            //        FreeSeg1 = 6,
            //        CubeH1 = new Tuple<decimal?, int>(1.5m,15),
            //        CubeHN = new Tuple<decimal?, int>(2.0m,15),
            //    };
            //    RuleTital.CalculationIMPL(T1, T2);
            //    RuleTital.PrintDump();
            //}
            //// 单词收费规则 测试实例
            //{
            //    IChargeEngine Time1Rule = new SingleTimesEngine("按次收费");
            //    Time1Rule.CalculationIMPL(DateTime.MinValue, DateTime.MinValue, true);
            //    Time1Rule.PrintDump();
            //}

            while (true) ;
        }
    }
}