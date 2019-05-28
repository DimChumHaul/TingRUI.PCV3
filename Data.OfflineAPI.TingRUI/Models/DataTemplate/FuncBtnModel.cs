using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TingRUI.Data.Models.DataTemplate
{
    // 功能按钮抽象出来的底层数据模型
    public class FuncBtnModel : UIBase
    {
        public Int32 OrderIndex { get; set; } = -1;
        public string RemoteImage { get; set; }
        public string URILocator { get; set; } = "/TingRUI/PCWin32/WSAPI/V1/MvvMLight/Button4";
        public bool IsOfflineSupport { get; } = false;

        public override string ToString()
        {
            return this.ToSafeJson();
        }

        public FuncBtnModel(string ModuleName , int orderIndex = -1)
        {
            URILocator = URILocator.TrimEnd('/');
            ModuleName = ModuleName.TrimEnd('/',';');

            if (!string.IsNullOrEmpty(this.ToJson()))
            {
                var commandURI = $"{URILocator}/{ModuleName}";

                // 判断 模块功能URI是否格式正确
                var code = commandURI.LastRightPart('/');
                if (string.IsNullOrWhiteSpace(code))
                    throw new NotImplementedException("模块Uri格式错误或功能缺失");
                else
                {
                    OrderIndex = orderIndex;
                    URILocator = commandURI;
                }
            }
        }

        public static IEnumerable<FuncBtnModel> FakeData()
        {
            var data = new List<FuncBtnModel>();

            // <iconPacks:PackIconModern Kind="Marketplace" />
            /* 动态配置主界面顶部【操作员功能模块】 */
            var AcceptModuels = new List<dynamic> {
                new { Name = "收费设置" , SvgIcon = "BarCode" },
                new { Name = "车场设置", SvgIcon = "Marketplace" },
                new { Name = "车道设置", SvgIcon = "AdobePhotoshop"  },
                new { Name = "部门管理", SvgIcon = "BatteryCharging"  },
                new { Name = "用户管理", SvgIcon = "BookContact"  },
                new { Name = "车辆管理", SvgIcon = "BrowserChrome"  },
                new { Name = "操作员管理", SvgIcon = "CalendarYear"  },
                new { Name = "实时监控", SvgIcon = "Camera"  },
                new { Name = "数据库备份", SvgIcon = "ConnectionWifiVariant"  },
                new { Name = "数据库还原", SvgIcon = "DrawPenReflection"  },
                new { Name = "重新登陆", SvgIcon = "Laptop"  },
                new { Name = "夏老师", SvgIcon = "FuturamaFry"  },
            };
            for (int i = 0; i < AcceptModuels.Count; i++)
            {
                var row = new FuncBtnModel(AcceptModuels[i].Name, i+1)
                {
                    Title = AcceptModuels.ElementAt(i).Name,
                    SVGImage = AcceptModuels[i].SvgIcon,
                };
                data.Add(row);
            }
            return data;
        }
    }
}
