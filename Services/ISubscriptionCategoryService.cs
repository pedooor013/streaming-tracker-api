using StreamingSubscriptionTrackerAPI.Models;

namespace StreamingSubscriptionTrackerAPI.Services
{
    public interface ISubscriptionCategoryService
    {
        //GET
        SubscriptionCategory GetById(int id);
        SubscriptionCategory GetByName(string name);
        List<SubscriptionCategory> GetAll();
        //POST
        SubscriptionCategory Create(SubscriptionCategory subscriptionCategory);
        //PUT
        SubscriptionCategory Update(int id, SubscriptionCategory subscriptionCategory);
        //DELETE
        void Delete(int id);

    }
}
