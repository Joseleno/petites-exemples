using Gens.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gens.Validation
{
    
    public class AdulteAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Personne personne = (Personne)validationContext.ObjectInstance;
            if (personne.Age < 18)
            {
                return new ValidationResult("Seulement depuis plus de 18 ans");
            }

            return ValidationResult.Success;
        }
    }
}
