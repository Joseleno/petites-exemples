using GestionCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.ViewModels
{
    public class CurriculumViewModel
    {
        public IEnumerable<Objectif> Objectifs { get; set; }
        public IEnumerable<Formation> Formations { get; set; }
        public IEnumerable<ExperienceProfessionnelle> ExperiencseProfessionnelles { get; set; }
        public IEnumerable<Langue> Langues { get; set; }
    }
}
