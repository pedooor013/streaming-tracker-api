using StreamingSubscriptionTrackerAPI.Models;

namespace StreamingSubscriptionTrackerAPI.Services
{
    public interface ISubscriptionService
    {
        //GET
        Subscription GetById(int id);
        List<Subscription> GetAll();
        List<Subscription> GetSubscriptionFromCategory(int idCategory);

        //POST
        Subscription Create(Subscription subscription);

        //PUT
        Subscription Update(int id, Subscription subscription);

        //DELETE
        void Delete(int id);
    }
}
