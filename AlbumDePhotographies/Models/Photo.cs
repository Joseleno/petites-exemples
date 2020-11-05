using System.ComponentModel.DataAnnotations;

namespace AlbumDePhotographies.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        
        [Required(ErrorMessage ="Champs requis")]
        public string Lien { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
