using System.ComponentModel.DataAnnotations;

namespace GestionCV.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        [EmailAddress(ErrorMessage = "Courriel invalide")]
        public string Courriel { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(20, ErrorMessage = "Seulement 20 caractères")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
    }
}