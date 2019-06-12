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

            SimpleIoc.Default.Register<MainViewModelVM>();
            SimpleIoc.Default.Register<HardWareCtrlVM>();
            SimpleIoc.Default.Register<ChargingEngineV1VM>();
        }

        public MainViewModelVM Main => ServiceLocator.Current.GetInstance<MainViewModelVM>();
        public HardWareCtrlVM Hardware => ServiceLocator.Current.GetInstance<HardWareCtrlVM>();
        public ChargingEngineV1VM Engine => ServiceLocator.Current.GetInstance<ChargingEngineV1VM>();

        public static void Cleanup()
        {
            // 应该在这里清理内存 VM和VM绑定的数据源 以防止内存泄漏
        }
    }
}