using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TingRUI.Data.JustEnum;

namespace TingRUI.Data.Models.DataTemplate
{
    // 功能按钮抽象出来的底层数据模型
    // 名词解释 DM Data Model Modulized 模块化可配置数据模板
    public class ModulizedBtn : UIBase
    {
        public string RemoteImage { get; set; }
        public string URILocator { get; set; } = "/TingRUI/PCWin32/WSAPI/V1/MvvMLight/Button4";
        public bool IsOfflineSupport { get; } = false;

        // v0.1.2 增加一些属性用于为菜单按钮分组
        public LeftBarUIType gType { get; private set; }

        public override string ToString()
        {
            return this.ToSafeJson();
        }

        public ModulizedBtn(string ModuleName, LeftBarUIType gType)
        {
            URILocator = URILocator.TrimEnd('/');
            ModuleName = ModuleName.TrimEnd('/',';');

            if (!string.IsNullOrEmpty(this.ToJson()))
            {
                var commandURI = $"{URILocator}/{ModuleName}";

                // 判断 模块功能URI是否格式正确
                var code = commandURI.LastRightPart('/');
                if (string.IsNullOrWhiteSpace(code)) throw new NotImplementedException("模块Uri格式错误或功能缺失");

                URILocator = commandURI;
                this.gType = gType;
            }
        }

        public static IEnumerable<ModulizedBtn> FakeData()
        {
            var data = new List<ModulizedBtn>();

            // <iconPacks:PackIconModern Kind="Marketplace" />
            /* 动态配置主界面顶部【操作员功能模块】 */
            var FakeModules = new List<dynamic> {
                new { Name = "收费设置" , SvgIcon = "BarCode" ,Node = LeftBarUIType.SystemAdmin },
                new { Name = "车场设置", SvgIcon = "Marketplace",Node = LeftBarUIType.SystemAdmin },
                new { Name = "车道设置", SvgIcon = "AdobePhotoshop",Node = LeftBarUIType.SystemAdmin },
                new { Name = "部门管理", SvgIcon = "BatteryCharging",Node = LeftBarUIType.UserAdmin },
                new { Name = "用户管理", SvgIcon = "BookContact",Node = LeftBarUIType.UserAdmin },
                new { Name = "车辆管理", SvgIcon = "BrowserChrome",Node = LeftBarUIType.UserAdmin },
                new { Name = "操作员管理", SvgIcon = "CalendarYear",Node = LeftBarUIType.ParkingFactory },
                new { Name = "实时监控", SvgIcon = "Camera",Node = LeftBarUIType.ParkingFactory },
                new { Name = "数据库备份", SvgIcon = "ConnectionWifiVariant",Node = LeftBarUIType.LiveMonitor },
                new { Name = "数据库还原", SvgIcon = "DrawPenReflection",Node = LeftBarUIType.CrystalReports },
                new { Name = "重新登陆", SvgIcon = "Laptop",Node = LeftBarUIType.CrystalReports },
                new { Name = "夏老师", SvgIcon = "FuturamaFry", Node = LeftBarUIType.CrystalReports },
            };

            for (int i = 0; i < FakeModules.Count; i++)
            {
                var moduleBtn = FakeModules[i];

                //李孟阔是个猛男 惹不起(33%可能打得过) 所以高经理也惹不起
                var row = new ModulizedBtn(moduleBtn.Name, moduleBtn.Node) 
                {
                    Title = FakeModules.ElementAt(i).Name,
                    SVGImage = FakeModules[i].SvgIcon,
                    gType = moduleBtn.Node,
                };
                data.Add(row);
            }
            return data;
        }
    }
}
