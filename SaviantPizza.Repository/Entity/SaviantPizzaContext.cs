using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SaviantPizza.Repository.Entity
{
    public partial class SaviantPizzaContext : DbContext
    {
        public SaviantPizzaContext()
        {
        }

        public SaviantPizzaContext(DbContextOptions<SaviantPizzaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<PizzaCategory> PizzaCategory { get; set; }
        public virtual DbSet<PizzaType> PizzaType { get; set; }
        public virtual DbSet<Pricing> Pricing { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VendorType> VendorType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SaviantPizza;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OrdeTotal).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__UserId__45F365D3");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Discount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OtherDiscount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalAfterDiscount).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.PizzaType)
                    .WithMany()
                    .HasForeignKey(d => d.PizzaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Pizza__49C3F6B7");

                entity.HasOne(d => d.Vendor)
                    .WithMany()
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Vendo__4AB81AF0");
            });

            modelBuilder.Entity<PizzaCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PizzaType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PizzaName).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PizzaType)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaType__Categ__412EB0B6");
            });

            modelBuilder.Entity<Pricing>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasColumnType("decimal(3, 1)");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Pricing)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pricing__PizzaId__3D5E1FD2");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Pricing)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pricing__VendorI__3E52440B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VendorType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.VendorName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
