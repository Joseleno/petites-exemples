using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class TypeCours
    {
        public int TypeCoursId { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        public string Type { get; set; }
        public ICollection<Formation> Formations { get; set; }

    }
}
