using StreamingSubscriptionTrackerAPI.Models;
using StreamingSubscriptionTrackerAPI.Models.Context;

namespace StreamingSubscriptionTrackerAPI.Services.Impl
{
    public class SubscriptionCategoryImpl : ISubscriptionCategoryService
    {
        private MSSQLContext _context;

        public SubscriptionCategoryImpl(MSSQLContext context)
        {
            _context = context;
        }

        //GET
        public SubscriptionCategory GetById(int id) => _context.SubscriptionCategories.Find(id);

        public SubscriptionCategory GetByName(string name) => _context.SubscriptionCategories.FirstOrDefault(sc => sc.Name == name);

        public List<SubscriptionCategory> GetAll() => _context.SubscriptionCategories.ToList();

        //POST
        public SubscriptionCategory Create(SubscriptionCategory subscriptionCategory)
        {
            _context.Add(subscriptionCategory);
            _context.SaveChanges();
            return subscriptionCategory;
        }
        
        //PUT
        public SubscriptionCategory Update(int id, SubscriptionCategory subscriptionCategory)
        {
            var existingSubscriptionCategory = _context.SubscriptionCategories.Find(id);
            if(existingSubscriptionCategory == null) throw new ArgumentException($"SubscriptionCategory with id {id} not found.");

            _context.Entry(existingSubscriptionCategory).CurrentValues.SetValues(subscriptionCategory);
            _context.SaveChanges();
            return subscriptionCategory;
        }
        
        //DELETE
        public void Delete(int id)
        {
            var existingSubscriptionCategory = _context.SubscriptionCategories.Find(id);
            if (existingSubscriptionCategory == null) throw new ArgumentException($"SubscriptionCategory with id {id} not found.");
            _context.Remove(existingSubscriptionCategory);
            _context.SaveChanges();
           
        }
            

    }
}
