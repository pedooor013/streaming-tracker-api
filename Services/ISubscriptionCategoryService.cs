using StreamingSubscriptionTrackerAPI.DTOs;

namespace StreamingSubscriptionTrackerAPI.Services
{
    public interface ISubscriptionCategoryService
    {
        //GET
        SubscriptionCategoryResponseDTO GetById(int id);
        SubscriptionCategoryResponseDTO GetByName(string name);
        List<SubscriptionCategoryResponseDTO> GetAll();
        //POST
        SubscriptionCategoryResponseDTO Create(SubscriptionCategoryRequestDTO subscriptionCategory);
        //PUT
        SubscriptionCategoryResponseDTO Update(int id, SubscriptionCategoryRequestDTO subscriptionCategory);
        //DELETE
        void Delete(int id);

    }
}
