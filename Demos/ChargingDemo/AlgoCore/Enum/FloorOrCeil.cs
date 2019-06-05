using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoCore.Enum
{
    public enum FloorOrCeil
    {
        /// <summary>
        /// 向下取整... 抽象到【北京】的收费规则 不停满60分钟不允许收费 必须停满61分钟才能收费
        /// </summary>
        Floor = 1,
        /// <summary>
        /// 向上取整... 抽象到【成都】的收费规则 不停满60分钟也要收费 按照 60 - cube.Tunit 进行计费
        /// </summary>
        Ceil
    }
}
