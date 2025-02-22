using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SteamKeyStore.Services.Database;

public partial class SteamKeyStoreDbContext : DbContext
{
    public SteamKeyStoreDbContext()
    {
    }

    public SteamKeyStoreDbContext(DbContextOptions<SteamKeyStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Edition> Editions { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderItemKey> OrderItemKeys { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductKey> ProductKeys { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coupon__3214EC0797A7FB6A");

            entity.ToTable("Coupon");

            entity.HasIndex(e => e.Code, "UQ__Coupon__A25C5AA70D328DA0").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CurrentUsage).HasDefaultValue(0);
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Edition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Edition__3214EC07833F6545");

            entity.ToTable("Edition");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Game).WithMany(p => p.Editions)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Edition__GameId__412EB0B6");

            entity.HasMany(d => d.Products).WithMany(p => p.EditionsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "EditionContent",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EditionCo__Produ__45F365D3"),
                    l => l.HasOne<Edition>().WithMany()
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EditionCo__Editi__44FF419A"),
                    j =>
                    {
                        j.HasKey("EditionId", "ProductId").HasName("PK__EditionC__0C22EF2F22B5AE13");
                        j.ToTable("EditionContent");
                        j.IndexerProperty<int>("EditionId").HasColumnName("EditionID");
                    });
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC071D51B5B6");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Product).WithMany(p => p.News)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__ProductID__5CD6CB2B");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07C936EC36");

            entity.ToTable("Order");

            entity.Property(e => e.CouponId).HasColumnName("CouponID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK__Order__CouponID__6754599E");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__CustomerI__656C112C");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC0732C88D0E");

            entity.ToTable("OrderItem");

            entity.Property(e => e.DiscountApplied).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EditionId).HasColumnName("EditionID");
            entity.Property(e => e.FinalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Edition).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.EditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Editi__6B24EA82");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__6A30C649");
        });

        modelBuilder.Entity<OrderItemKey>(entity =>
        {
            entity.HasKey(e => e.OrderItemKeyId).HasName("PK__OrderIte__C5478C0A5F9DB51A");

            entity.ToTable("OrderItemKey");

            entity.Property(e => e.OrderItemKeyId).HasColumnName("OrderItemKeyID");
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.ProductKeyId).HasColumnName("ProductKeyID");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.OrderItemKeys)
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__73BA3083");

            entity.HasOne(d => d.ProductKey).WithMany(p => p.OrderItemKeys)
                .HasForeignKey(d => d.ProductKeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__74AE54BC");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0784893482");

            entity.ToTable("Product");

            entity.Property(e => e.DeveloperId).HasColumnName("DeveloperID");
            entity.Property(e => e.MainImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MainImageURL");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Developer).WithMany(p => p.ProductDevelopers)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Develop__3C69FB99");

            entity.HasOne(d => d.Game).WithMany(p => p.InverseGame)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Product__GameId__76969D2E");

            entity.HasOne(d => d.Publisher).WithMany(p => p.ProductPublishers)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Publish__3D5E1FD2");

            entity.HasMany(d => d.Tags).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductTa__TagID__4CA06362"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductTa__Produ__4BAC3F29"),
                    j =>
                    {
                        j.HasKey("ProductId", "TagId").HasName("PK__ProductT__625B09494A7CF538");
                        j.ToTable("ProductTag");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("TagId").HasColumnName("TagID");
                    });
        });

        modelBuilder.Entity<ProductKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductK__3214EC07A939B8F9");

            entity.ToTable("ProductKey");

            entity.HasIndex(e => e.KeyCode, "UQ__ProductK__5B86B6EF5B4D4BE1").IsUnique();

            entity.Property(e => e.KeyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductKeys)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductKe__Produ__6FE99F9F");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3214EC07E3FD3D97");

            entity.ToTable("Review");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__Customer__5812160E");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__ProductI__571DF1D5");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC07ACB2E6DB");

            entity.ToTable("Sale");

            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Edition).WithMany(p => p.Sales)
                .HasForeignKey(d => d.EditionId)
                .HasConstraintName("FK__Sale__EditionId__5070F446");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Sale__ProductId__4F7CD00D");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tag__3214EC0754172BC5");

            entity.ToTable("Tag");

            entity.HasIndex(e => e.Name, "UQ__Tag__737584F60CD90E8E").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC072D0A1C6C");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534A4D28875").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wishlist__3214EC07852A49F2");

            entity.ToTable("Wishlist");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wishlist__Custom__60A75C0F");

            entity.HasOne(d => d.Product).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wishlist__Produc__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
