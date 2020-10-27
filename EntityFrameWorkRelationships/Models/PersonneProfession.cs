using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkRelationships.Models
{
    public class PersonneProfession
    {
        public int PersonneId { get; set; }
        public  Personne Personne { get; set; }

        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }

        public decimal? Salaire { get; set; }
    }
}
