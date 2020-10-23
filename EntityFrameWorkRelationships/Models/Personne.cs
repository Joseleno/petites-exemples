using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkRelationships.Models
{
    public class Personne
    {
        public int PersonneId { get; set; }
        
        public string Nom { get; set; }

        public DateTime DateNaissance { get; set; }
        
        public double? Poids { get; set; }

        public int? AdresseId { get; set; }
        public Adresse Adresse { get; set; }
    }
}
