using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppplication_01.Models
{
    public class Voiture
    {
        public int VoitureId { get; set; }
        public string Fabricant { get; set; }
        public string Modele { get; set; }
        public int Anne { get; set; }
    }
}
