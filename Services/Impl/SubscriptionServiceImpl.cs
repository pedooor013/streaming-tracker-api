using StreamingSubscriptionTrackerAPI.Models;
using StreamingSubscriptionTrackerAPI.Models.Context;
using StreamingSubscriptionTrackerAPI.DTOs;

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
        public List<SubscriptionResponseDTO> GetAll() => _context.Subscriptions.Select(s => ToResponseDTO(s)).ToList();
        public SubscriptionResponseDTO GetById(int id)
        {
            var subscription = _context.Subscriptions.Find(id);
            
            if (subscription == null) throw new ArgumentException($"Subscription with id {id} not found.");
            
            return ToResponseDTO(subscription);
        }

        public List<SubscriptionResponseDTO> GetSubscriptionFromCategory(int idCategory)
        {
            var subscriptions = _context.Subscriptions.Where(s => s.IdCategory == idCategory).ToList();

            return subscriptions.Select(ToResponseDTO).ToList();
        }

        //POST
        public SubscriptionResponseDTO Create(SubscriptionRequestDTO dto)
        {
            var subscription = new Subscription
            {
                Name = dto.Name,
                Price = dto.Price,
                DateToPaid = dto.DateToPaid,
                IdCategory = dto.IdCategory
            };
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();

            return ToResponseDTO(subscription);
        }

        //PUT
        public SubscriptionResponseDTO Update(int id, SubscriptionRequestDTO dto)
        {
            var existingSubscription = _context.Subscriptions.Find(id);

            if(existingSubscription == null) throw new ArgumentException($"Subscription with id {id} not found.");
            
            existingSubscription.Name = dto.Name;
            existingSubscription.Price = dto.Price;
            existingSubscription.DateToPaid = dto.DateToPaid;
            existingSubscription.IdCategory = dto.IdCategory;

            _context.SaveChanges();

            return ToResponseDTO(existingSubscription);
        }

        //DELETE
        public void Delete(int id)
        {
            var existingSubscription = _context.Subscriptions.Find(id);
            
            if (existingSubscription == null) throw new ArgumentException($"Subscription with id {id} not found.");
            
            _context.Subscriptions.Remove(existingSubscription);
            _context.SaveChanges();
        }

        //DTO Utils
        private SubscriptionResponseDTO ToResponseDTO(Subscription subscription)
        {
            var category = _context.SubscriptionCategories.Find(subscription.IdCategory);

            return new SubscriptionResponseDTO
            {
                Id = subscription.Id,
                Name = subscription.Name,
                Price = subscription.Price, 
                DateToPaid = subscription.DateToPaid,
                IdCategory = subscription.IdCategory,
                CategoryName = category?.Name
            };
        }




    }
}
