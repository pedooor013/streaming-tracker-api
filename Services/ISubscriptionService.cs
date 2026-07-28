using StreamingSubscriptionTrackerAPI.DTOs;

namespace StreamingSubscriptionTrackerAPI.Services
{
    public interface ISubscriptionService
    {
        //GET
        SubscriptionResponseDTO GetById(int id);
        List<SubscriptionResponseDTO> GetAll();
        List<SubscriptionResponseDTO> GetSubscriptionFromCategory(int idCategory);

        //POST
        SubscriptionResponseDTO Create(SubscriptionRequestDTO subscription);

        //PUT
        SubscriptionResponseDTO Update(int id, SubscriptionRequestDTO subscription);

        //DELETE
        void Delete(int id);
    }
}
