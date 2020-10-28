using System.ComponentModel.DataAnnotations;

namespace ControleurDepensesPersonnelles.Models
{
    public class Depense
    {
        public int DepenseId { get; set; }

        public int MoisId { get; set; }
        public Mois Mois { get; set; }
        public int TypeDepenseId { get; set; }
        public TypeDepense TypeDepense { get; set; }

        [Required(ErrorMessage = "Champs requis.")]
        [Range(0, double.MaxValue, ErrorMessage = "Seulement valeur positive")]
        public double Valeur { get; set; }
    }
}
