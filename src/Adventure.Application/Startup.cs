using System.Reflection;
using Adventure.Domain.Interface.Repository;
using Adventure.Infrastructure;
using Adventure.Infrastructure.Repository;
using Adventure.Service.Impl;
using Adventure.Service.Interface;

namespace Adventure.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            #region EntityFramework Core

            services.CreateDbInstance(Configuration, typeof(Startup).GetTypeInfo().Assembly.GetName().Name!);

            #endregion

            #region Service

            services.AddTransient<IAdventureService, AdventureService>();
            services.AddTransient<IUserAdventureService, UserAdventureService>();

            #endregion

            #region DomainService
            
            #endregion

            #region Repository

            services.AddTransient<IAdventureRepository, AdventureRepository>();
            services.AddTransient<IUserAdventureSelectionRepository, UserAdventureSelectionRepository>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(ep => { ep.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Adventure Selection V1");
            });
        }
    }
}
