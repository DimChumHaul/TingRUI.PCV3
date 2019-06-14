/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PCChageTermialV3.TingRUI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using PCChageTermialV3.TingRUI.ViewModels;

namespace PCChageTermialV3.TingRUI.ViewModel
{
    /// <summary>
    /// �֣���ļ����߾�̬�ڴ�Ρ���Mvvm��ܾ�̬��������ViewModelLocator ͳһ�ӹ�
    /// �µ�VMӦ��ע��ΪLocator���һ����Ա���� �ڹ��췽����ע��ΪIoC�����ĺ���
    /// </summary>
    internal class ViewModelLocator
    {
        /// <summary>
        /// ��ʼ��IoC������ ViewModelLocator 
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModelVM>();
            SimpleIoc.Default.Register<HardWareCtrlVM>();
            SimpleIoc.Default.Register<OrderCalculationV1VM>();
        }

        public MainViewModelVM Main => ServiceLocator.Current.GetInstance<MainViewModelVM>();
        public HardWareCtrlVM Hardware => ServiceLocator.Current.GetInstance<HardWareCtrlVM>();
        public OrderCalculationV1VM Engine => ServiceLocator.Current.GetInstance<OrderCalculationV1VM>();

        public static void Cleanup()
        {
            // Ӧ�������������ڴ� VM��VM�󶨵�����Դ �Է�ֹ�ڴ�й©
        }
    }
}