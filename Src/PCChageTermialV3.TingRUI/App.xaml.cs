using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PCChageTermialV3.TingRUI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public const string AppDescription = "停如意PC端收费终端 运行在各大停车场岗亭内部 版本v3.0.0.0";
        public static readonly DateTime StartAt = DateTime.Parse("2019-05-23");
    }
}
