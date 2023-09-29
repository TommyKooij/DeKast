using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace De_Kast.Models
{
    public class Personeelslid
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Voornaam kan niet langer zijn dan 50 karakters.")]
        [Display(Name = "Voornaam")]
        [Column("Voornaam")]
        public string Voornaam { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Achternaam kan niet langer zijn dan 50 karakters.")]
        [Display(Name = "Achternaam")]
        [Column("Achternaam")]
        public string Achternaam { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Functie kan niet langer zijn dan 50 karakters.")]
        [Display(Name = "Functie")]
        public string Functie { get; set; }

        [Required]
        [Display(Name = "Telefoon")]
        public int Telefoonnummer { get; set; }
    }
}
