using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkRelationships.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }
        public string Title { get; set; }
        public ICollection<PersonneProfession> PersonneProfessions { get; set; }
    }
}
