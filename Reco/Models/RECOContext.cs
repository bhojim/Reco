using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Reco.Models
{
    public partial class RECOContext : DbContext
    {
        //public RECOContext()
        //{
        //}

        public RECOContext(DbContextOptions<RECOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Page> Page { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID");
                    //.ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Guid).HasColumnName("GUID");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Page)
                    .HasForeignKey(d => d.Guid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
