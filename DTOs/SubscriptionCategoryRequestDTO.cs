using System.ComponentModel.DataAnnotations;

namespace StreamingSubscriptionTrackerAPI.DTOs
{
    public class SubscriptionCategoryRequestDTO
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
    }
}
