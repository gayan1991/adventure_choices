using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.Interface.Repository;
using Adventure.Infrastructure.Context;
using Adventure.Infrastructure.Interceptors;
using Adventure.Infrastructure.Repository;
using Adventure.Infrastructure.Util.InfraModel;
using Adventure.Infrastructure.Util.InfraService;
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

            #region Infra Services

            services.AddTransient<IRequestResponseLogService, RequestResponseLogService>();

            #endregion

            #region Infra Repositories

            services.AddTransient<IRepository<Audit>, AuditRepository>();
            services.AddTransient<IRepository<RequestResponseLog>, RequestLogRepository>();

            #endregion

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
