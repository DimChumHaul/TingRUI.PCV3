using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace PCChageTermialV3.TingRUI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    internal class MainViewModel : ViewModelBase
    {
        public string AppInfo { get; set; } = string.Format(
            "1.{0} App开发始于{1}",
            App.AppDescription, App.StartAt.ToLongDateString()
        );

        /* 动态配置主界面顶部【操作员功能模块】 */
        public IEnumerable<object> AcceptModuels { get; set; } = new List<dynamic> {
                new { Name = "收费设置" },
                new { Name = "车场设置" },
                new { Name = "车道设置" },
                new { Name = "部门管理" },
                new { Name = "用户管理" },
                new { Name = "车辆管理" },
                new { Name = "操作员管理" },
                new { Name = "实时监控" },
                new { Name = "数据库备份" },
                new { Name = "数据库还原" },
                new { Name = "重新登陆" },
                new { Name = "推出系统" },
            };
        /* 动态配置主界面左边系 【统菜单栏】 */
        public IEnumerable<object> AcceptMenus { get; set; } = new List<dynamic>
        {
            new { MenuTitle = "系统管理" },
            new { MenuTitle = "用户管理" },
            new { MenuTitle = "车厂管理" },
            new { MenuTitle = "实时监控" },
            new { MenuTitle = "报表管理" },
        };

        /// <summary>
        /// 初始化一个 VM实体 继承自 ViewModelBase MvvmLight框架基类
        /// </summary>
        public MainViewModel()
        {

        }
    }
}