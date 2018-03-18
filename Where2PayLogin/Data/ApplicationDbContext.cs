using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Where2PayLogin.Models;

namespace Where2PayLogin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Biller> Billers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentsBillers> AgentsBillers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UsersBillers> UsersBillers { get; set; }
        public DbSet<UsersBillerInfo> UsersBillerInfo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agent>().HasKey(m => m.ID);
            modelBuilder.Entity<Biller>().HasKey(m => m.ID);
            modelBuilder.Entity<UsersBillerInfo>().HasKey(m => m.ID);

            modelBuilder.Entity<AgentsBillers>()
                .HasKey(ab => new { ab.AgentID, ab.BillerID });

            modelBuilder.Entity<AgentsBillers>()
                .HasOne(ab => ab.Agent)
                .WithMany(b => b.AgentsBillers)
                .HasForeignKey(ab => ab.AgentID);

            modelBuilder.Entity<AgentsBillers>()
                .HasOne(ab => ab.Biller)
                .WithMany(a => a.AgentsBillers)
                .HasForeignKey(ab => ab.BillerID);

            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
        }
    }
}
