using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.Data.TingRUI.Models.DataTemplate
{
    public enum LeftBarUIType
    {
        SystemAdmin,UserAdmin,ParkingFactory,LiveMonitor,CrystalReports
    }
    public class FuncMenuModel : WpfUI
    {
        public List<FuncBtnModel> MenuSublines { get; set; } = new List<FuncBtnModel>();
        public int SubCount { get; }
        public LeftBarUIType NodeTag { get; set; }

        public FuncMenuModel()
        {
            SubCount = this.MenuSublines.Count();
        }

        public static List<FuncMenuModel> FakeData()
        {
            var data = new List<dynamic>
            {
                new { MenuTitle = "系统管理", Type = LeftBarUIType.SystemAdmin },
                new { MenuTitle = "用户管理", Type = LeftBarUIType.UserAdmin },
                new { MenuTitle = "车厂管理", Type = LeftBarUIType.ParkingFactory },
                new { MenuTitle = "实时监控", Type = LeftBarUIType.LiveMonitor },
                new { MenuTitle = "报表管理", Type = LeftBarUIType.CrystalReports },
            };
            var result = new List<FuncMenuModel>();
            for (int i = 0; i < data.Count; i++)
            {
                result.Add(new FuncMenuModel {
                    NodeTag = data[i].Type,
                    Title = data[i].MenuTitle });
            }
            return result;
        }
    }
}
