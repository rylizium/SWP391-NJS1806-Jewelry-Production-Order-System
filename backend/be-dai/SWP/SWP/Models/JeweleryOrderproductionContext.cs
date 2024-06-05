﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWP.Models;

public partial class JeweleryOrderproductionContext : DbContext
{
    public JeweleryOrderproductionContext()
    {
    }

    public JeweleryOrderproductionContext(DbContextOptions<JeweleryOrderproductionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<Design> Designs { get; set; }

    public virtual DbSet<DesignImage> DesignImages { get; set; }

    public virtual DbSet<Gemstone> Gemstones { get; set; }

    public virtual DbSet<Metal> Metals { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderCustomItem> OrderCustomItems { get; set; }

    public virtual DbSet<OrderFixedItem> OrderFixedItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductStock> ProductStocks { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProductionStatus> ProductionStatuses { get; set; }

    public virtual DbSet<ProductionTracking> ProductionTrackings { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<RequestImage> RequestImages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HARDLEYDAVIDSON\\HARRYHOA;uid=sa;pwd=12345;database= JeweleryORDERPRODUCTION;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB855B8D1085");

            entity.ToTable("Customer_Detail");

            entity.HasIndex(e => e.UserId, "UQ__Customer__B9BE370E9EF1BC73").IsUnique();

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.AddressLine)
                .HasMaxLength(50)
                .HasColumnName("address_line");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.DistrictTown)
                .HasMaxLength(50)
                .HasColumnName("district_town");
            entity.Property(e => e.FirstName)
                .HasMaxLength(35)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(35)
                .HasColumnName("last_name");
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .HasColumnName("province");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .HasColumnName("sex");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.CustomerDetail)
                .HasForeignKey<CustomerDetail>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer___user___2D27B809");
        });

        modelBuilder.Entity<Design>(entity =>
        {
            entity.HasKey(e => e.DesignId).HasName("PK__Design__1BA5C3FB8182DA93");

            entity.ToTable("Design");

            entity.Property(e => e.DesignId)
                .ValueGeneratedNever()
                .HasColumnName("design_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DesignatedCompletion).HasColumnName("designated_completion");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.OrderCustomId).HasColumnName("order_custom_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.OrderCustom).WithMany(p => p.Designs)
                .HasForeignKey(d => d.OrderCustomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Design__order_cu__5812160E");

            entity.HasOne(d => d.Order).WithMany(p => p.Designs)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Design__order_id__59063A47");
        });

        modelBuilder.Entity<DesignImage>(entity =>
        {
            entity.HasKey(e => e.DesignImageId).HasName("PK__Design_I__02A18B6926795CAD");

            entity.ToTable("Design_Images");

            entity.Property(e => e.DesignImageId)
                .ValueGeneratedNever()
                .HasColumnName("design_image_id");
            entity.Property(e => e.DesignId).HasColumnName("design_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");

            entity.HasOne(d => d.Design).WithMany(p => p.DesignImages)
                .HasForeignKey(d => d.DesignId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Design_Im__desig__5BE2A6F2");
        });

        modelBuilder.Entity<Gemstone>(entity =>
        {
            entity.HasKey(e => e.GemstoneId).HasName("PK__Gemstone__08CCD219B4C8628A");

            entity.ToTable("Gemstone");

            entity.HasIndex(e => new { e.GemstoneType, e.GemstoneCarat, e.Color }, "UQ__Gemstone__3E7282755B039692").IsUnique();

            entity.Property(e => e.GemstoneId)
                .ValueGeneratedNever()
                .HasColumnName("gemstone_id");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.GemstoneCarat).HasColumnName("gemstone_carat");
            entity.Property(e => e.GemstoneType)
                .HasMaxLength(50)
                .HasColumnName("gemstone_type");
        });

        modelBuilder.Entity<Metal>(entity =>
        {
            entity.HasKey(e => e.MetalId).HasName("PK__Metals__15EB863C6E37089E");

            entity.HasIndex(e => e.MetalTypeName, "UQ__Metals__EC08308C43F7F071").IsUnique();

            entity.Property(e => e.MetalId)
                .ValueGeneratedNever()
                .HasColumnName("metal_id");
            entity.Property(e => e.MetalTypeName)
                .HasMaxLength(50)
                .HasColumnName("metal_type_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__4659622999F1E697");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.IsCustom).HasColumnName("is_custom");
            entity.Property(e => e.IsShipment).HasColumnName("is_shipment");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasColumnName("order_status");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("payment_status");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__customer__44FF419A");
        });

        modelBuilder.Entity<OrderCustomItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__Order_Cu__3764B6BC2CCD94E9");

            entity.ToTable("Order_Custom_Items");

            entity.HasIndex(e => new { e.OrderId, e.GemstoneId, e.MetalId, e.Size }, "UQ__Order_Cu__1502BCB8A4D05A65").IsUnique();

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("order_item_id");
            entity.Property(e => e.GemstoneId).HasColumnName("gemstone_id");
            entity.Property(e => e.MetalId).HasColumnName("metal_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Gemstone).WithMany(p => p.OrderCustomItems)
                .HasForeignKey(d => d.GemstoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Cus__gemst__4E88ABD4");

            entity.HasOne(d => d.Metal).WithMany(p => p.OrderCustomItems)
                .HasForeignKey(d => d.MetalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Cus__metal__4F7CD00D");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderCustomItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Cus__order__4D94879B");
        });

        modelBuilder.Entity<OrderFixedItem>(entity =>
        {
            entity.HasKey(e => e.OrderFixedItemId).HasName("PK__Order_Fi__A0C3DD8679DDAB5C");

            entity.ToTable("Order_Fixed_Items");

            entity.HasIndex(e => new { e.OrderId, e.ProductStockId }, "UQ__Order_Fi__14E50BC22BF723AF").IsUnique();

            entity.Property(e => e.OrderFixedItemId)
                .ValueGeneratedNever()
                .HasColumnName("order_fixed_item_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductStockId).HasColumnName("product_stock_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderFixedItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Fix__order__48CFD27E");

            entity.HasOne(d => d.ProductStock).WithMany(p => p.OrderFixedItems)
                .HasForeignKey(d => d.ProductStockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Fix__produ__49C3F6B7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF54DE36A2B");

            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductName, "UQ__Product__2B5A6A5FE4B19AE4").IsUnique();

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");
            entity.Property(e => e.InStock).HasColumnName("inStock");
            entity.Property(e => e.ProductDescription)
                .HasColumnType("text")
                .HasColumnName("product_description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__product__36B12243");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__Product___0302EB4AF2F8AFFE");

            entity.ToTable("Product_Images");

            entity.Property(e => e.ProductImageId)
                .ValueGeneratedNever()
                .HasColumnName("product_image_id");
            entity.Property(e => e.Alt)
                .HasColumnType("text")
                .HasColumnName("alt");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.ProductStockId).HasColumnName("product_stock_id");

            entity.HasOne(d => d.ProductStock).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductStockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_I__produ__619B8048");
        });

        modelBuilder.Entity<ProductStock>(entity =>
        {
            entity.HasKey(e => e.ProductStockId).HasName("PK__Product___2BC69EA41FAFC564");

            entity.ToTable("Product_Stock");

            entity.HasIndex(e => new { e.ProductId, e.GemstoneId, e.MetalId, e.Size }, "UQ__Product___1459A3643DCC9F5F").IsUnique();

            entity.Property(e => e.ProductStockId)
                .ValueGeneratedNever()
                .HasColumnName("product_stock_id");
            entity.Property(e => e.GalleryUrl)
                .HasMaxLength(255)
                .HasColumnName("gallery_url");
            entity.Property(e => e.GemstoneId).HasColumnName("gemstone_id");
            entity.Property(e => e.MetalId).HasColumnName("metal_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");

            entity.HasOne(d => d.Gemstone).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.GemstoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_S__gemst__3E52440B");

            entity.HasOne(d => d.Metal).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.MetalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_S__metal__3F466844");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_S__produ__3D5E1FD2");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PK__Product___6EED3ED64EB51537");

            entity.ToTable("Product_Types");

            entity.HasIndex(e => e.TypeName, "UQ__Product___543C4FD90D04233B").IsUnique();

            entity.Property(e => e.ProductTypeId)
                .ValueGeneratedNever()
                .HasColumnName("product_type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<ProductionStatus>(entity =>
        {
            entity.HasKey(e => e.ProductionStatusId).HasName("PK__Producti__182287F39490BF05");

            entity.ToTable("Production_Status");

            entity.HasIndex(e => e.StatusName, "UQ__Producti__501B3753D1493DCE").IsUnique();

            entity.Property(e => e.ProductionStatusId)
                .ValueGeneratedNever()
                .HasColumnName("production_status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<ProductionTracking>(entity =>
        {
            entity.HasKey(e => e.ProductionId).HasName("PK__Producti__60F4D65CF905F3F5");

            entity.ToTable("Production_Tracking");

            entity.Property(e => e.ProductionId)
                .ValueGeneratedNever()
                .HasColumnName("production_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductionStatusId).HasColumnName("production_status_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductionTrackings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__produ__6E01572D");

            entity.HasOne(d => d.ProductionStatus).WithMany(p => p.ProductionTrackings)
                .HasForeignKey(d => d.ProductionStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__produ__6EF57B66");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.QuoteId).HasName("PK__Quote__0D37DF0C91D4D5C0");

            entity.ToTable("Quote");

            entity.Property(e => e.QuoteId)
                .ValueGeneratedNever()
                .HasColumnName("quote_id");
            entity.Property(e => e.CaratCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("carat_cost");
            entity.Property(e => e.CaratPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("carat_price");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.MetalCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("metal_cost");
            entity.Property(e => e.MetalWeight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("metal_weight");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductionCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("production_cost");
            entity.Property(e => e.QuoteTotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quote_total_price");

            entity.HasOne(d => d.Order).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__order_id__5535A963");
        });

        modelBuilder.Entity<RequestImage>(entity =>
        {
            entity.HasKey(e => e.RequestImageId).HasName("PK__Request___4212A850F3B7F7AB");

            entity.ToTable("Request_Images");

            entity.Property(e => e.RequestImageId)
                .ValueGeneratedNever()
                .HasColumnName("request_image_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.OrderCustomId).HasColumnName("order_custom_id");

            entity.HasOne(d => d.OrderCustom).WithMany(p => p.RequestImages)
                .HasForeignKey(d => d.OrderCustomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Request_I__order__5EBF139D");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__60883D903A6B39C4");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("review_id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__product___68487DD7");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CCC59BF9B7");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__783254B17050B150").IsUnique();

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Shipment__465962297EAC6C8F");

            entity.ToTable("Shipment");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.IsShipping).HasColumnName("is_shipping");
            entity.Property(e => e.ShipmentDate).HasColumnName("shipment_date");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .HasColumnName("shipping_address");
            entity.Property(e => e.ShippingDistrict)
                .HasMaxLength(50)
                .HasColumnName("shipping_district");
            entity.Property(e => e.ShippingFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("shipping_fee");
            entity.Property(e => e.ShippingProvince)
                .HasMaxLength(50)
                .HasColumnName("shipping_province");

            entity.HasOne(d => d.Order).WithOne(p => p.Shipment)
                .HasForeignKey<Shipment>(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Shipment__order___6477ECF3");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__3683B531D0B89EFE");

            entity.ToTable("Status");

            entity.HasIndex(e => e.StatusDetail, "UQ__Status__1433E42087066EA0").IsUnique();

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.StatusDetail)
                .HasMaxLength(50)
                .HasColumnName("status_detail");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AF92E97911");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.IsDeposit).HasColumnName("is_deposit");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .HasColumnName("payment_type");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("transaction_total");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__order__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BE370F1C6E8636");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__AB6E6164B7A7907E").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__User__B43B145FBC022F72").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__role_id__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
