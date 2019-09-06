using Nop.Core.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Tasks
{
    /// <summary>
    /// Task service interface
    /// 任务服务接口
    /// </summary>
    public partial interface IScheduleTaskService
    {
        /// <summary>
        /// Deletes a task
        /// 删除一个任务
        /// </summary>
        /// <param name="task">Task</param>
        void DeleteTask(ScheduleTask task);

        /// <summary>
        /// Gets a task
        /// 得到一个任务
        /// </summary>
        /// <param name="taskId">Task identifier</param>
        /// <returns>Task</returns>
        ScheduleTask GetTaskById(int taskId);

        /// <summary>
        /// Gets a task by its type
        /// 按任务类型获取任务
        /// </summary>
        /// <param name="type">Task type</param>
        /// <returns>Task</returns>
        ScheduleTask GetTaskByType(string type);

        /// <summary>
        /// Gets all tasks
        /// 得到所有任务
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Tasks</returns>
        IList<ScheduleTask> GetAllTasks(bool showHidden = false);

        /// <summary>
        /// Inserts a task
        /// 插入一个任务
        /// </summary>
        /// <param name="task">Task</param>
        void InsertTask(ScheduleTask task);

        /// <summary>
        /// Updates the task
        /// 更新任务
        /// </summary>
        /// <param name="task">Task</param>
        void UpdateTask(ScheduleTask task);
    }
}
