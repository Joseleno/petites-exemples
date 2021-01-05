using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Enums
{
    public enum Niveau
    {
        [Display(Name = "Basique")]
        Basique = 0,
        [Display(Name = "Intermédiare")]
        Intermédiare = 1,
        [Display(Name = "Avancée")]
        Avancée = 2
    }
}
