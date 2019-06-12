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
        /// 初始化IoC容器类 ViewModelLocator 
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // 注入类型到IoC容器 首页VM-ViewModel
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
            // 应该在这里清理内存 VM和VM绑定的数据源 以防止内存泄漏
        }
    }
}