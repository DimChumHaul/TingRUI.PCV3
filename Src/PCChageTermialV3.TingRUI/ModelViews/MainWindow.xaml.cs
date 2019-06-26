using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro.Controls;
using PCChageTermialV3.TingRUI.ViewModel;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCChageTermialV3.TingRUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // 观察者模式一定要注意的地方 - 页面清理的时候要**手动管理CLR内存**
            this.Loaded += (sender, e) =>
            {
                // 初始化首页[顶部模组]
                LoadBasicUI();

                // 注册MVVMLight消息机订阅模式 上层模式：观察者 底层模式:static函数指针区插值
                Messenger.Default.Register<string>(this, "TopViewTokenAction", BtnSelectedChange);
            };

            this.Unloaded += (sender, e) => {
                // 卸载当前(this)对象注册的所有MVVMLight消息
                Messenger.Default.Unregister(this);
            };
        }

        #region 这一段要拿到MV模型视图中去处理
        private void BtnSelectedChange(string Token)
        {
            UserSelectingIndex = Convert.ToInt32(Token);

            if (string.IsNullOrEmpty(Token)) throw new ArgumentOutOfRangeException("MvvmLight消息机Token非法~");
            /*
            * MVVM Light Messenger 
            * 旨在通过简单的设计模式来精简此场景：任何对象都可以是接收端；
            * 任何对象都可以是发送端；任何对象都可以是消息 
            */
            {
                string originTitle = this.Title;
                this.Title = Token.ToJson();
                // MessageBox.Show($"MVVM Light Messenger - 用户选中TabItem:|{UserSelectingIndex}|");
                this.Title = originTitle;
                TopView.SelectedIndex = UserSelectingIndex;
            }
        }
        #endregion

        private void LoadBasicUI()
        {
            // 1.找到应该加载的 首页TopView 索引数
            UserSelectingIndex = 3;

            // 2.异步|同步 ...加载页面... 
        }

        private void LaunchMahAppsOnGitHub(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MahApps/MahApps.Metro");
        }
        private void LaunchIcons(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MahApps/MahApps.Metro.IconPacks");
        }

        private int UserSelectingIndex { get; set; }
    }
}
