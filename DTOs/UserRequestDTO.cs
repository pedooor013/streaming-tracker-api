using System.ComponentModel.DataAnnotations;

namespace StreamingSubscriptionTrackerAPI.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Actived { get; set; }

    }
}
