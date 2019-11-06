using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Model
{
    class RandomizerContext : DbContext
    {
        public RandomizerContext() : base("Randomizer")
        {
            Database.SetInitializer<RandomizerContext>(
                new MigrateDatabaseToLatestVersion<RandomizerContext, RandomizerLib.Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
