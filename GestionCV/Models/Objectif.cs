using System.ComponentModel.DataAnnotations;

namespace GestionCV.Models
{
    public class Objectif
    {
        public int ObjectifId { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(1000, ErrorMessage = "Seulement 1000 caractères")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }

    }
}
