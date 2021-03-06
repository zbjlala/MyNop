﻿using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// Common settings
    /// 公共设置
    /// </summary>
    public class CommonSettings : ISettings
    {
        public CommonSettings()
        {
            IgnoreLogWordlist = new List<string>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the contacts form should have "Subject"
        /// 获取或设置一个值，该值指示联系人表单是否应该具有“Subject”
        /// </summary>
        public bool SubjectFieldOnContactUsForm { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the contacts form should use system email
        /// 获取或设置一个值，该值指示联系人表单是否应使用系统电子邮件
        /// </summary>
        public bool UseSystemEmailForContactUsForm { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use stored procedure (if supported) for loading categories (it's much faster in admin area with a large number of categories than the LINQ implementation)
        /// 获取或设置一个值，该值指示是否使用存储过程(如果受支持)加载类别(在包含大量类别的管理区域中，该值要比LINQ实现快得多)
        /// </summary>
        public bool UseStoredProcedureForLoadingCategories { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display a warning if java-script is disabled
        /// 获取或设置一个值，该值指示在禁用js脚本时是否显示警告
        /// </summary>
        public bool DisplayJavaScriptDisabledWarning { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether full-text search is supported
        /// 获取或设置一个值，该值指示是否支持全文本搜索
        /// </summary>
        public bool UseFullTextSearch { get; set; }

        /// <summary>
        /// Gets or sets a Full-Text search mode
        /// 获取或设置全文本搜索模式
        /// </summary>
        public FulltextSearchMode FullTextMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 404 errors (page or file not found) should be logged
        /// 获取或设置一个值，该值指示是否应记录404错误(未找到页或文件)
        /// </summary>
        public bool Log404Errors { get; set; }

        /// <summary>
        /// Gets or sets a breadcrumb delimiter used on the site
        /// 获取或设置站点上使用的面包屑分隔符
        /// </summary>
        public string BreadcrumbDelimiter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we should render <meta http-equiv="X-UA-Compatible" content="IE=edge"/> tag
        /// </summary>
        public bool RenderXuaCompatible { get; set; }

        /// <summary>
        /// Gets or sets a value of "X-UA-Compatible" META tag
        /// 获取或设置“x - ua兼容”元标记的值
        /// </summary>
        public string XuaCompatibleValue { get; set; }

        /// <summary>
        /// Gets or sets ignore words (phrases) to be ignored when logging errors/messages
        /// 获取或设置在记录错误/消息时忽略要忽略的单词(短语)
        /// </summary>
        public List<string> IgnoreLogWordlist { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether links generated by BBCode Editor should be opened in a new window
        /// 获取或设置一个值，该值指示BBCode编辑器生成的链接是否应在新窗口中打开
        /// </summary>
        public bool BbcodeEditorOpenLinksInNewWindow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "accept terms of service" links should be open in popup window. If disabled, then they'll be open on a new page.
        /// 获取或设置一个值，该值指示是否应在弹出窗口中打开“接受服务条款”链接。如果禁用，它们将打开一个新页面。
        /// </summary>
        public bool PopupForTermsOfServiceLinks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether jQuery migrate script logging is active
        /// 获取或设置一个值，该值指示jQuery迁移脚本日志记录是否活动
        /// </summary>
        public bool JqueryMigrateScriptLoggingActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we should support previous nopCommerce versions (it can slightly improve performance)
        /// 获取或设置一个值，该值指示是否应该支持以前的nopCommerce版本(它可以稍微提高性能)
        /// </summary>
        public bool SupportPreviousNopcommerceVersions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to compress response (gzip by default). 
        /// 获取或设置一个值，该值指示是否压缩响应(默认情况下为gzip)
        /// You may want to disable it, for example, If you have an active IIS Dynamic Compression Module configured at the server level
        /// </summary>
        public bool UseResponseCompression { get; set; }

        /// <summary>
        /// Gets or sets a value of "Cache-Control" header value for static content
        /// 获取或设置静态内容的“Cache-Control”标头值
        /// </summary>
        public string StaticFilesCacheControl { get; set; }

        /// <summary>
        /// Gets or sets a value of favicon and app icons <head/> code
        /// 获取或设置favicon和应用程序图标的值<head/> code
        /// </summary>
        public string FaviconAndAppIconsHeadCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable markup minification
        /// 获取或设置一个值，该值指示是否启用标记缩小
        /// </summary>
        public bool EnableHtmlMinification { get; set; }

        /// <summary>
        /// A value indicating whether JS file bundling and minification is enabled
        /// 一个值，指示是否启用JS文件绑定和缩小
        /// </summary>
        public bool EnableJsBundling { get; set; }

        /// <summary>
        /// A value indicating whether CSS file bundling and minification is enabled
        /// 一个值，指示是否启用CSS文件绑定和缩小
        /// </summary>
        public bool EnableCssBundling { get; set; }

        /// <summary>
        /// The length of time, in milliseconds, before the running schedule task times out. Set null to use default value
        /// 运行调度任务超时前的时间长度，以毫秒为单位。将null设置为使用默认值
        /// </summary>
        public int? ScheduleTaskRunTimeout { get; set; }
    }
}
