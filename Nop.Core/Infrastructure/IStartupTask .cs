using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Interface which should be implemented by tasks run on startup
    /// 接口，该接口应由在启动时运行的任务来实现
    /// </summary>
    public interface IStartupTask
    {
        /// <summary>
        /// Executes a task
        /// 执行一个任务
        /// </summary>
        void Execute();

        /// <summary>
        /// Gets order of this startup task implementation
        /// 获取此启动任务实现的顺序
        /// </summary>
        int Order { get; }
    }
}
