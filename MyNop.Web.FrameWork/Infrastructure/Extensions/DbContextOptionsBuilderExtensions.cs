using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Configuration;
using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNop.Web.FrameWork.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of DbContextOptionsBuilder
    /// 表示DbContextOptionsBuilder的扩展
    /// </summary>
    public static class DbContextOptionsBuilderExtensions
    {
        /// <summary>
        /// SQL Server specific extension method for Microsoft.EntityFrameworkCore.DbContextOptionsBuilder
        /// </summary>
        /// <param name="optionsBuilder">Database context options builder</param>
        /// <param name="services">Collection of service descriptors</param>
        public static void UseSqlServerWithLazyLoading(this DbContextOptionsBuilder optionsBuilder, IServiceCollection services)
        {
            var nopConfig = services.BuildServiceProvider().GetRequiredService<NopConfig>();

            var dataSettings = DataSettingsManager.LoadSettings();
            if (!dataSettings?.IsValid ?? true)
                return;

            var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();

            if (nopConfig.UseRowNumberForPaging)
                dbContextOptionsBuilder.UseSqlServer(dataSettings.DataConnectionString, option => option.UseRowNumberForPaging());
            else
                dbContextOptionsBuilder.UseSqlServer(dataSettings.DataConnectionString);
        }
    }
}
