using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureAggregate;
using Microsoft.EntityFrameworkCore;

namespace Adventure.Infrastructure.EntityConfiguration.AdventureEntityConfigurations
{
    internal class AdventureModelEntityConfiguration : BaseEntityTypeConfiguration<Adventure.Domain.DomainModels.AdventureAggregate.Adventure>
    {
        public override void DomainConfiguration(EntityTypeBuilder<Adventure.Domain.DomainModels.AdventureAggregate.Adventure> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(200);

            builder.HasMany(a => a.Choices).WithOne(a => a.Adventure).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
