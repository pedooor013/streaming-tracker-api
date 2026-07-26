using StreamingSubscriptionTrackerAPI.Models;
using StreamingSubscriptionTrackerAPI.Models.Context;
using Microsoft.AspNetCore.Http.HttpResults;

namespace StreamingSubscriptionTrackerAPI.Services.Impl
{
    public class SubscriptionServiceImpl : ISubscriptionService
    {
        private MSSQLContext _context;

        public SubscriptionServiceImpl(MSSQLContext context)
        {
            _context = context;
        }

        //GET
        public Subscription GetById(int id) => _context.Subscriptions.Find(id);
        public List<Subscription> GetAll() => _context.Subscriptions.ToList();
        public List<Subscription> GetSubscriptionFromCategory(int idCategory) => _context.Subscriptions.Where(s => s.IdCategory == idCategory).ToList();

        //POST
        public Subscription Create(Subscription subscription)
        {
            _context.Add(subscription);
            _context.SaveChanges();
            return subscription;
        }

        //PUT
        public Subscription Update(int id, Subscription subscription)
        {
            var existingSubscription = _context.Subscriptions.Find(id);
            if (existingSubscription == null) throw new ArgumentException("Subscription not found");

            _context.Entry(existingSubscription).CurrentValues.SetValues(subscription);
            _context.SaveChanges();
            return subscription;
        }

        //DELETE
        public void Delete(int id)
        {
            var existingSubscription = _context.Subscriptions.Find(id);
            if (existingSubscription == null) throw new ArgumentException("Subscription not found");

            _context.Remove(existingSubscription);
            _context.SaveChanges();
        }
    }
}
