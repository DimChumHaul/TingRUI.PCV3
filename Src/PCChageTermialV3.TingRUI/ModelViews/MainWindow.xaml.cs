﻿using GalaSoft.MvvmLight.Threading;
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

            DispatcherHelper.Initialize();
        }
        private void LaunchMahAppsOnGitHub(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MahApps/MahApps.Metro");
        }
        private void LaunchIcons(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MahApps/MahApps.Metro.IconPacks");
        }
    }
}