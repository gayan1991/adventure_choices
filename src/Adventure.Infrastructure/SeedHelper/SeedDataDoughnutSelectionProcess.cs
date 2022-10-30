using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureModels;

namespace Adventure.Infrastructure.SeedHelper
{
    public static class SeedSelectionProcess
    {
        public static void SeedDataDoughnutSelectionProcess(this ModelBuilder builder)
        {
            #region Parent

            var adventure = new Domain.DomainModels.AdventureModels.Adventure("Doughnut Selection");
            builder.Entity<Domain.DomainModels.AdventureModels.Adventure>().HasData(adventure);

            #endregion

            #region Tire1
            
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 0, "DO I WANT A DOUGHNUT?"));

            #endregion

            #region Tier2
            
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 1, "Do I deserve it?", "Yes", 0));
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 2, "Maybe you want an apple?", "No", 0));

            #endregion

            #region Tier3
            
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 3, "Are you sure?", "Yes", 1));
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 4, "Is it a good doughnut?", "No", 1));

            #endregion

            #region Tier4
            
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 5, "Get it.", "Yes", 3));
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 6, "Do jumping jacks first.", "No", 3));
            
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 7, "What are you waiting for? Grab it now.", "Yes", 4));
            builder.Entity<AdventureSelection>().HasData(GenerateSelection(adventure.Id, 8, "Wait 'till you find a sinful unforgettable doughnut.", "No", 4));

            #endregion
        }

        private static dynamic GenerateSelection(Guid adventureId, byte code, string text, string? action = null, byte? parentCode = null)
        {
            return new
            {
                Id = Guid.NewGuid(),
                Code = code,
                ParentCode = parentCode,
                Text = text,
                Action = action,
                AdventureId = adventureId
            };
        }
    }
}
