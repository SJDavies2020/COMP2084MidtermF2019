using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace COMP2084MidtermF2019.Models
{
    public partial class f19Context : IdentityDbContext
    {
        public f19Context()
        {
        }

        public f19Context(DbContextOptions<f19Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<Riding> Riding { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_PartyId");

                entity.HasOne(d => d.Riding)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.RidingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_RidingId");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Riding>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });
        }
    }
}
