using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoCore
{
    /// <summary>
    /// 停如意v3.0 PCv1.0版本所使用的时间管理器类
    /// 需要在开发阶段 划分 1.最小时间单元(分钟(时钟自转)) 2.最大时间单元(天(地球自转)) 3.虚拟中间单元(1H小时)
    ///     人类时间管理单元 存放一些常用算法 
    ///         例如 1.千禧年问题 2.新浪微博时间尾巴儿 3.中国农历 4.Unix转换当天时间 5.DateTime转Time(当日)
    ///         
    /// </summary>
    public class DKTimingUnit :DKTStd
    {
        #region  增加函数最好是以`扩展函数`的形式增强SDK 方便调用
        internal static DateTime ParseTime2DTime(int h, int m, int s)
        {
            // 检查Time返回值是否越界
            DateTime Today = DateTime.Today;
            DateTime cTime = new DateTime(Today.Year, Today.Month, Today.Day, h, m, s);
            if (cTime > Today.AddDays(1) || cTime <= Today)
            {
                throw new Exception(InfoWarning + ErrorReason[0x7e]);
            }
            return cTime;
        }
        #endregion

        // 1.任意进制转换算法

        // 2.幽闭空间质数生成器

        // 3.微积分与极坐标知识体系

        // 4.矩阵平方

        // 5.停如意错峰算法

        // 6.倒转阴阳

        // 7.LINQ: 算法的继承
    }
}
