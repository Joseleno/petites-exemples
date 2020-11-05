using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumDePhotographies.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        
        [Required(ErrorMessage ="Champs requis")]
        [StringLength(50, ErrorMessage ="Jusqu'à 50")]
        public string Nom { get; set; }
        
        public string PhotoCouverture { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Champs requis")]
        public DateTime Debut { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Champs requis")]
        public DateTime Fin { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
