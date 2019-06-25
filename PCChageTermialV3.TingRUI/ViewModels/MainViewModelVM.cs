using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using ServiceStack;
using System;
using System.Windows;
using System.Windows.Media;
using TingRUI.Data.Models.DataTemplate;
using TingRUI.Data.JustEnum;
using System.Collections.Generic;
using ServiceStack.Text;
using System.Windows.Controls;

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
    internal class MainViewModelVM :ViewModelBase
    {
        /* 动态配置主界面左边系 【统菜单栏】 */
        public ObservableCollection<ModulizedBtn> AcceptModuels { get; set; } = new ObservableCollection<ModulizedBtn>();
        public ObservableCollection<ModualizedMenu> AcceptMenus { get; set; } = new ObservableCollection<ModualizedMenu>();

        /// <summary>
        /// 初始化一个 VM实体 继承自 ViewModelBase MvvmLight框架基类
        /// </summary>
        public MainViewModelVM()
        {
            // 一次性初始化所有UI模块
            InitialAllFuckingModules();

            ChangeBgColorCMD = new RelayCommand<object>( Idx => 
            {
                Application.Current.MainWindow.Background = Brushes.AliceBlue;
            });

            LoadModuleCMD = new RelayCommand<PrettyModuel>(tokenParam =>
            {
                Random R = new Random();
                var result = R.Next(AcceptModuels.Count);
                MessageBox.Show(tokenParam.ToJson().IndentJson() + $"随机到索引:|{result}|");
            });
        }

        private static string AutoImageSelector()
        {
            string JpgFile = string.Empty;
            JpgFile = PrettyModuel.isHoliday()?"MainBg3-Programer.Jpg":"MainBg2-TonyStark.JPG";
            var Resource_Dir_File = Path.Combine("~/".MapProjectPath(),$"/Resources/{JpgFile}");
            return Resource_Dir_File;
        }

        /* 添加左边侧边栏下拉子菜单: 添加2级子菜单绑定到子类Title或者SubTitle字段 */
        private void InitialMenuSubNodes()
        {
            // LINQ: 内存分页添加
            ModualizedMenu DockerLast = AcceptMenus.LastOrDefault();
            if (DockerLast == null) return;
            
            // 手动添加 首页顶部模块需要用到的Model
            var range2Add = AcceptModuels.Where(o => o.gType == DockerLast.gTypeL1).ToList();
            DockerLast.MenuSublines.AddRange(range2Add);
        }

        /// <summary>
        /// 一次性初始化所有UI模块
        /// </summary>
        void InitialAllFuckingModules()
        {
            IEnumerable<ModulizedBtn> data = ModulizedBtn.FakeData();
            
            /* 添加顶部【***所有基础功能***】菜单栏 */
            foreach (var item in data)
                AcceptModuels.Add(item);
            
            var menus = ModualizedMenu.FakeData();
            for (int i = 0; i < menus.Count; i++)
            {
                // 先把菜单添加到 UI
                AcceptMenus.Add(menus[i]);
                // 再添加2级子节点 SubNodes
                InitialMenuSubNodes();
            }
        }

        public string AppInfo { get; set; } = string.Format("1.{0} App开发始于{1}",App.AppDescription, App.StartAt.ToLongDateString());
        public int SelectedIdxNo { get; set; } = 5;  // 夏老师 & 丁老师
        public string TodaysBackImage { get; set; } = AutoImageSelector();

        #region  WPF事件转命令
        public RelayCommand<object> ChangeBgColorCMD { get; set; }

        // WPF按钮配合TabControl控件 模拟首页模块加载|切换 效果
        public RelayCommand<PrettyModuel> LoadModuleCMD { get; set; }
        #endregion
    }
}