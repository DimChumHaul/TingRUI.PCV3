using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TingRUI.Data.JustEnum;

namespace TingRUI.Data.Models.DataTemplate
{
    // MDM : Modulized Data Menu 模块化菜单组选数据模板 用作UI第二层容器 
    // 按类型进行分类管理 用枚举类型就行分组实现
    public class ModualizedMenu : PrettyModuel
    {
        public List<ModulizedBtn> MenuSublines { get; set; } = new List<ModulizedBtn>();
        public LeftBarUIType gTypeL1 { get; set; }

        public static List<ModualizedMenu> FakeData()
        {
            var data = new List<dynamic>
            {
                new { MenuTitle = "系统管理", Type = LeftBarUIType.SystemAdmin },
                new { MenuTitle = "用户管理", Type = LeftBarUIType.UserAdmin },
                new { MenuTitle = "车厂管理", Type = LeftBarUIType.ParkingFactory },
                new { MenuTitle = "实时监控", Type = LeftBarUIType.LiveMonitor },
                new { MenuTitle = "报表管理", Type = LeftBarUIType.CrystalReports },
            };
            var result = new List<ModualizedMenu>();
            for (int i = 0; i < data.Count; i++)
            {
                result.Add(new ModualizedMenu
                {
                    gTypeL1 = data[i].Type,
                    Title = data[i].MenuTitle
                });
            }
            return result;
        }
    }
}
