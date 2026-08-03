using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingSubscriptionTrackerAPI.Models
{
    public class Subscription
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        [Column("name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string Name { get; set; }
        
        [Required]
        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [Required]
        [Column("date_to_paid", TypeName = "date")]
        public DateOnly DateToPaid { get; set; }
        
        [Required]
        [Column("id_category")]
        public long IdCategory { get; set; }

        [ForeignKey(nameof(IdCategory))]
        public SubscriptionCategory Category { get; set; }
        
        [Required]
        [Column("id_user")]
        public long IdUser { get; set; }

        [ForeignKey(nameof(IdUser))]
        public UserRequestDto User { get; set; }
    }
}
