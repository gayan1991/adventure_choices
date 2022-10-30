using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureModels;
using Adventure.Domain.DomainModels.SelectionModels;
using Adventure.Infrastructure.EntityConfiguration.AdventureEntityConfigurations;
using Adventure.Infrastructure.EntityConfiguration.UserSelectionEntityConfigurations;
using Adventure.Infrastructure.SeedHelper;
using Microsoft.EntityFrameworkCore;

namespace Adventure.Infrastructure.Context
{
    public class AdventureDbContext : DbContext
    {
        #region Adventure Selection

        public DbSet<UserAdventureSelection> UserAdventureSelections { get; set; }
        public DbSet<UserAdventureStepsSelection> UserAdventureStepsSelections { get; set; }

        #endregion

        #region Adventure Master Data

        public DbSet<Domain.DomainModels.AdventureModels.Adventure> Adventures { get; set; }
        public DbSet<AdventureSelection> AdventureSelections { get; set; }

        #endregion

        public AdventureDbContext(DbContextOptions<AdventureDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDataDoughnutSelectionProcess();

            modelBuilder.ApplyConfiguration(new AdventureModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdventureSelectionModelEntityConfigurations());
            modelBuilder.ApplyConfiguration(new UserAdventureSelectionModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserAdventureStepsSelectionModelEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
