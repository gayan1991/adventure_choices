using Adventure.Infrastructure.Util.InfraModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.EntityConfiguration.InfraEntityConfiguration
{
    public class AuditEntityConfiguration : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("Audit").HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Table).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Record);
        }
    }
}
