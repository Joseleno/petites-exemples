using GestionCV.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class Langue
    {
        public int LangueId { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        public string Nom { get; set; }
        public Niveau Niveau { get; set; }
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
