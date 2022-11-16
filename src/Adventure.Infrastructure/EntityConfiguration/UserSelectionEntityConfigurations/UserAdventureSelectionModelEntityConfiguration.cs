using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.UserSelectionAggregate;
using Microsoft.EntityFrameworkCore;

namespace Adventure.Infrastructure.EntityConfiguration.UserSelectionEntityConfigurations
{
    internal class UserAdventureSelectionModelEntityConfiguration : BaseEntityTypeConfiguration<UserAdventureSelection>
    {
        public override void DomainConfiguration(EntityTypeBuilder<UserAdventureSelection> builder)
        {
            builder.Property(d => d.UserId).IsRequired();

            builder.Property(d => d.AdventureId).IsRequired();

            builder.Property(u => u.IsCompleted).IsRequired().HasDefaultValue(false);

            builder.HasMany(d => d.Steps).WithOne(s => s.AdventureSelection).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
