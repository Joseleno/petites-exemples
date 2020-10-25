using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkRelationships.Models
{
    public class Telephone
    {
        public int TelephoneId { get; set; }
        public string Numero { get; set; }

        public Personne Personne { get; set; }
    }
}
