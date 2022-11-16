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
    internal class RequestResponseLogEntityConfiguration : IEntityTypeConfiguration<RequestResponseLog>
    {
        public void Configure(EntityTypeBuilder<RequestResponseLog> builder)
        {
            builder.ToTable("RequestResponseLog").HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.LogType).IsRequired().HasMaxLength(20).HasConversion(to => to.ToString(),
                from => (RequestResponseLogType)Enum.Parse(typeof(RequestResponseLogType), from));

            builder.Property(u => u.DisplayName).IsRequired().HasMaxLength(200);

            builder.Property(u => u.Parameters);

            builder.Property(u => u.RouteValues);
        }
    }
}
