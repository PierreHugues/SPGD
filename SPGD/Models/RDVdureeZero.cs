using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SPGD.DAL;

namespace SPGD.Models
{
    public class RDVdureeZero : ValidationAttribute
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //RendezVou RDV = (RendezVou)validationContext.ObjectInstance;
            //RendezVou RDV_BD = unitOfWork.RendezVousRepository.GetRendezVousByID(RDV.RendezVouID);
            if (value != null)
            {
                if ((int)value <= 0)
                {
                    var errorMessage = "La durée de rendez-vous doit être supérieure à 0";
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}