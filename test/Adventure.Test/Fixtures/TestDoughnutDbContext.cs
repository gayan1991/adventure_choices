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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static TesAdventureDbContext GetTestDB()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var options = new DbContextOptionsBuilder<AdventureDbContext>().UseInMemoryDatabase("UserDb").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).UseInternalServiceProvider(serviceProvider).Options;

            var dbContext = new TesAdventureDbContext(options);

            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
