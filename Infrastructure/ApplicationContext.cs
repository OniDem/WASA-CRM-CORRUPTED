using Core.Entity;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ReceiptEntity> Receipts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) { }
    }
}
