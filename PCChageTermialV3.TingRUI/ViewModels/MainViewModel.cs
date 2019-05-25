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
            "1.{0} App����ʼ��{1}",  App.AppDescription, App.StartAt.ToLongDateString()
        );

        public ObservableCollection<FuncBtnModel> AcceptModuels { get; set; }

        /* ��̬�������������ϵ ��ͳ�˵����� */
        public ObservableCollection<FuncMenuModel> AcceptMenus { get; set; } = new ObservableCollection<FuncMenuModel>();

        /// <summary>
        /// ��ʼ��һ�� VMʵ�� �̳��� ViewModelBase MvvmLight��ܻ���
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
            // ��ʼ�����ܰ�ť �����ö�ȡ֧�ֵĹ��ܰ�ť
            Initial_App_Moduels();
        }
    }
}