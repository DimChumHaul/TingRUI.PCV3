using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offline.Data.TingRUI.Models.DataTemplate
{
    // 功能按钮抽象出来的底层数据模型
    public class FuncBtnModel : WpfUI
    {
        public bool IsOfflineSupport { get; } = false;
        public string RemoteImage { get; set; }
        public int OrderIndex { get; set; } = 0;
        public string URILocator { get; set; } = "/WPF/V1/MvvMLight/Page/2/CreateOrder/New";
        public bool IsSizeSharedScope = true;

        public override string ToString()
        {
            return this.ToSafeJson();
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
                //new { Name ="|",SvgIcon = "." },
                new { Name = "操作员管理", SvgIcon = "CalendarYear"  },
                new { Name = "实时监控", SvgIcon = "Camera"  },
                new { Name = "数据库备份", SvgIcon = "ConnectionWifiVariant"  },
                new { Name = "数据库还原", SvgIcon = "DrawPenReflection"  },
                new { Name = "重新登陆", SvgIcon = "Laptop"  },
                new { Name = "夏老师", SvgIcon = "FuturamaFry"  },
            };
            for (int i = 0; i < AcceptModuels.Count; i++)
            {
                var row = new FuncBtnModel
                {
                    Title = AcceptModuels.ElementAt(i).Name,
                    OrderIndex = i,
                    SVGImage = AcceptModuels[i].SvgIcon,
                    IsSizeSharedScope = i % 2 == 0,
                };
                data.Add(row);
            }
            return data;
        }
    }
}
