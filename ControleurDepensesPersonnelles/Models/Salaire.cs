using System.ComponentModel.DataAnnotations;

namespace ControleurDepensesPersonnelles.Models
{
    public class Salaire
    {
        public int SalaireId { get; set; }
        public int MoisId { get; set; }
        public Mois Mois { get; set; }
        
        [Required(ErrorMessage = "Champs requis.")]
        [Range(0,double.MaxValue,ErrorMessage = "Seulement valeur positive")]
        public double Valeur { get; set; }
    }
}
