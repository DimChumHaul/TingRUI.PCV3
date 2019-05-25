using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.Data.TingRUI.Models.DataTemplate
{
    public class FuncMenuModel : WpfUI
    {
        public bool HasSonNode { get; set; } = true;
        public List<FuncBtnModel> MenuSublines { get; set; } = new List<FuncBtnModel>();
        public int SubCount { get; }

        public FuncMenuModel()
        {
            SubCount = this.MenuSublines.Count();
        }

        public static List<FuncMenuModel> FakeData()
        {
            var data = new List<dynamic>
            {
                new { MenuTitle = "系统管理" },
                new { MenuTitle = "用户管理" },
                new { MenuTitle = "车厂管理" },
                new { MenuTitle = "实时监控" },
                new { MenuTitle = "报表管理" },
            };
            var result = new List<FuncMenuModel>();
            for (int i = 0; i < data.Count; i++)
            {
                result.Add(new FuncMenuModel { HasSonNode = false , Title = data[i].MenuTitle });
            }
            return result;
        }
    }
}
