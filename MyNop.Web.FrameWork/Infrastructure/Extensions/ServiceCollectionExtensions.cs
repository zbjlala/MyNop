using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNop.Web.FrameWork.MVC.ModelBinding;
using MyNop.Web.FrameWork.MVC.Routing;
using MyNop.Web.FrameWork.Themes;
using Newtonsoft.Json.Serialization;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Domain.Security;
using Nop.Core.Http;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Services.Authentication;
using Nop.Services.External;
using Nop.Services.Logging;
using Nop.Services.Plugins;
using Nop.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MyNop.Web.FrameWork.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// 代表Iservices Collection的扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            //most of API providers require TLS 1.2 nowadays
            //目前，大多数API提供商都需要TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //add NopConfig configuration parameters
            //添加nopconfig配置参数
            var nopConfig = services.ConfigureStartupConfig<NopConfig>
                (configuration.GetSection("Nop"));

            //添加主机配置参数
            services.ConfigureStartupConfig<HostingConfig>(configuration.GetSection("Hosting"));
            //add accessor to HttpContext
            //附加到httpconxt
            services.AddHttpContextAccessor();

            //create default file provider
            //创建默认文件提供程序
            CommonHelper.DefaultFileProvider = new NopFileProvider(hostingEnvironment);

            //initialize plugins
            //初始化插件
            var mvcCoreBuilder = services.AddMvcCore();
            mvcCoreBuilder.PartManager.InitializePlugins(nopConfig);

            //create engine and configure service provider
            //创建引擎并配置服务提供者
            var engine = EngineContext.Create();
            var serviceProvider = engine.ConfigureServices(services, configuration, nopConfig);

            //further actions are performed only when the database is installed
            //只有在安装数据库时才会执行进一步的操作
            if (!DataSettingsManager.DatabaseIsInstalled)
                return serviceProvider;

            //initialize and start schedule tasks
            //初始化并开始计划任务
            TaskManager.Instance.Initialize();
            TaskManager.Instance.Start();

            //log application start
            //日志应用程序开始
            engine.Resolve<ILogger>().Information("Application started");

            //install plugins
            //安装插件
            engine.Resolve<IPluginService>().InstallPlugins();

            return serviceProvider;
        }
        /// <summary>
        /// 创建、绑定和注册指定的配置参数作为服务
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if(configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            //创建配置实例
            var config = new TConfig();

            //将其绑定到配置的适当部分
            configuration.Bind(config);

            //并将其注册为服务
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Adds services required for anti-forgery support
        /// 添加反伪造支持所需的服务
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddAntiForgery(this IServiceCollection services)
        {
            //override cookie name
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.AntiforgeryCookie}";

                //whether to allow the use of anti-forgery cookies from SSL protected page on the other store pages which are not
                //是否允许在没有SSL保护的其他存储页上使用来自SSL保护页的反伪造cookie
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });
        }

        /// <summary>
        /// Adds services required for application session state
        /// 添加应用程序会话状态所需的服务
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.SessionCookie}";
                options.Cookie.HttpOnly = true;

                //whether to allow the use of session values from SSL protected page on the other store pages which are not
                //是否允许在其他不受SSL保护的存储页上使用SSL保护页中的会话值
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });
        }

        /// <summary>
        /// Adds services required for themes support
        /// 添加主题支持所需的服务
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddThemes(this IServiceCollection services)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            //themes support
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ThemeableViewLocationExpander());
            });
        }

        ///// <summary>
        ///// Adds data protection services
        ///// 增加数据保护服务
        ///// </summary>
        ///// <param name="services">Collection of service descriptors</param>
        //public static void AddNopDataProtection(this IServiceCollection services)
        //{
        //    //check whether to persist data protection in Redis
        //    //检查是否在Redis中保存数据保护
        //    var nopConfig = services.BuildServiceProvider().GetRequiredService<NopConfig>();
        //    if (nopConfig.RedisEnabled && nopConfig.UseRedisToStoreDataProtectionKeys)
        //    {
        //        //store keys in Redis
        //        //使用Redis存储密钥
        //        services.AddDataProtection().PersistKeysToRedis(() =>
        //        {
        //            var redisConnectionWrapper = EngineContext.Current.Resolve<IRedisConnectionWrapper>();
        //            return redisConnectionWrapper.GetDatabase(nopConfig.RedisDatabaseId ?? (int)RedisDatabaseNumber.DataProtectionKeys);
        //        }, NopCachingDefaults.RedisDataProtectionKey);
        //    }
        //    else
        //    {
        //        var dataProtectionKeysPath = CommonHelper.DefaultFileProvider.MapPath("~/App_Data/DataProtectionKeys");
        //        var dataProtectionKeysFolder = new System.IO.DirectoryInfo(dataProtectionKeysPath);

        //        //configure the data protection system to persist keys to the specified directory
        //        services.AddDataProtection().PersistKeysToFileSystem(dataProtectionKeysFolder);
        //    }
        //}

        /// <summary>
        /// Adds authentication service
        /// 添加身份验证服务
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddNopAuthentication(this IServiceCollection services)
        {
            //set default authentication schemes
            var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = NopAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = NopAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = NopAuthenticationDefaults.ExternalAuthenticationScheme;
            });

            //add main cookie authentication
            //添加主cookie身份验证
            authenticationBuilder.AddCookie(NopAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.AuthenticationCookie}";
                options.Cookie.HttpOnly = true;
                options.LoginPath = NopAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = NopAuthenticationDefaults.AccessDeniedPath;

                //whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                //是否允许在其他不受SSL保护的存储页上使用来自SSL保护页的身份验证cookie
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });

            //add external authentication
            //添加外部验证
            authenticationBuilder.AddCookie(NopAuthenticationDefaults.ExternalAuthenticationScheme, options =>
            {
                options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.ExternalAuthenticationCookie}";
                options.Cookie.HttpOnly = true;
                options.LoginPath = NopAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = NopAuthenticationDefaults.AccessDeniedPath;

                //whether to allow the use of authentication cookies from SSL protected page on the other store pages which are not
                options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                    ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
            });

            //register and configure external authentication plugins now
            //现在注册并配置外部身份验证插件
            var typeFinder = new WebAppTypeFinder();
            var externalAuthConfigurations = typeFinder.FindClassesOfType<IExternalAuthenticationRegistrar>();
            var externalAuthInstances = externalAuthConfigurations
                .Select(x => (IExternalAuthenticationRegistrar)Activator.CreateInstance(x));

            foreach (var instance in externalAuthInstances)
                instance.Configure(authenticationBuilder);
        }

        /// <summary>
        /// Add and configure MVC for the application
        /// 为应用程序添加和配置MVC
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static IMvcBuilder AddNopMvc(this IServiceCollection services)
        {
            //add basic MVC feature
            //添加基本MVC功能
            var mvcBuilder = services.AddMvc();

            //we use legacy (from previous versions) routing logic
            //我们使用(来自以前版本的)遗留路由逻辑
            mvcBuilder.AddMvcOptions(options => options.EnableEndpointRouting = false);

            //sets the default value of settings on MvcOptions to match the behavior of asp.net core mvc 2.2
            //设置MvcOptions上的默认设置值，以匹配asp.net core mvc 2.2的行为
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var nopConfig = services.BuildServiceProvider().GetRequiredService<NopConfig>();
            if (nopConfig.UseSessionStateTempDataProvider)
            {
                //use session-based temp data provider
                mvcBuilder.AddSessionStateTempDataProvider();
            }
            else
            {
                //use cookie-based temp data provider
                mvcBuilder.AddCookieTempDataProvider(options =>
                {
                    options.Cookie.Name = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.TempDataCookie}";

                    //whether to allow the use of cookies from SSL protected page on the other store pages which are not
                    options.Cookie.SecurePolicy = DataSettingsManager.DatabaseIsInstalled && EngineContext.Current.Resolve<SecuritySettings>().ForceSslForAllPages
                        ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.None;
                });
            }

            //MVC now serializes JSON with camel case names by default, use this code to avoid it
            //MVC现在默认使用驼峰大小写名序列化JSON，使用这段代码来避免它
            mvcBuilder.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //add custom display metadata provider
            //添加自定义显示元数据提供程序
            mvcBuilder.AddMvcOptions(options => options.ModelMetadataDetailsProviders.Add(new NopMetadataProvider()));

            //add custom model binder provider (to the top of the provider list)
            //添加自定义模型绑定器提供程序(到提供程序列表的顶部)
            mvcBuilder.AddMvcOptions(options => options.ModelBinderProviders.Insert(0, new NopModelBinderProvider()));

            //add fluent validation
            //添加流利的验证
            mvcBuilder.AddFluentValidation(configuration =>
            {
                //register all available validators from Nop assemblies
                //从Nop程序集中注册所有可用的验证器
                var assemblies = mvcBuilder.PartManager.ApplicationParts
                    .OfType<AssemblyPart>()
                    .Where(part => part.Name.StartsWith("Nop", StringComparison.InvariantCultureIgnoreCase))
                    .Select(part => part.Assembly);
                configuration.RegisterValidatorsFromAssemblies(assemblies);

                //implicit/automatic validation of child properties
                configuration.ImplicitlyValidateChildProperties = true;
            });

            //register controllers as services, it'll allow to override them
            //将控制器注册为服务，它将允许覆盖它们
            mvcBuilder.AddControllersAsServices();

            return mvcBuilder;
        }

        /// <summary>
        /// Register custom RedirectResultExecutor
        /// 注册自定义RedirectResultExecutor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddNopRedirectResultExecutor(this IServiceCollection services)
        {
            //we use custom redirect executor as a workaround to allow using non-ASCII characters in redirect URLs
            services.AddSingleton<IActionResultExecutor<RedirectResult>, 
                NopRedirectResultExecutor>();
        }

        /// <summary>
        /// Register base object context
        /// 寄存器基对象上下文
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddNopObjectContext(this IServiceCollection services)
        {
            services.AddDbContextPool<NopObjectContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServerWithLazyLoading(services);
            });
        }

        ///// <summary>
        ///// Add and configure MiniProfiler service
        ///// 添加和配置微型分析器服务
        ///// </summary>
        ///// <param name="services">Collection of service descriptors</param>
        //public static void AddNopMiniProfiler(this IServiceCollection services)
        //{
        //    //whether database is already installed
        //    if (!DataSettingsManager.DatabaseIsInstalled)
        //        return;

        //    services.AddMiniProfiler(miniProfilerOptions =>
        //    {
        //        //use memory cache provider for storing each result
        //        ((MemoryCacheStorage)miniProfilerOptions.Storage).CacheDuration = TimeSpan.FromMinutes(60);

        //        //whether MiniProfiler should be displayed
        //        miniProfilerOptions.ShouldProfile = request =>
        //            EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore;

        //        //determine who can access the MiniProfiler results
        //        miniProfilerOptions.ResultsAuthorize = request =>
        //            !EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerForAdminOnly ||
        //            EngineContext.Current.Resolve<IPermissionService>().Authorize(StandardPermissionProvider.AccessAdminPanel);
        //    }).AddEntityFramework();
        //}

        ///// <summary>
        ///// Add and configure WebMarkupMin service
        ///// </summary>
        ///// <param name="services">Collection of service descriptors</param>
        //public static void AddNopWebMarkupMin(this IServiceCollection services)
        //{
        //    //check whether database is installed
        //    if (!DataSettingsManager.DatabaseIsInstalled)
        //        return;

        //    services
        //        .AddWebMarkupMin(options =>
        //        {
        //            options.AllowMinificationInDevelopmentEnvironment = true;
        //            options.AllowCompressionInDevelopmentEnvironment = true;
        //            options.DisableMinification = !EngineContext.Current.Resolve<CommonSettings>().EnableHtmlMinification;
        //            options.DisableCompression = true;
        //            options.DisablePoweredByHttpHeaders = true;
        //        })
        //        .AddHtmlMinification(options =>
        //        {
        //            var settings = options.MinificationSettings;

        //            options.CssMinifierFactory = new NUglifyCssMinifierFactory();
        //            options.JsMinifierFactory = new NUglifyJsMinifierFactory();
        //        })
        //        .AddXmlMinification(options =>
        //        {
        //            var settings = options.MinificationSettings;
        //            settings.RenderEmptyTagsWithSpace = true;
        //            settings.CollapseTagsWithoutContent = true;
        //        });
        //}

        ///// <summary>
        ///// Add and configure EasyCaching service
        ///// </summary>
        ///// <param name="services">Collection of service descriptors</param>
        //public static void AddEasyCaching(this IServiceCollection services)
        //{
        //    services.AddEasyCaching(option =>
        //    {
        //        //use memory cache
        //        option.UseInMemory("nopCommerce_memory_cache");
        //    });
        //}

        ///// <summary>
        ///// Add and configure default HTTP clients
        ///// </summary>
        ///// <param name="services">Collection of service descriptors</param>
        //public static void AddNopHttpClients(this IServiceCollection services)
        //{
        //    //default client
        //    //默认客户端
        //    services.AddHttpClient(NopHttpDefaults.DefaultHttpClient).WithProxy();

        //    //client to request current store
        //    //客户端请求当前存储
        //    services.AddHttpClient<StoreHttpClient>();

        //    //client to request nopCommerce official site
        //    services.AddHttpClient<NopHttpClient>().WithProxy();

        //    //client to request reCAPTCHA service
        //    services.AddHttpClient<CaptchaHttpClient>().WithProxy();
        //}
    }
}
