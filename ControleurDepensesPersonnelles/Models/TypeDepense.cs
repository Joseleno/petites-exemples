using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleurDepensesPersonnelles.Models
{
    public class TypeDepense
    {
        public int TypeDepenseId { get; set; }
        
        [Required(ErrorMessage ="Champs Oblige")]
        [StringLength(60, ErrorMessage = "Seulement 60 caractères")]
        public string Nom { get; set; }
        public ICollection<Depense> Depenses { get; set; }
    }

    
}
