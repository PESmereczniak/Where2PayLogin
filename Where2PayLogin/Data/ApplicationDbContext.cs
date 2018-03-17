﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}