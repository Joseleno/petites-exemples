using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Tache
    {
        public int TacheId { get; set; }

        [Required(ErrorMessage = "champs requis")]
        [StringLength(50, ErrorMessage = "Nombre de caractères 50")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "champs requis")]
        [StringLength(500, ErrorMessage = "Nombre de caractères 500")]
        public string Description { get; set; }

        [Required(ErrorMessage = "champs requis")]
        [DataType(DataType.DateTime)]       
        public DateTime Debut { get; set; }

        [Required(ErrorMessage = "champs requis")]
        [DataType(DataType.DateTime)]
        public DateTime Fin { get; set; }

        [Required(ErrorMessage = "champs requis")]
        [StringLength(50, ErrorMessage = "Nombre de caractères 5")]
        public string Priorite { get; set; }
    }
}
