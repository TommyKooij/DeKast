using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace De_Kast.Models
{
    public class Cursus
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Naam kan niet langer zijn dan 50 karakters.")]
        [Display(Name = "Naam")]
        [Column("Naam")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Dag")]
        [Column("Dag")]
        public string Dag { get; set; }

        [Required]
        [Display(Name = "Begin Tijd")]
        public TimeSpan BeginTijd { get; set; }

        [Required]
        [Display(Name = "Eind Tijd")]
        public TimeSpan EindTijd { get; set; }
    }
}
