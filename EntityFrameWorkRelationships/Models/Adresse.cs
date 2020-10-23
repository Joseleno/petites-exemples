using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkRelationships.Models
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        public int NumeroCivique { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }

        public Personne Personne { get; set; }
    }
}
