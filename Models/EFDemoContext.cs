using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dbdemo.Models
{
    public partial class EFDemoContext : DbContext
    {
        public EFDemoContext()
        {
        }

        public EFDemoContext(DbContextOptions<EFDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clans> Clans { get; set; }
        public virtual DbSet<NinjaEquipments> NinjaEquipments { get; set; }
        public virtual DbSet<Ninjas> Ninjas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=EFDemo;User Id= sa; Password=MyDocker123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clans>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClanName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NinjaEquipments>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NinjaId).HasColumnName("Ninja_Id");

                entity.HasOne(d => d.Ninja)
                    .WithMany(p => p.NinjaEquipments)
                    .HasForeignKey(d => d.NinjaId)
                    .HasConstraintName("FK__NinjaEqui__Ninja__3D5E1FD2");
            });

            modelBuilder.Entity<Ninjas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.Ninjas)
                    .HasForeignKey(d => d.ClanId)
                    .HasConstraintName("FK__Ninjas__ClanId__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
