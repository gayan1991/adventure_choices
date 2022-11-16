using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text;
using Adventure.Infrastructure.Util.InfraModel;

namespace Adventure.Infrastructure.Interceptors
{
    public class AdventureSaveChangeInterceptor : SaveChangesInterceptor
    {
        private readonly IServiceProvider _services;

        public AdventureSaveChangeInterceptor(IServiceProvider services)
        {
            _services = services;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
               DbContextEventData eventData,
               InterceptionResult<int> result,
               CancellationToken cancellationToken = new CancellationToken())
        {
            using (var scope = _services.CreateScope())
            {
                try
                {
                    foreach (var entry in eventData!.Context!.ChangeTracker.Entries())
                    {
                        var messageBody = entry.Properties.Aggregate("", (auditString, property) => auditString + $"{property.Metadata.Name}: '{property.CurrentValue}' ");
                            var audit = new Audit($"{ entry.Metadata.Name } - { entry.State}", messageBody);
                    }
                    
                }
                catch
                {
                    //scope.r();
                }
            }

            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}
