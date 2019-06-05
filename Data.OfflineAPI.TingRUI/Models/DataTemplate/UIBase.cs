﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TingRUI.Data.Models.DataTemplate
{
    public class UIBase
    {
        public string Title { get; set; } = "WpfCtrlBase空间标题";
        public string SubTitle { get; set; } = "子标题";
        public string SVGImage { get; set; } = "打开NuGet搜索 `MahApps.Metro.IconPacks`";

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
                    return false;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                default:
                    return true;
            }
        }
    }
}
