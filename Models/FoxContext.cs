using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoxDB.Models;

public partial class FoxContext : DbContext
{
    public FoxContext()
    {
    }

    public FoxContext(DbContextOptions<FoxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC\\MSSQLSERVER01;Database=Fox;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B86FE7AA7A");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF488D3FEC");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerIdFk).HasColumnName("CustomerID_FK");
            entity.Property(e => e.ProductIdFk).HasColumnName("ProductID_FK");

            entity.HasOne(d => d.CustomerIdFkNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerIdFk)
                .HasConstraintName("FK__Orders__Customer__440B1D61");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductIdFk)
                .HasConstraintName("FK__Orders__ProductI__44FF419A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDD174EE4F");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
