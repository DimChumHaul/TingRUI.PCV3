using AlgoCore;
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
    internal class DKScorpio
    {
        protected internal DateTime PivotLeft { get; set; } 
        protected internal DateTime PivotRight { get; set; }
        private Time AsDayTimeLeft { get => PivotLeft.ToTime(); }
        private Time AsDayTimeRight { get => PivotRight.ToTime(); }

        public DKScorpio(ref DateTime workingDTLeft,ref DateTime workingDTRight)
        {
            PivotLeft = workingDTLeft;
            PivotRight = workingDTRight;
        }

        /// <summary>
        /// 获取左右手位置的`当日时间`
        /// </summary>
        /// <returns>元组:(时间轴左边界应对的当日时间,时间轴应对的右边界当日时间)</returns>
        private (Time LeftDT2T,Time RightDT2T) DTAsTime()
        {
            var start = this.PivotLeft.ToTime();
            var end = this.PivotRight.ToTime();
            return (start, end);
        }
    }
}
