using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class InformationLogin
    {
        public int InformationLoginId { get; set; }
        public string AdresseIp { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
