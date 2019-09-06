using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Data;
using Nop.Core;
using Nop.Services.Logging;
using System.Runtime.ExceptionServices;
using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Common;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.FileProviders;
using Nop.Core.Domain.Security;
using System.Linq;
using Nop.Services.Media.RoxyFileman;
using Nop.Services.Common;
using Nop.Services.Installation;
using Nop.Services.Authentication;
using Nop.Services.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using MyNop.Web.FrameWork.Globalization;
using MyNop.Web.FrameWork.MVC.Routing;
using WebMarkupMin.AspNetCore2;

namespace MyNop.Web.FrameWork.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder
    /// 表示IApplicationBuilder的扩展
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure the application HTTP request pipeline
        /// 配置应用程序HTTP请求管道
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }

        /// <summary>
        /// Add exception handling
        /// 添加异常处理
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseNopExceptionHandler(this IApplicationBuilder application)
        {
            var nopConfig = EngineContext.Current.Resolve<NopConfig>();
            var hostingEnvironment = EngineContext.Current.Resolve<IHostingEnvironment>();
            var useDetailedExceptionPage = nopConfig.DisplayFullErrorStack || hostingEnvironment.IsDevelopment();
            if (useDetailedExceptionPage)
            {
                //get detailed exceptions for developing and testing purposes
                application.UseDeveloperExceptionPage();
            }
            else
            {
                //or use special exception handler
                application.UseExceptionHandler("/Error/Error");
            }

            //log errors
            application.UseExceptionHandler(handler =>
            {
                handler.Run(context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception == null)
                        return Task.CompletedTask;

                    try
                    {
                        //check whether database is installed
                        //检查是否安装了数据库
                        if (DataSettingsManager.DatabaseIsInstalled)
                        {
                            //get current customer
                            var currentCustomer = EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer;

                            //log error
                            EngineContext.Current.Resolve<ILogger>().Error(exception.Message, exception, currentCustomer);
                        }
                    }
                    finally
                    {
                        //rethrow the exception to show the error page
                        //重新抛出异常以显示错误页面
                        ExceptionDispatchInfo.Throw(exception);
                    }

                    return Task.CompletedTask;
                });
            });
        }

        /// <summary>
        /// Adds a special handler that checks for responses with the 404 status code that do not have a body
        /// 添加一个特殊处理程序，用于检查404状态代码中没有正文的响应
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UsePageNotFound(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(async context =>
            {
                //handle 404 Not Found
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                    if (!webHelper.IsStaticResource())
                    {
                        //get original path and query
                        //获取原始路径和查询
                        var originalPath = context.HttpContext.Request.Path;
                        var originalQueryString = context.HttpContext.Request.QueryString;

                        //store the original paths in special feature, so we can use it later
                        //将原始路径存储在special feature中，以便稍后使用
                        context.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(new StatusCodeReExecuteFeature
                        {
                            OriginalPathBase = context.HttpContext.Request.PathBase.Value,
                            OriginalPath = originalPath.Value,
                            OriginalQueryString = originalQueryString.HasValue ? originalQueryString.Value : null
                        });

                        //get new path
                        context.HttpContext.Request.Path = "/page-not-found";
                        context.HttpContext.Request.QueryString = QueryString.Empty;

                        try
                        {
                            //re-execute request with new path
                            //使用新路径重新执行请求
                            await context.Next(context.HttpContext);
                        }
                        finally
                        {
                            //return original path to request
                            //返回请求的原始路径
                            context.HttpContext.Request.QueryString = originalQueryString;
                            context.HttpContext.Request.Path = originalPath;
                            context.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(null);
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Adds a special handler that checks for responses with the 400 status code (bad request)
        /// 添加一个特殊的处理程序，用于检查带有400个状态码的响应(坏请求)
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseBadRequestResult(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(context =>
            {
                //handle 404 (Bad request)
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    var logger = EngineContext.Current.Resolve<ILogger>();
                    var workContext = EngineContext.Current.Resolve<IWorkContext>();
                    logger.Error("Error 400. Bad request", null, customer: workContext.CurrentCustomer);
                }

                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Configure middleware for dynamically compressing HTTP responses
        /// 为动态压缩HTTP响应配置中间件
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseNopResponseCompression(this IApplicationBuilder application)
        {
            //whether to use compression (gzip by default)
            //是否使用压缩(默认为gzip)
            if (DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<CommonSettings>().UseResponseCompression)
                application.UseResponseCompression();
        }

        /// <summary>
        /// Configure static file serving
        /// 配置静态文件服务
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseNopStaticFiles(this IApplicationBuilder application)
        {
            void staticFileResponse(StaticFileResponseContext context)
            {
                if (!DataSettingsManager.DatabaseIsInstalled)
                    return;

                var commonSettings = EngineContext.Current.Resolve<CommonSettings>();
                if (!string.IsNullOrEmpty(commonSettings.StaticFilesCacheControl))
                    context.Context.Response.Headers.Append(HeaderNames.CacheControl, commonSettings.StaticFilesCacheControl);
            }

            var fileProvider = EngineContext.Current.Resolve<INopFileProvider>();

            //common static files
            //常见的静态文件
            application.UseStaticFiles(new StaticFileOptions { OnPrepareResponse = staticFileResponse });

            //themes static files
            //主题静态文件
            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileProvider.MapPath(@"Themes")),
                RequestPath = new PathString("/Themes"),
                OnPrepareResponse = staticFileResponse
            });

            //plugins static files
            //插件静态文件
            var staticFileOptions = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileProvider.MapPath(@"Plugins")),
                RequestPath = new PathString("/Plugins"),
                OnPrepareResponse = staticFileResponse
            };

            if (DataSettingsManager.DatabaseIsInstalled)
            {
                var securitySettings = EngineContext.Current.Resolve<SecuritySettings>();
                if (!string.IsNullOrEmpty(securitySettings.PluginStaticFileExtensionsBlacklist))
                {
                    var fileExtensionContentTypeProvider = new FileExtensionContentTypeProvider();

                    foreach (var ext in securitySettings.PluginStaticFileExtensionsBlacklist
                        .Split(';', ',')
                        .Select(e => e.Trim().ToLower())
                        .Select(e => $"{(e.StartsWith(".") ? string.Empty : ".")}{e}")
                        .Where(fileExtensionContentTypeProvider.Mappings.ContainsKey))
                    {
                        fileExtensionContentTypeProvider.Mappings.Remove(ext);
                    }

                    staticFileOptions.ContentTypeProvider = fileExtensionContentTypeProvider;
                }
            }

            application.UseStaticFiles(staticFileOptions);

            //add support for backups
            //添加对备份的支持
            var provider = new FileExtensionContentTypeProvider
            {
                Mappings = { [".bak"] = MimeTypes.ApplicationOctetStream }
            };

            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileProvider.GetAbsolutePath("db_backups")),
                RequestPath = new PathString("/db_backups"),
                ContentTypeProvider = provider
            });

            //add support for webmanifest files
            //添加对webmanifest文件的支持
            provider.Mappings[".webmanifest"] = MimeTypes.ApplicationManifestJson;

            application.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileProvider.GetAbsolutePath("icons")),
                RequestPath = "/icons",
                ContentTypeProvider = provider
            });

            if (DataSettingsManager.DatabaseIsInstalled)
            {
                application.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new RoxyFilemanProvider(fileProvider.GetAbsolutePath(NopRoxyFilemanDefaults.DefaultRootDirectory.TrimStart('/').Split('/'))),
                    RequestPath = new PathString(NopRoxyFilemanDefaults.DefaultRootDirectory),
                    OnPrepareResponse = staticFileResponse
                });
            }
        }

        /// <summary>
        /// Configure middleware checking whether requested page is keep alive page
        /// 配置中间件，检查请求的页面是否保持活动页面
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseKeepAlive(this IApplicationBuilder application)
        {
            application.UseMiddleware<KeepAliveMiddleware>();
        }

        /// <summary>
        /// Configure middleware checking whether database is installed
        /// 配置中间件，检查是否安装了数据库
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseInstallUrl(this IApplicationBuilder application)
        {
            application.UseMiddleware<InstallUrlMiddleware>();
        }

        /// <summary>
        /// Adds the authentication middleware, which enables authentication capabilities.
        /// 添加身份验证中间件，该中间件支持身份验证功能
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseNopAuthentication(this IApplicationBuilder application)
        {
            //check whether database is installed
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            application.UseMiddleware<AuthenticationMiddleware>();
        }

        /// <summary>
        /// Configure the request localization feature
        /// 配置请求本地化特性
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseNopRequestLocalization(this IApplicationBuilder application)
        {
            application.UseRequestLocalization(options =>
            {
                if (!DataSettingsManager.DatabaseIsInstalled)
                    return;

                //prepare supported cultures
                //准备支持文化
                var cultures = EngineContext.Current.Resolve<ILanguageService>().GetAllLanguages()
                    .OrderBy(language => language.DisplayOrder)
                    .Select(language => new CultureInfo(language.LanguageCulture)).ToList();
                options.SupportedCultures = cultures;
                options.DefaultRequestCulture = new RequestCulture(cultures.FirstOrDefault());
            });
        }

        /// <summary>
        /// Set current culture info
        /// 设置当前文化信息
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseCulture(this IApplicationBuilder application)
        {
            //check whether database is installed
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            application.UseMiddleware<CultureMiddleware>();
        }

        /// <summary>
        /// Configure MVC routing
        /// MVC路由配置
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseNopMvc(this IApplicationBuilder application)
        {
            application.UseMvc(routeBuilder =>
            {
                //register all routes
                EngineContext.Current.Resolve<IRoutePublisher>().RegisterRoutes(routeBuilder);
            });
        }

        /// <summary>
        /// Configure WebMarkupMin
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseNopWebMarkupMin(this IApplicationBuilder application)
        {
            //check whether database is installed
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            application.UseWebMarkupMin();
        }
    }
}
