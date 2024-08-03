using Microsoft.EntityFrameworkCore;
//using EntityFramework.Models;
//using System.Collections.Generic;
using Lab5.Models;
//need this other wise got error The type or namespace name 'Subscription' could not be found (are you missing a using directive or an assembly reference?)

namespace Lab5.Data
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fan> Fans { get; set; }
        public DbSet<SportClub> SportClubs { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call base class implementation
            base.OnModelCreating(modelBuilder);

            // Define table names
            modelBuilder.Entity<Fan>().ToTable("Fan");
            modelBuilder.Entity<SportClub>().ToTable("SportClub");
            modelBuilder.Entity<Subscription>().ToTable("Subscription");

           
        }
    }

  
}
