using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TingRUI.Data.JustEnum
{
    // By 丁诚昊 职业技能考核 Pro6Level
    public enum Level6Pro
    {
        // ---- 滚蛋 ---- 
        菜鸟 = -32, 知道 = 32, 了解 = 8192,
        // ---- 打杂 ---- 
        熟练 = 65536,
        // ---- 扶摇直上 ---- 
        精通 = 1920*1080,
        // ---- 融会贯通 | 发明创造 ----
        修仙 = int.MaxValue
    }

    // 丁诚昊 六级人才分割理论
    public enum NormalPeople
    {
        // ---- 滚蛋 ---- 
        废才,庸才,人才,
        // ---- 哈哈 ----
        // 巧言令色 恩威并用 收揽人心 为我所用 发现了第一个真正的`将才`
        将才,
        天才 = 1027 * 768,
        众神之王 
    }
}
