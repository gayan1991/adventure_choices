using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Infrastructure.Context;
using Adventure.Infrastructure.Interceptors;
using Adventure.Infrastructure.Util.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Infrastructure
{
    public static class SetUpDbContexts
    {
        public static void CreateDbInstance(this IServiceCollection services,
            IConfiguration configuration,
            string assemblyName)
        {
            var config = new DbConfig();
            configuration.Bind(nameof(DbConfig), config);
            services.AddSingleton<SaveChangesInterceptor, AdventureSaveChangeInterceptor>();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AdventureDbContext>((serviceProvider, options) =>
                {
                    options.UseSqlServer(config.ToString(), sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(assemblyName);
                            sqlOptions.CommandTimeout(config.CommandTimeout);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: config.MaxRetryCount, maxRetryDelay: TimeSpan.FromSeconds(config.MaxRetryDelay), errorNumbersToAdd: null);
                        })
                        .AddInterceptors(serviceProvider.GetRequiredService<SaveChangesInterceptor>());
                });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<InfraDbContext>((serviceProvider, options) =>
                {
                    options.UseSqlServer(config.ToString(), sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(assemblyName);
                        sqlOptions.CommandTimeout(config.CommandTimeout);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: config.MaxRetryCount, maxRetryDelay: TimeSpan.FromSeconds(config.MaxRetryDelay), errorNumbersToAdd: null);
                    });
                });
        }
    }
}
