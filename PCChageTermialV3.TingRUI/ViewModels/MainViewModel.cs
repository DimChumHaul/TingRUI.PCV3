using GalaSoft.MvvmLight;
using Offline.Data.TingRUI.Models.DataTemplate;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            "1.{0} App开发始于{1}",  App.AppDescription, App.StartAt.ToLongDateString()
        );

        public ObservableCollection<FuncBtnModel> AcceptModuels { get; set; }

        /* 动态配置主界面左边系 【统菜单栏】 */
        public ObservableCollection<FuncMenuModel> AcceptMenus { get; set; } = new ObservableCollection<FuncMenuModel>();

        /// <summary>
        /// 初始化一个 VM实体 继承自 ViewModelBase MvvmLight框架基类
        /// </summary>
        public MainViewModel()
        {
            int Initial_App_Moduels()
            {
                AcceptModuels = new ObservableCollection<FuncBtnModel>();
                var data = FuncBtnModel.FakeData();
                data.ToList().ForEach(item => AcceptModuels.Add(item));
                var menus = FuncMenuModel.FakeData();
                menus.ToList().ForEach(item => AcceptMenus.Add(item));
                return AcceptModuels.Count + AcceptMenus.Count;
            }
            // 初始化功能按钮 从配置读取支持的功能按钮
            Initial_App_Moduels();
        }
    }
}