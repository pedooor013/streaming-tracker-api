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
        [Column("name", TypeName = "varcha(80)")]
        [MaxLength(80)]
        public string Name { get; set; }
        //Aqui vai ser aplicado a verificação se existe essa category antes de ser criada!
    }
}
