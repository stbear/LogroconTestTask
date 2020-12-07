using LogroconTestTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogroconTestTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Navigation properties
            modelBuilder.Entity<Client>().HasMany(x => x.Orders).WithOne(x => x.Client).IsRequired();
            modelBuilder.Entity<Order>().HasMany(x => x.Positions).WithOne(x => x.Order).IsRequired();
            modelBuilder.Entity<OrderPosition>().HasKey(x => new { x.OrderNumber, x.GoodNumber });
            modelBuilder.Entity<OrderPosition>().HasOne(x => x.Good).WithMany().IsRequired();

            // Decimal precision
            modelBuilder.Entity<Order>().Property(x => x.TotalPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Good>().Property(x => x.Price).HasPrecision(18, 2);
            modelBuilder.Entity<OrderPosition>().Property(x => x.Price).HasPrecision(18, 2);

            // Identity
            modelBuilder.Entity<Client>().Property(x => x.Number).ValueGeneratedOnAdd();
            modelBuilder.Entity<Good>().Property(x => x.Number).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().Property(x => x.Number).ValueGeneratedOnAdd();

            // Seed data
            modelBuilder.Entity<Client>().HasData(new Client { Number = 1, Name = "Первый не вип", Address = "Калуга улица Одна" });
            modelBuilder.Entity<Client>().HasData(new Client { Number = 2, Name = "Второй не вип", Address = "Калуга улица Другая" });
            modelBuilder.Entity<Client>().HasData(new Client { Number = 3, Name = "Третий вип", Address = "Калуга улица Хорошая", VIP = true });
            modelBuilder.Entity<Client>().HasData(new Client { Number = 4, Name = "Четвёртый тоже вип", Address = "Калуга улица Лучшая", VIP = true });
            modelBuilder.Entity<Client>().HasData(new Client { Number = 5, Name = "Пятый не вип", Address = "Калуга улица Обычная" });

            modelBuilder.Entity<Good>().HasData(new Good { Number = 1, Name = "Огурец", Price = 100 });
            modelBuilder.Entity<Good>().HasData(new Good { Number = 2, Name = "Молодец", Price = 999.99m });
            modelBuilder.Entity<Good>().HasData(new Good { Number = 3, Name = "Леденец", Price = 33.33m });
            modelBuilder.Entity<Good>().HasData(new Good { Number = 4, Name = "Холодец", Price = 650 });
            modelBuilder.Entity<Good>().HasData(new Good { Number = 5, Name = "Меч-кладенец", Price = 12345678 });
        }
    }
}
