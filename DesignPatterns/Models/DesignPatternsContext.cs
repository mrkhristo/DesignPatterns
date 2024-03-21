using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DesignPatterns.Models
{
    public partial class DesignPatternsContext : DbContext
    {
        public DesignPatternsContext()
        {
        }

        public DesignPatternsContext(DbContextOptions<DesignPatternsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beer> Beers { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;DataBase=DesignPatterns;Trusted_Connection=true;User=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>(entity =>
            {
                entity.ToTable("Beer");

                entity.Property(e => e.BeerId).HasColumnName("BeerID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Style).HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
