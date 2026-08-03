using Microsoft.EntityFrameworkCore;
namespace StreamingSubscriptionTrackerAPI.Models.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.IdCategory)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubscriptionCategory>()
                .HasOne(sc => sc.User)
                .WithMany()
                .HasForeignKey(sc => sc.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}