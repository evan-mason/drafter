using Drafter.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data
{
    public class DrafterContext: DbContext
    {
        private readonly IConfiguration _config;

        public DrafterContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DrafterContextDb"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(a => a.FantasyTeam)
                .WithOne(a => a.User)
                .HasForeignKey<FantasyTeam>(f => f.Id);
         }
    }
}
