using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPGD.Regles_Affaires
{
    public class PhotoExtensionValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            if (value != null)
            {
                String extention = value.ToString().Substring(value.ToString().LastIndexOf('.'));

                if (extention != ".png" && extention != ".jpg" && extention != ".jpeg")
                {
                    var errorMessage = "Seuls les formats .png, .jpg et .jpeg peuvent êtres téléversés";
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}