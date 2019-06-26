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

            // 根据顶部模组 初始化首页
            LoadBasicUI();
        }
        private void LoadBasicUI()
        {
            // 1.找到应该加载的 首页TopView 索引数
            TopViewSelectingIndex = 3;

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

        private uint TopViewSelectingIndex = 0;
    }
}
