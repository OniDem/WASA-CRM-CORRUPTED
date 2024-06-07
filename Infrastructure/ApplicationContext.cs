using Core.Entity;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ReceiptEntity> Receipts { get; set; }

        public DbSet<ShiftEntity> Shifts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShiftEntity>(entity =>
            {
                entity.HasIndex(e => e.Closed).AreNullsDistinct();
                entity.HasIndex(e => e.ClosedBy).AreNullsDistinct();
                entity.HasIndex(e => e.CloseDate).AreNullsDistinct();
                entity.HasIndex(e => e.Cash).AreNullsDistinct();
                entity.HasIndex(e => e.CashBox).AreNullsDistinct();
                entity.HasIndex(e => e.CashBoxOperations).AreNullsDistinct();
                entity.HasIndex(e => e.Acquiring).AreNullsDistinct();
                entity.HasIndex(e => e.AcquiringApproved).AreNullsDistinct();
                entity.HasIndex(e => e.Total).AreNullsDistinct();
                entity.HasIndex(e => e.ReceiptsList).AreNullsDistinct();

            });
        }
    }
}
