using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Infrastructure.EntityConfiguration.InfraEntityConfiguration;
using Adventure.Infrastructure.Util.InfraModel;
using Microsoft.EntityFrameworkCore;

namespace Adventure.Infrastructure.Context
{
    public class InfraDbContext : DbContext
    {
        public DbSet<Audit> Audits { get; set; }
        public DbSet<RequestResponseLog> RequestResponseLogs { get; set; }

        public InfraDbContext(DbContextOptions<InfraDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("system");
            modelBuilder.ApplyConfiguration(new AuditEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestResponseLogEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
