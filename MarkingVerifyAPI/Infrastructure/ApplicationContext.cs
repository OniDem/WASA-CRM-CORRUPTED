using MarkingVerifyAPI.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace MarkingVerifyAPI.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AlcoholLabelEntity> AlcoholLabels { get; set; }
        public DbSet<CigaretteLabelEntity> CigaretteLabels { get; set; }
        public DbSet<MilkLabelEntity> MilkLabels { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlcoholLabelEntity>(entity =>
            {
                entity.HasIndex(e => e.Label).IsUnique();
            });

            builder.Entity<CigaretteLabelEntity>(entity =>
            {
                entity.HasIndex(e => e.Label).IsUnique();
            });
        }
    }
}
