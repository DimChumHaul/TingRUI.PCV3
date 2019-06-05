using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TingRUI.Data.JustEnum
{
    // By 丁诚昊 职业技能考核的6个等级 Level6Pro
    public enum Level6Pro
    {
        // ---- 滚蛋 ---- 
        菜鸟 = -32,
        知道 = 32,
        了解 = 8192,
        // ---- 打杂 ---- 
        熟练 = 65536,
        // ---- 扶摇直上 ---- 
        精通 = 1920*1080,
        // ---- 融会贯通 ~> 发明创造 ----
        修仙 = int.MaxValue
    }
}
