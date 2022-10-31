using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureAggregate;

namespace Adventure.Infrastructure.EntityConfiguration.AdventureEntityConfigurations
{
    internal class AdventureSelectionModelEntityConfigurations : BaseEntityTypeConfiguration<AdventureSelection>
    {
        public override void DomainConfiguration(EntityTypeBuilder<AdventureSelection> builder)
        {
            builder.Property(a => a.Code).IsRequired();

            builder.Property(a => a.ParentCode);

            builder.Property(a => a.Text).IsRequired().HasMaxLength(100);

            builder.Property(a => a.Action).HasMaxLength(10);

            builder.Ignore(a => a.NextSelection);
        }
    }
}
