using ApiDataBaseFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiDataBaseFirst.DataBaseContext
{
    public class OnlineStoreDBContext : DbContext
    {
        public OnlineStoreDBContext(DbContextOptions<OnlineStoreDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB;initial catalog=OnlineStore;user id=sa;password=ideal2s;Trust Server Certificate=True");
            }
        }
    }
}
