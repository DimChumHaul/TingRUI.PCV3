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
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    internal class ViewModelLocator
    {
        /// <summary>
        /// ��ʼ��IoC������ ViewModelLocator 
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // ע�����͵�IoC���� ��ҳVM-ViewModel
            SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<ParkingInfoVM>();
            //SimpleIoc.Default.Register<CacheInfoVM>();
            SimpleIoc.Default.Register<HardWareCtrlVM>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        //public ParkingInfoVM SettingVM => ServiceLocator.Current.GetInstance<ParkingInfoVM>();
        //public CacheInfoVM CacheVM => ServiceLocator.Current.GetInstance<CacheInfoVM>();
        public HardWareCtrlVM HardwareVM => ServiceLocator.Current.GetInstance<HardWareCtrlVM>();

        public static void Cleanup()
        {
            // Ӧ�������������ڴ� VM��VM�󶨵�����Դ �Է�ֹ�ڴ�й©
        }
    }
}