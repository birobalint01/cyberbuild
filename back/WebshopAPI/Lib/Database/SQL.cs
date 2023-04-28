using Microsoft.EntityFrameworkCore;

namespace WebshopAPI.Lib.Database
{
    public class SQL : DbContext
    {
        public SQL() : base(new DbContextOptionsBuilder().UseSqlServer(Program.ConnectionString).Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey("Email", "RoleID");
            modelBuilder.Entity<OrderedProduct>().HasKey("OrderID", "ProductID");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
