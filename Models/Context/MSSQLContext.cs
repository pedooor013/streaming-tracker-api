using Microsoft.EntityFrameworkCore;
namespace StreamingSubscriptionTrackerAPI.Models.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }
    }
}