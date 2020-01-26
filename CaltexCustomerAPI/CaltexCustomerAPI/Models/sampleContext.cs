using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CaltexCustomerAPI.Models
{
    public partial class sampleContext : DbContext
    {
        public sampleContext()
        {
        }

        public sampleContext(DbContextOptions<sampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<CustomerTransaction> CustomerTransaction { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<TotalDetail> TotalDetail { get; set; }
        //public virtual DbSet<TotalDetails> TblTotalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MSI;Database=sample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tblBasket");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.BasketId)
                    .HasColumnName("BasketID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.TblBasket)
                    .HasForeignKey<Basket>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBasket_tblCustomerTransaction");
            });

            modelBuilder.Entity<CustomerTransaction>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_tblCustomerTransactionn");

                entity.ToTable("tblCustomerTransaction");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.DtmInserted)
                    .HasColumnName("dtmInserted")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtmTransaction)
                    .HasColumnName("dtmTransaction")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoyaltyCard)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("tblDiscount");

                entity.Property(e => e.DiscountId).HasMaxLength(50);

                entity.Property(e => e.DiscountPromotionName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DtmInserted)
                    .HasColumnName("dtmInserted")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblDiscount)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProductDetails_tblDiscount");
            });

            modelBuilder.Entity<ProductDetails>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_tblProductDetails	");

                entity.ToTable("tblProductDetails");

                entity.Property(e => e.ProductId).HasMaxLength(50);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DtmInserted)
                    .HasColumnName("dtmInserted")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.PromotionId)
                    .HasName("PK_tblPromotion	");

                entity.ToTable("tblPromotion");

                entity.Property(e => e.PromotionId).HasMaxLength(50);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DtmInserted)
                    .HasColumnName("dtmInserted")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PromotionName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TotalDetail>(entity =>
            
            {
                entity.HasKey(e => e.TotalD)
                .HasName("PK_tblTotalDetail	");

                entity.ToTable("tblTotalDetail");

                entity.Property(e => e.DtmInserted)
                    .HasColumnName("dtmInserted")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblTotalDetail)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTotalDetail_tblCustomerTransaction");
            });

            //modelBuilder.Entity<TotalDetail>(entity =>
            //{
            //    entity.HasKey(e => e.TotalD);

            //    entity.ToTable("tblTotalDetails");

            //    entity.Property(e => e.DtmInserted)
            //        .HasColumnName("dtmInserted")
            //        .HasColumnType("datetime");

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.TblTotalDetail)
            //        .HasForeignKey(d => d.CustomerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_tblTotalDetails_tblCustomerTransaction");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
