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
    /// ＶＭ类的加载走静态内存段　由Mvvm框架静态管理器类ViewModelLocator 统一接管
    /// 新的VM应该注册为Locator类的一个成员属性 在构造方法中注册为IoC容器的孩子
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
            SimpleIoc.Default.Register<OrderCalculationV1VM>();
        }

        public MainViewModelVM Main => ServiceLocator.Current.GetInstance<MainViewModelVM>();
        public HardWareCtrlVM Hardware => ServiceLocator.Current.GetInstance<HardWareCtrlVM>();
        public OrderCalculationV1VM Engine => ServiceLocator.Current.GetInstance<OrderCalculationV1VM>();

        public static void Cleanup()
        {
            // 应该在这里清理内存 VM和VM绑定的数据源 以防止内存泄漏
        }
    }
}