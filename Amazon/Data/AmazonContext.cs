using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Amazon.Models;

namespace Amazon.Data
{
    // It defines all about connecting to database
    public partial class AmazonContext : DbContext
    {
        public AmazonContext()
        {
        }

        public AmazonContext(DbContextOptions<AmazonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmzCategory> AmzCategories { get; set; } = null!;
        public virtual DbSet<AmzDepartment> AmzDepartments { get; set; } = null!;
        public virtual DbSet<AmzProduct> AmzProducts { get; set; } = null!;
        public virtual DbSet<AmzUser> AmzUsers { get; set; } = null!;
        public virtual DbSet<AmzUserRole> AmzUserRoles { get; set; } = null!;

        // Configuration for database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:ds-amazon.database.windows.net,1433;Initial Catalog=db-amazon;Persist Security Info=False;User ID=sa-admin;Password=Amazon@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmzCategory>(entity =>
            {
                entity.HasKey(e => e.CtgyId)
                    .HasName("PK__AMZ_CATE__96F0B9E74B1477F7");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.AmzCategories)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_CATEGORY_DEPARTMENT");
            });

            modelBuilder.Entity<AmzDepartment>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__AMZ_DEPA__512A59ACCD5A51AD");
            });

            modelBuilder.Entity<AmzProduct>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__AMZ_PROD__B3271E11D73F7FD6");

                entity.HasOne(d => d.Ctgy)
                    .WithMany(p => p.AmzProducts)
                    .HasForeignKey(d => d.CtgyId)
                    .HasConstraintName("FK_PRODUCT_CATEGORY");
            });

            modelBuilder.Entity<AmzUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AMZ_USER__F3BEEBFFA8B32E5F");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.AmzUsers)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_AMZ_USER_USER_ROLE");
            });

            modelBuilder.Entity<AmzUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId)
                    .HasName("PK__AMZ_USER__A50F1D2081D7A1C1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
