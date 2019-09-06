using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Tasks
{
    /// <summary>
    /// Schedule task
    /// 计划任务
    /// </summary>
    public partial class ScheduleTask : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the run period (in seconds)
        /// 获取或设置运行周期(以秒为单位)
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Gets or sets the type of appropriate IScheduleTask class
        /// 获取或设置适当的IScheduleTask类的类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether a task is enabled
        /// 获取或设置指示是否启用任务的值
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether a task should be stopped on some error
        /// 获取或设置一个值，该值指示是否应在发生错误时停止任务
        /// </summary>
        public bool StopOnError { get; set; }

        /// <summary>
        /// Gets or sets the datetime when it was started last time
        /// 获取或设置上次启动时的日期时间
        /// </summary>
        public DateTime? LastStartUtc { get; set; }

        /// <summary>
        /// Gets or sets the datetime when it was finished last time (no matter failed is success)
        /// 获取或设置上次完成时的日期时间(无论失败是否成功)
        /// </summary>
        public DateTime? LastEndUtc { get; set; }

        /// <summary>
        /// Gets or sets the datetime when it was successfully finished last time
        /// 获取或设置上次成功完成时的日期时间
        /// </summary>
        public DateTime? LastSuccessUtc { get; set; }
    }
}
