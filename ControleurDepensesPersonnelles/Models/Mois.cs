using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleurDepensesPersonnelles.Models
{
    public class Mois
    {
        public int MoisId { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [StringLength(15, ErrorMessage = "Seulement 60 caractères")]
        public string Nom { get; set; }
        public ICollection<Depense> Depenses { get; set; }
        public Salaire Salaire { get; set; }
    }
}
