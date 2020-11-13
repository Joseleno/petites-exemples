using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class TypeCours
    {
        public int TypeCoursId { get; set; }
        public string Type { get; set; }
        public ICollection<Formation> Formations { get; set; }

    }
}
