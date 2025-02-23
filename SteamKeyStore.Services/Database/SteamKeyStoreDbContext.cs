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
            entity.HasKey(e => e.Id).HasName("PK__Coupon__3214EC0773633CEA");

            entity.ToTable("Coupon");

            entity.HasIndex(e => e.Code, "UQ__Coupon__A25C5AA7D1364600").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CurrentUsage).HasDefaultValue(0);
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Edition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Edition__3214EC0712E31265");

            entity.ToTable("Edition");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Game).WithMany(p => p.Editions)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Edition__GameId__4222D4EF");

            entity.HasMany(d => d.Products).WithMany(p => p.EditionsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "EditionContent",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EditionCo__Produ__46E78A0C"),
                    l => l.HasOne<Edition>().WithMany()
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EditionCo__Editi__45F365D3"),
                    j =>
                    {
                        j.HasKey("EditionId", "ProductId").HasName("PK__EditionC__0C22EF2F232AE684");
                        j.ToTable("EditionContent");
                        j.IndexerProperty<int>("EditionId").HasColumnName("EditionID");
                    });
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC073410D35D");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Product).WithMany(p => p.News)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__ProductID__5DCAEF64");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC074093681D");

            entity.ToTable("Order");

            entity.Property(e => e.CouponId).HasColumnName("CouponID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK__Order__CouponID__68487DD7");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__CustomerI__66603565");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC0736178329");

            entity.ToTable("OrderItem");

            entity.Property(e => e.DiscountApplied).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EditionId).HasColumnName("EditionID");
            entity.Property(e => e.FinalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Edition).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.EditionId)
                .HasConstraintName("FK__OrderItem__Editi__6C190EBB");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__6B24EA82");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__6D0D32F4");
        });

        modelBuilder.Entity<OrderItemKey>(entity =>
        {
            entity.HasKey(e => e.OrderItemKeyId).HasName("PK__OrderIte__C5478C0A1221C367");

            entity.ToTable("OrderItemKey");

            entity.Property(e => e.OrderItemKeyId).HasColumnName("OrderItemKeyID");
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.ProductKeyId).HasColumnName("ProductKeyID");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.OrderItemKeys)
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__75A278F5");

            entity.HasOne(d => d.ProductKey).WithMany(p => p.OrderItemKeys)
                .HasForeignKey(d => d.ProductKeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__76969D2E");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07CFCF039B");

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
                .IsUnicode(false)
                .HasConversion<string>();

            entity.HasOne(d => d.Developer).WithMany(p => p.ProductDevelopers)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Develop__3C69FB99");

            entity.HasOne(d => d.Game).WithMany(p => p.InverseGame)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Product__GameId__3E52440B");

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
                        .HasConstraintName("FK__ProductTa__TagID__4D94879B"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductTa__Produ__4CA06362"),
                    j =>
                    {
                        j.HasKey("ProductId", "TagId").HasName("PK__ProductT__625B09494E7C76ED");
                        j.ToTable("ProductTag");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("TagId").HasColumnName("TagID");
                    });
        });

        modelBuilder.Entity<ProductKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductK__3214EC07154D502B");

            entity.ToTable("ProductKey");

            entity.HasIndex(e => e.KeyCode, "UQ__ProductK__5B86B6EFBC3D4D9F").IsUnique();

            entity.Property(e => e.KeyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductKeys)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductKe__Produ__71D1E811");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3214EC07D33C1BBB");

            entity.ToTable("Review");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__Customer__59063A47");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__ProductI__5812160E");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC0756E4A346");

            entity.ToTable("Sale");

            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Edition).WithMany(p => p.Sales)
                .HasForeignKey(d => d.EditionId)
                .HasConstraintName("FK__Sale__EditionId__5165187F");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Sale__ProductId__5070F446");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tag__3214EC0781BA8656");

            entity.ToTable("Tag");

            entity.HasIndex(e => e.Name, "UQ__Tag__737584F6BB9569DD").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC077938DA1F");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534D4EA2448").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasConversion<string>();
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wishlist__3214EC07EA3E6179");

            entity.ToTable("Wishlist");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wishlist__Custom__619B8048");

            entity.HasOne(d => d.Product).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wishlist__Produc__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
