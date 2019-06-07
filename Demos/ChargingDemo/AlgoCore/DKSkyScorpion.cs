﻿using AlgoCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgoCore.DKStd;

namespace AlgoCore
{
    /// <summary>
    /// Scorpio : 天蝎座♏ 不停地挥动两只钳子 对时间轴的左右两界做切割和计费处理 
    /// 当你你可以换一种抽象方式: 大众汽车作业流水线上的`机械摇臂`
    /// </summary>
    internal class DKSkyScorpion
    {
        public decimal? TotalResult { get; protected internal set; } = -.0m;
        /* 尾巴儿容器 参数列表 1.计费单元 2.计费规则 3.单元价格 */
        public List<(Time Mtu1,Time Mtu2, decimal? unitPrice, bool? discount)> Tail { get; set; }

        protected internal DateTime PivotLeft { get; set ; } 
        protected internal DateTime PivotRight { get; set; }

        public DKSkyScorpion(DateTime workingDTLeft,DateTime workingDTRight)
        {
            PivotLeft = workingDTLeft;
            PivotRight = workingDTRight;

            /* 1-0.启动三重作业引擎: 蝎子 + 盒子 * 矩阵平方 * 尾巴儿 */
            TotalResult = -.0m;
            // 1-1.初始化 作业引擎【时间切片儿】容器 - Init
            Tail = new List<ValueTuple<Time,Time, decimal?, bool?>> { };
        }
    }
}
