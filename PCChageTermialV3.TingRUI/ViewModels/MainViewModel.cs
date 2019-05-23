using GalaSoft.MvvmLight;
using System.Collections.Generic;

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
            "1.{0} App����ʼ��{1}",
            App.AppDescription, App.StartAt.ToLongDateString()
        );

        /* ��̬���������涥��������Ա����ģ�顿 */
        public IEnumerable<object> AcceptModuels { get; set; } = new List<dynamic> {
                new { Name = "�շ�����" },
                new { Name = "��������" },
                new { Name = "��������" },
                new { Name = "���Ź���" },
                new { Name = "�û�����" },
                new { Name = "��������" },
                new { Name = "����Ա����" },
                new { Name = "ʵʱ���" },
                new { Name = "���ݿⱸ��" },
                new { Name = "���ݿ⻹ԭ" },
                new { Name = "���µ�½" },
                new { Name = "�Ƴ�ϵͳ" },
            };
        /* ��̬�������������ϵ ��ͳ�˵����� */
        public IEnumerable<object> AcceptMenus { get; set; } = new List<dynamic>
        {
            new { MenuTitle = "ϵͳ����" },
            new { MenuTitle = "�û�����" },
            new { MenuTitle = "��������" },
            new { MenuTitle = "ʵʱ���" },
            new { MenuTitle = "�������" },
        };

        /// <summary>
        /// ��ʼ��һ�� VMʵ�� �̳��� ViewModelBase MvvmLight��ܻ���
        /// </summary>
        public MainViewModel()
        {

        }
    }
}