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
        public string AppInfo { get; set; } = string.Format("1.{0} App����ʼ��{1}",
            App.AppDescription,
            App.StartAt.ToLongDateString()
        );

        public string TodaysBackImage { get; } = AutoImageSelector();

        public ObservableCollection<ModulizedBtn> AcceptModuels { get; set; }

        /* ��̬�������������ϵ ��ͳ�˵����� */
        public ObservableCollection<ModualizedMenu> AcceptMenus { get; set; }
            = new ObservableCollection<ModualizedMenu>();

        /// <summary>
        /// ��ʼ��һ�� VMʵ�� �̳��� ViewModelBase MvvmLight��ܻ���
        /// </summary>
        public MainViewModel()
        {
            int Initial_App_Moduels()
            {
                // �����ҳ�����˵���
                AcceptModuels = new ObservableCollection<ModulizedBtn>();
                var data = ModulizedBtn.FakeData();

                data.ToList().ForEach(item => AcceptModuels.Add(item));


                // �����߲���������Ӳ˵�
                var menus = ModualizedMenu.FakeData();
                menus.ToList().ForEach( item => {
                    // ���1�����˵� �󶨵�Title�ֶ���Ϊ����
                    AcceptMenus.Add(item);

                    Int32 NodeToValue = (Int32)item.NodeTag;

                    // ���2���Ӳ˵� �󶨵�����Title����SubTitle�ֶ�
                    for (int i = 0; i < (Int32)(item.NodeTag); i++)
                    {
                        Int32 lastIndex = -1;
                        item.MenuSublines.AddRange(AcceptModuels.Skip(lastIndex).Take(NodeToValue - lastIndex));
                    }
                });
                return AcceptModuels.Count + AcceptMenus.Count;
            }

            // ��ʼ�����ܰ�ť �����ö�ȡ֧�ֵĹ��ܰ�ť
            Initial_App_Moduels();

            FuncModuleCMD = new RelayCommand(() =>
            {
                MessageBox.Show("���ԡ��¼�ת����ɹ�...");
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

        #region  WPF�¼�ת����
        public RelayCommand FuncModuleCMD { get; set; }
        public RelayCommand<Object> ChangeBgColorCMD { get; set; }
        #endregion
    }
}