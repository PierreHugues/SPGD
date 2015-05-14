using SPGD.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPGD.Models
{
    public class RDVModifierNbPhotoValidation : ValidationAttribute
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public RDVModifierNbPhotoValidation()
            : base()
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                int valeurNbPhoto = (int)value;

                RendezVou RDV = (RendezVou)validationContext.ObjectInstance;
                RendezVou RDV_BD = unitOfWork.RendezVousRepository.GetRendezVousByID(RDV.RendezVouID);

                if (RDV_BD != null)
                {
                    if (valeurNbPhoto != RDV_BD.NbPhotoReel)
                    {
                        if (DateTime.Now < RDV_BD.DateHeureRendezVous)
                        {
                            var errorMessage = "Il est impossible de modifier le nombre de photos prises avant la date de rendez-vous.";
                            return new ValidationResult(errorMessage);
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}