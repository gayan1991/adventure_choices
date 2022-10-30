using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Adventure.Infrastructure.Context
{
    public class InfraDbContext : DbContext
    {
        //public DbSet<DoughnutSelection> DoughnutSelections { get; set; }
        //public DbSet<DoughnutSelectionSteps> DoubhnutSelectionSteps { get; set; }
        //public DbSet<RefSelectionProcess> RefSelectionProcess { get; set; }

        public InfraDbContext(DbContextOptions<InfraDbContext> options) : base(options)
        {
        }
    }
}
