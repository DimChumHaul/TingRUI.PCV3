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
        public string AppInfo { get; set; } = string.Format("1.{0} App开发始于{1}",
            App.AppDescription,
            App.StartAt.ToLongDateString()
        );

        public string TodaysBackImage { get; } = AutoImageSelector();

        public ObservableCollection<ModulizedBtn> AcceptModuels { get; set; }

        /* 动态配置主界面左边系 【统菜单栏】 */
        public ObservableCollection<ModualizedMenu> AcceptMenus { get; set; }
            = new ObservableCollection<ModualizedMenu>();

        /// <summary>
        /// 初始化一个 VM实体 继承自 ViewModelBase MvvmLight框架基类
        /// </summary>
        public MainViewModel()
        {
            int Initial_App_Moduels()
            {
                // 添加首页顶部菜单栏
                AcceptModuels = new ObservableCollection<ModulizedBtn>();
                var data = ModulizedBtn.FakeData();

                data.ToList().ForEach(item => AcceptModuels.Add(item));


                // 添加左边侧边栏下拉子菜单
                var menus = ModualizedMenu.FakeData();
                menus.ToList().ForEach( item => {
                    // 添加1级主菜单 绑定到Title字段作为标题
                    AcceptMenus.Add(item);

                    Int32 NodeToValue = (Int32)item.NodeTag;

                    // 添加2级子菜单 绑定到子类Title或者SubTitle字段
                    for (int i = 0; i < (Int32)(item.NodeTag); i++)
                    {
                        Int32 lastIndex = -1;
                        item.MenuSublines.AddRange(AcceptModuels.Skip(lastIndex).Take(NodeToValue - lastIndex));
                    }
                });
                return AcceptModuels.Count + AcceptMenus.Count;
            }

            // 初始化功能按钮 从配置读取支持的功能按钮
            Initial_App_Moduels();

            FuncModuleCMD = new RelayCommand(() =>
            {
                MessageBox.Show("测试【事件转命令】成功...");
            });

            ChangeBgColorCMD = new RelayCommand<Object>( Idx => {
                App.Current.MainWindow.Background = Brushes.Yellow;
            });
        }

        private static string AutoImageSelector()
        {
            var JpgFile = string.Empty;
            DayOfWeek NowDay = DateTime.Now.DayOfWeek;
            switch (NowDay)
            {
                case DayOfWeek.Friday:
                case DayOfWeek.Monday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                    JpgFile = "MainBg3-Programer.Jpg";
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                default:
                    JpgFile = "MainBg2-TonyStark.JPG";
                    break;
            }

            var Resource_Dir_File = Path.Combine("~/".MapProjectPath(),$"/Resources/{JpgFile}");
            return Resource_Dir_File;
        }

        #region  WPF事件转命令
        public RelayCommand FuncModuleCMD { get; set; }
        public RelayCommand<Object> ChangeBgColorCMD { get; set; }
        #endregion
    }
}