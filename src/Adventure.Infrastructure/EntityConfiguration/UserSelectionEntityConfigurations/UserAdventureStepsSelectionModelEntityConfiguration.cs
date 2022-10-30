using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.SelectionModels;

namespace Adventure.Infrastructure.EntityConfiguration.UserSelectionEntityConfigurations
{
    internal class UserAdventureStepsSelectionModelEntityConfiguration : BaseEntityTypeConfiguration<UserAdventureStepsSelection>
    {
        public override void DomainConfiguration(EntityTypeBuilder<UserAdventureStepsSelection> builder)
        {
            builder.Property(s => s.Step).IsRequired();
        }
    }
}
