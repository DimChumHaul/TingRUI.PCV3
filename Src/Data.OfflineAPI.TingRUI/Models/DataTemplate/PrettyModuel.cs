using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TingRUI.Data.Models.DataTemplate
{
    public class PrettyModuel
    {
        public string SvgImage { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; } = "子标题";

        /* 一个非常重要的 OrderIndex属性 直接绑定到模块中去 走绑定传递变量 */
        public uint OrderIndex { get; set; }

        public static bool isHoliday()
        {
            DayOfWeek NowDay = DateTime.Now.DayOfWeek;
            switch (NowDay)
            {
                case DayOfWeek.Friday:
                case DayOfWeek.Monday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                    return true;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                default:
                    return false;
            }
        }
    }
}
