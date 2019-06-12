using GalaSoft.MvvmLight;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCChageTermialV3.TingRUI.ViewModels
{
    internal class HardWareCtrlVM :ViewModelBase
    {
        // 要被 ServiceLocator捕获 必须要有一个无参构造方法
        public HardWareCtrlVM()
        {
            "硬件方案确定给 集成到成都【臻识科技】1.高速摄像机 2.道闸 3.地感 4.费显屏幕".PrintDump();
        }
    }
}
