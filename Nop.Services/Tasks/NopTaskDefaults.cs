using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Tasks
{
    /// <summary>
    /// Represents default values related to task services
    /// 表示与任务服务相关的默认值
    /// </summary>
    public static partial class NopTaskDefaults
    {
        /// <summary>
        /// Gets a running schedule task path
        /// 获取正在运行的调度任务路径
        /// </summary>
        public static string ScheduleTaskPath => "scheduletask/runtask";
    }
}
