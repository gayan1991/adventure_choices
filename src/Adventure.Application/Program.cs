using Adventure.Application;
using Adventure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var advDb = scope.ServiceProvider.GetRequiredService<AdventureDbContext>();
    await advDb.Database.MigrateAsync();

    var infraDb = scope.ServiceProvider.GetRequiredService<InfraDbContext>();
    await infraDb.Database.MigrateAsync();
}

app.Run();