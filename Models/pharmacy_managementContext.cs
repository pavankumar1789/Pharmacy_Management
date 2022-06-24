using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Pharmacy_Management1.Models
{
    public partial class pharmacy_managementContext : DbContext
    {
        public pharmacy_managementContext()
        {
        }

        public pharmacy_managementContext(DbContextOptions<pharmacy_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DrugDetail> DrugDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<SupplierDetail> SupplierDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OFVB849\\SQLEXPRESS;Database=pharmacy_management;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugDetail>(entity =>
            {
                entity.HasKey(e => e.DrugId)
                    .HasName("PK__DrugDeta__908D6616ABE7376F");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DrugName).HasMaxLength(100);

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.DrugDetails)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__DrugDetai__Suppl__3A81B327");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.UserId })
                    .HasName("PK__Orders__12E8D70B1DDC0612");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__OrderId__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__49C3F6B7");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BCFBF0E29D6");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderPickedUp).HasColumnType("datetime");

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.DrugId)
                    .HasConstraintName("FK__OrderDeta__DrugI__3D5E1FD2");
            });

            modelBuilder.Entity<SupplierDetail>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__Supplier__4BE666B4AD10AFCE");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierContact).HasMaxLength(100);

                entity.Property(e => e.SupplierEmail).HasMaxLength(255);

                entity.Property(e => e.SupplierName).HasMaxLength(100);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4CE3338137");

                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

              

                entity.Property(e => e.UserAddress).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.UserPassword).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
