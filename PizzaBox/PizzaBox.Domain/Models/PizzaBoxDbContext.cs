using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Domain
{
    public partial class PizzaBoxDbContext : DbContext
    {
        public PizzaBoxDbContext()
        {
        }

        public PizzaBoxDbContext(DbContextOptions<PizzaBoxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cheese> Cheese { get; set; }
        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5VQ0CSFS\\SQLEXPRESS ;Database=PizzaBoxDb; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cheese>(entity =>
            {
                entity.ToTable("Cheese", "PizzaBox");

                entity.HasIndex(e => e.CheeseName)
                    .HasName("UQ__Cheese__84652CB6ECE42216")
                    .IsUnique();

                entity.Property(e => e.CheeseId).HasColumnName("cheese_id");

                entity.Property(e => e.CheeseName)
                    .IsRequired()
                    .HasColumnName("cheese_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "PizzaBox");

                entity.HasIndex(e => e.CrustName)
                    .HasName("UQ__Crust__3598F912963B5E18")
                    .IsUnique();

                entity.Property(e => e.CrustId).HasColumnName("crust_id");

                entity.Property(e => e.CrustName)
                    .IsRequired()
                    .HasColumnName("crust_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "PizzaBox");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Customer__F3DBC5728A70AD36")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sauce>(entity =>
            {
                entity.ToTable("Sauce", "PizzaBox");

                entity.HasIndex(e => e.SauceName)
                    .HasName("UQ__Sauce__1D98A6C3202A364E")
                    .IsUnique();

                entity.Property(e => e.SauceId).HasColumnName("sauce_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.SauceName)
                    .IsRequired()
                    .HasColumnName("sauce_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
