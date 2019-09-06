using Microsoft.Extensions.DependencyInjection;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Tasks;
using Nop.Core.Http;
using Nop.Core.Infrastructure;
using Nop.Services.Localization;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nop.Services.Tasks
{
    /// <summary>
    /// Represents task thread
    /// 代表任务线程
    /// </summary>
    public partial class TaskThread : IDisposable
    {
        #region Fields

        private static readonly string _scheduleTaskUrl;
        private static readonly int? _timeout;

        private readonly Dictionary<string, string> _tasks;
        private Timer _timer;
        private bool _disposed;

        #endregion

        #region Ctor

        static TaskThread()
        {
            _scheduleTaskUrl = $"{EngineContext.Current.Resolve<IStoreContext>().CurrentStore.Url}{NopTaskDefaults.ScheduleTaskPath}";
            _timeout = EngineContext.Current.Resolve<CommonSettings>().ScheduleTaskRunTimeout;
        }

        internal TaskThread()
        {
            _tasks = new Dictionary<string, string>();
            Seconds = 10 * 60;
        }

        #endregion

        #region Utilities

        private void Run()
        {
            if (Seconds <= 0)
                return;

            StartedUtc = DateTime.UtcNow;
            IsRunning = true;

            foreach (var taskName in _tasks.Keys)
            {
                var taskType = _tasks[taskName];
                try
                {
                    //create and configure client
                    var client = EngineContext.Current.Resolve<IHttpClientFactory>().CreateClient(NopHttpDefaults.DefaultHttpClient);
                    if (_timeout.HasValue)
                        client.Timeout = TimeSpan.FromMilliseconds(_timeout.Value);

                    //send post data
                    var data = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>(nameof(taskType), taskType) });
                    client.PostAsync(_scheduleTaskUrl, data).Wait();
                }
                catch (Exception ex)
                {
                    var _serviceScopeFactory = EngineContext.Current.Resolve<IServiceScopeFactory>();
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        // Resolve
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                        var localizationService = scope.ServiceProvider.GetRequiredService<ILocalizationService>();
                        var storeContext = scope.ServiceProvider.GetRequiredService<IStoreContext>();

                        var message = ex.InnerException?.GetType() == typeof(TaskCanceledException) ? localizationService.GetResource("ScheduleTasks.TimeoutError") : ex.Message;

                        message = string.Format(localizationService.GetResource("ScheduleTasks.Error"), taskName,
                            message, taskType, storeContext.CurrentStore.Name, _scheduleTaskUrl);

                        logger.Error(message, ex);
                    }
                }
            }

            IsRunning = false;
        }

        private void TimerHandler(object state)
        {
            try
            {
                _timer.Change(-1, -1);
                Run();

                if (RunOnlyOnce)
                    Dispose();
                else
                    _timer.Change(Interval, Interval);
            }
            catch
            {
                // ignore
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Disposes the instance
        /// 处理实例
        /// </summary>
        public void Dispose()
        {
            if (_timer == null || _disposed)
                return;

            lock (this)
            {
                _timer.Dispose();
                _timer = null;
                _disposed = true;
            }
        }

        /// <summary>
        /// Inits a timer
        /// 初始化一个计时器
        /// </summary>
        public void InitTimer()
        {
            if (_timer == null)
                _timer = new Timer(TimerHandler, null, InitInterval, Interval);
        }

        /// <summary>
        /// Adds a task to the thread
        /// 向线程添加任务
        /// </summary>
        /// <param name="task">The task to be added</param>
        public void AddTask(ScheduleTask task)
        {
            if (!_tasks.ContainsKey(task.Name))
                _tasks.Add(task.Name, task.Type);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the interval in seconds at which to run the tasks
        /// 获取或设置运行任务的间隔(以秒为单位)
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Get or set the interval before timer first start 
        /// 获取或设置计时器首次启动前的间隔
        /// </summary>
        public int InitSeconds { get; set; }

        /// <summary>
        /// Get or sets a datetime when thread has been started
        /// 获取或设置线程启动时的日期时间
        /// </summary>
        public DateTime StartedUtc { get; private set; }

        /// <summary>
        /// Get or sets a value indicating whether thread is running
        /// 获取或设置一个值，该值指示线程是否正在运行
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Gets the interval (in milliseconds) at which to run the task
        /// 获取运行任务的间隔(以毫秒为单位)
        /// </summary>
        public int Interval
        {
            get
            {
                //if somebody entered more than "2147483" seconds, then an exception could be thrown (exceeds int.MaxValue)
                var interval = Seconds * 1000;
                if (interval <= 0)
                    interval = int.MaxValue;
                return interval;
            }
        }

        /// <summary>
        /// Gets the due time interval (in milliseconds) at which to begin start the task
        /// 获取开始启动任务的适当时间间隔(以毫秒为单位)
        /// </summary>
        public int InitInterval
        {
            get
            {
                //if somebody entered less than "0" seconds, then an exception could be thrown
                var interval = InitSeconds * 1000;
                if (interval <= 0)
                    interval = 0;
                return interval;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the thread would be run only once (on application start)
        /// 获取或设置一个值，该值指示线程是否只运行一次(在应用程序启动时)
        /// </summary>
        public bool RunOnlyOnce { get; set; }

        #endregion
    }
}
