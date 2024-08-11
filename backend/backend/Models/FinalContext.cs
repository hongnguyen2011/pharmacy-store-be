using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class FinalContext : DbContext
{
    public FinalContext()
    {
    }

    public FinalContext(DbContextOptions<FinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Detailorder> Detailorders { get; set; }

    public virtual DbSet<Imageproduct> Imageproducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Admin;Initial Catalog=FINAL;Integrated Security=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORY__3213E83FB9E570EF");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .HasColumnName("slug");
        });

        modelBuilder.Entity<Detailorder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETAILOR__3213E83FDCA3E768");

            entity.ToTable("DETAILORDERS");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Detailorders)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK__DETAILORD__idOrd__4D94879B");
        });

        modelBuilder.Entity<Imageproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IMAGEPRO__3213E83FD8B98D1A");

            entity.ToTable("IMAGEPRODUCT");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Imageproducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__IMAGEPROD__idPro__5165187F");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ORDER__3213E83F52E74CC3");

            entity.ToTable("ORDER");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((0))")
                .HasColumnName("status");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__ORDER__idUser__49C3F6B7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3213E83F4025885A");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createAt");
            entity.Property(e => e.Detail)
                .HasMaxLength(255)
                .HasColumnName("detail");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRODUCT__idCateg__440B1D61");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRODUCT__idUser__4316F928");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROLE__3213E83F2BB44D2F");

            entity.ToTable("ROLE");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USER__3213E83FC2248948");

            entity.ToTable("USER");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PathImg).HasColumnName("pathImg");
            entity.Property(e => e.Phone).HasColumnName("phone");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__USER__idRole__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
