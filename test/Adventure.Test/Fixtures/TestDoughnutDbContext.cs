using Adventure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Test.Fixtures
{
    public class TesAdventureDbContext : AdventureDbContext
    {
        public TesAdventureDbContext(DbContextOptions<AdventureDbContext> options) : base(options)
        {

        }

        public static TesAdventureDbContext GetTestDb()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var options = new DbContextOptionsBuilder<AdventureDbContext>().UseInMemoryDatabase("AdventureDb").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).UseInternalServiceProvider(serviceProvider).Options;

            var dbContext = new TesAdventureDbContext(options);

            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
