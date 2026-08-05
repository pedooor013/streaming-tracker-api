using System.ComponentModel.DataAnnotations;

namespace StreamingSubscriptionTrackerAPI.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
