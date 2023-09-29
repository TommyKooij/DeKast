using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace De_Kast.Models
{
    public class Abonnement
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Naam van Type kan niet langer zijn dan 50 karakters.")]
        [Display(Name = "Type")]
        [Column("Type")]
        public string Type { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Naam kan niet langer zijn dan 50 karakters.")]
        [Display(Name = "Prijs")]
        public double Prijs { get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name = "Aangeschaft")]
        public bool Aangeschaft { get; set; }
    }
}
