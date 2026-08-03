using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingSubscriptionTrackerAPI.Models
{
    public class SubscriptionCategory
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
        [Column("id_user")]
        public long IdUser { get; set; }

        [ForeignKey(nameof(IdUser))]
        public virtual UserRequestDto User { get; set; }
    }
}
