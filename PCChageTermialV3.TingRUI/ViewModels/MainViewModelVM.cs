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
        /* ��̬�������������ϵ ��ͳ�˵����� */
        public ObservableCollection<ModulizedBtn> AcceptModuels { get; set; } = new ObservableCollection<ModulizedBtn>();
        public ObservableCollection<ModualizedMenu> AcceptMenus { get; set; } = new ObservableCollection<ModualizedMenu>();

        /// <summary>
        /// ��ʼ��һ�� VMʵ�� �̳��� ViewModelBase MvvmLight��ܻ���
        /// </summary>
        public MainViewModelVM()
        {
            // һ���Գ�ʼ������UIģ��
            InitialAllFuckingModules();

            ChangeBgColorCMD = new RelayCommand<object>( Idx => 
            {
                Application.Current.MainWindow.Background = Brushes.AliceBlue;
            });

            LoadModuleCMD = new RelayCommand<PrettyModuel>(tokenParam =>
            {
                Random R = new Random();
                var result = R.Next(AcceptModuels.Count);
                MessageBox.Show(tokenParam.ToJson().IndentJson() + $"���������:|{result}|");
            });
        }

        private static string AutoImageSelector()
        {
            string JpgFile = string.Empty;
            JpgFile = PrettyModuel.isHoliday()?"MainBg3-Programer.Jpg":"MainBg2-TonyStark.JPG";
            var Resource_Dir_File = Path.Combine("~/".MapProjectPath(),$"/Resources/{JpgFile}");
            return Resource_Dir_File;
        }

        /* �����߲���������Ӳ˵�: ���2���Ӳ˵��󶨵�����Title����SubTitle�ֶ� */
        private void InitialMenuSubNodes()
        {
            // LINQ: �ڴ��ҳ���
            ModualizedMenu DockerLast = AcceptMenus.LastOrDefault();
            if (DockerLast == null) return;
            
            // �ֶ���� ��ҳ����ģ����Ҫ�õ���Model
            var range2Add = AcceptModuels.Where(o => o.gType == DockerLast.gTypeL1).ToList();
            DockerLast.MenuSublines.AddRange(range2Add);
        }

        /// <summary>
        /// һ���Գ�ʼ������UIģ��
        /// </summary>
        void InitialAllFuckingModules()
        {
            IEnumerable<ModulizedBtn> data = ModulizedBtn.FakeData();
            
            /* ��Ӷ�����***���л�������***���˵��� */
            foreach (var item in data)
                AcceptModuels.Add(item);
            
            var menus = ModualizedMenu.FakeData();
            for (int i = 0; i < menus.Count; i++)
            {
                // �ȰѲ˵���ӵ� UI
                AcceptMenus.Add(menus[i]);
                // �����2���ӽڵ� SubNodes
                InitialMenuSubNodes();
            }
        }

        public string AppInfo { get; set; } = string.Format("1.{0} App����ʼ��{1}",App.AppDescription, App.StartAt.ToLongDateString());
        public int SelectedIdxNo { get; set; } = 5;  // ����ʦ & ����ʦ
        public string TodaysBackImage { get; set; } = AutoImageSelector();

        #region  WPF�¼�ת����
        public RelayCommand<object> ChangeBgColorCMD { get; set; }

        // WPF��ť���TabControl�ؼ� ģ����ҳģ�����|�л� Ч��
        public RelayCommand<PrettyModuel> LoadModuleCMD { get; set; }
        #endregion
    }
}