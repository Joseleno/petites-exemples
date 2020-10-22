using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Sondage.Models
{
    public class Cryptocurrency
    {
        public int CryptocurrencyId { get; set; }
        
        public string Nom { get; set; }
        
        public int Quantite { get; set; }

        [NotMapped]
        public bool Selectionne { get; set; }
    }
}
