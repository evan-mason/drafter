using Drafter.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data
{
    public class DrafterContext: IdentityDbContext<DrafterUser>
    {
        private readonly IConfiguration _config;

        public DrafterContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
        //public DbSet<DrafterUser> Users { get; set; }

        public DbSet<Draft> Drafts { get; set; }
        public DbSet<Pick> Picks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DrafterContextDb"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DrafterUser>()
                .HasOne(a => a.FantasyTeam)
                .WithOne(a => a.DrafterUser)
                .HasForeignKey<FantasyTeam>(f => f.DrafterUserId)
                .IsRequired(false);
         }
    }
}
