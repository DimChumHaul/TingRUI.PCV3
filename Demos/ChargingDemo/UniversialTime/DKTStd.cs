using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingDemo.UniversialTime
{
    public class DKTStd
    {
        public const string InfoWarning = "时间管理器警告 : ";

        protected static IDictionary<byte, string> ErrorReason = new Dictionary<byte, string>
        {
            { 0x7e,"内核异常.WarningReason : 时间轴越界" },
        };
    }
}
