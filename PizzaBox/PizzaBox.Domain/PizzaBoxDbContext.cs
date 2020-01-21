using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

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
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderPizzasMap> OrderPizzasMap { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaToppingsMap> PizzaToppingsMap { get; set; }
        public virtual DbSet<RestaurantPizzasMap> RestaurantPizzasMap { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configBuilder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = configBuilder.Build();

                optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cheese>(entity =>
            {
                entity.ToTable("Cheese", "PizzaBox");

                entity.HasIndex(e => e.CheeseName)
                    .HasName("UQ__Cheese__84652CB626D57205")
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
                    .HasName("UQ__Crust__3598F91266472975")
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

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__CD65CB854250E9FD");

                entity.ToTable("Customers", "PizzaBox");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Customer__F3DBC5725F0477F1")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
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

            modelBuilder.Entity<OrderPizzasMap>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.PizzaId })
                    .HasName("PK__OrderPiz__6372EBF7438AF3FF");

                entity.ToTable("OrderPizzasMap", "PizzaBox");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPizzasMap)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderPizz__order__1EA48E88");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderPizzasMap)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderPizz__pizza__1F98B2C1");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__465962295E0E566D");

                entity.ToTable("Orders", "PizzaBox");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__customer__05D8E0BE");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__Orders__restaura__06CD04F7");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PizzaBox");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.CheeseId).HasColumnName("cheese_id");

                entity.Property(e => e.CrustId).HasColumnName("crust_id");

                entity.Property(e => e.PizzaName)
                    .HasColumnName("pizza_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTotal)
                    .HasColumnName("price_total")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SauceId).HasColumnName("sauce_id");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.HasOne(d => d.Cheese)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CheeseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Cheese");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Crust");

                entity.HasOne(d => d.Sauce)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SauceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Sauce");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Size");
            });

            modelBuilder.Entity<PizzaToppingsMap>(entity =>
            {
                entity.HasKey(e => new { e.PizzaId, e.ToppingId })
                    .HasName("PK__PizzaTop__23F97C03DDDBD263");

                entity.ToTable("PizzaToppingsMap", "PizzaBox");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.ToppingId).HasColumnName("topping_id");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToppingsMap)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__pizza__22751F6C");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzaToppingsMap)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__toppi__236943A5");
            });

            modelBuilder.Entity<RestaurantPizzasMap>(entity =>
            {
                entity.HasKey(e => new { e.RestaurantId, e.PizzaId })
                    .HasName("PK__Restaura__1E24234FDB615763");

                entity.ToTable("RestaurantPizzasMap", "PizzaBox");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.RestaurantPizzasMap)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__pizza__2739D489");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantPizzasMap)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__resta__2645B050");
            });

            modelBuilder.Entity<Restaurants>(entity =>
            {
                entity.HasKey(e => e.RestaurantId)
                    .HasName("PK__Restaura__3B0FAA91F7D7CBD4");

                entity.ToTable("Restaurants", "PizzaBox");

                entity.HasIndex(e => e.RestaurantName)
                    .HasName("UQ__Restaura__6B1FCEB72D6DEA19")
                    .IsUnique();

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.RestaurantMarkup)
                    .HasColumnName("restaurant_markup")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasColumnName("restaurant_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sauce>(entity =>
            {
                entity.ToTable("Sauce", "PizzaBox");

                entity.HasIndex(e => e.SauceName)
                    .HasName("UQ__Sauce__1D98A6C35EB3EE11")
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

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "PizzaBox");

                entity.HasIndex(e => e.Size1)
                    .HasName("UQ__Size__2F837EEC3676A4B8")
                    .IsUnique();

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.PriceMultiplier).HasColumnName("price_multiplier");

                entity.Property(e => e.Size1)
                    .IsRequired()
                    .HasColumnName("size")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.HasKey(e => e.ToppingId)
                    .HasName("PK__Toppings__141E1E062425131A");

                entity.ToTable("Toppings", "PizzaBox");

                entity.HasIndex(e => e.ToppingName)
                    .HasName("UQ__Toppings__89BB94EB1778F4FC")
                    .IsUnique();

                entity.Property(e => e.ToppingId).HasColumnName("topping_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.ToppingName)
                    .IsRequired()
                    .HasColumnName("topping_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
