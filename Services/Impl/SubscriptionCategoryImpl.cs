using StreamingSubscriptionTrackerAPI.DTOs;
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
        public List<SubscriptionCategoryResponseDTO> GetAll() => _context.SubscriptionCategories.Select(sc => ToResponseDTO(sc)).ToList();
        public SubscriptionCategoryResponseDTO GetById(int id)
        {
            var subscriptionCategory = _context.SubscriptionCategories.FirstOrDefault(sc => sc.Id == id);
            
            if(subscriptionCategory == null)
                throw new ArgumentException("Subscription category not found");

            return ToResponseDTO(subscriptionCategory);
        }

        public SubscriptionCategoryResponseDTO GetByName(string name)
        {
            var subscriptionCategory = _context.SubscriptionCategories.FirstOrDefault(sc => sc.Name == name);

            if(subscriptionCategory == null)
                throw new ArgumentException("Subscription category not found");

            return ToResponseDTO(subscriptionCategory);
        }

        //POST
        public SubscriptionCategoryResponseDTO Create(SubscriptionCategoryRequestDTO dto)
        {
            var subscriptionCategory = new SubscriptionCategory
            {
                Name = dto.Name
            };

            _context.SubscriptionCategories.Add(subscriptionCategory);
            _context.SaveChanges();

            return ToResponseDTO(subscriptionCategory);
        }



        //PUT
        public SubscriptionCategoryResponseDTO Update(int id, SubscriptionCategoryRequestDTO dto)
        {
            var existingSubscriptionCategory = _context.SubscriptionCategories.Find(id);

            if(existingSubscriptionCategory == null)
                throw new ArgumentException("Subscription category not found");

            existingSubscriptionCategory.Name = dto.Name;

            _context.SaveChanges();

            return ToResponseDTO(existingSubscriptionCategory);
        }

        //DELETE
        public void Delete(int id)
        {
            var existingSubscriptionCategory = _context.SubscriptionCategories.Find(id);

            if (existingSubscriptionCategory == null)
                throw new ArgumentException("Subscription category not found");

            _context.SubscriptionCategories.Remove(existingSubscriptionCategory);
            _context.SaveChanges();
        }

        private SubscriptionCategoryResponseDTO ToResponseDTO(SubscriptionCategory subscriptionCategory)
        {
            return new SubscriptionCategoryResponseDTO
            {
                Id = (int)(long)subscriptionCategory.Id,
                Name = subscriptionCategory.Name
            };
        }

    }
}
