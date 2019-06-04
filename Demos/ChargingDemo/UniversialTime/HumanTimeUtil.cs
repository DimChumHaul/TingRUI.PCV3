using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.UniversialTime
{
    /// <summary>
    /// 人类时间管理单元 存放一些常用算法 
    /// 例如 1.千禧年问题 2.新浪微博时间尾巴儿 3.中国农历 4.Unix转换当天时间 5.DateTime转Time(当日)
    /// 增加函数最好是以`扩展函数`的形式增强SDK 方便调用
    /// </summary>
    public static class HumanTimeUtil
    {
        public static DateTime MakeTime(this DateTime ATime,int h, int m, int s)
        {
            // 控制指针左右边界
            if (ATime == DateTime.MinValue) ;

            DateTime Today = DateTime.Today;
            DateTime FakeTime = new DateTime(Today.Year, Today.Month, Today.Day, h, m, s);
            if (FakeTime > Today.AddDays(1) || FakeTime <= Today)
            {
                throw new Exception("时间管理器警告：逻辑错误");
            }
            return FakeTime;
        }
    }
}
