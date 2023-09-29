using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using De_Kast.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace De_Kast.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cursus> Cursussen { get; set; }
        public DbSet<Personeelslid> Personeel { get; set; }
        public DbSet<Abonnement> Abonnementen { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Cursus>().ToTable("Cursus");
            modelBuilder.Entity<Personeelslid>().ToTable("Personeel");
            modelBuilder.Entity<Abonnementen>().ToTable("Abonnementen");*/
            base.OnModelCreating(modelBuilder);
        }
    }
}