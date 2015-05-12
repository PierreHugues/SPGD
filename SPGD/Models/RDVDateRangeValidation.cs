using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SPGD.DAL;

namespace SPGD.Models
{
    public class RDVDateRangeValidation:ValidationAttribute
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


        public RDVDateRangeValidation()
            : base()
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {

                DateTime dateTimeAVerifier = (DateTime)value;

                RendezVou RDV = (RendezVou)validationContext.ObjectInstance;
                RendezVou RDV_BD = unitOfWork.RendezVousRepository.GetRendezVousByID(RDV.RendezVouID);

                if (RDV_BD == null || dateTimeAVerifier != RDV_BD.DateHeureRendezVous)
                {
                    if (dateTimeAVerifier <= DateTime.Today.AddDays(1) || dateTimeAVerifier >= DateTime.Today.AddDays(15))
                    {
                        var errorMessage = "La date de rendez-vous pour une séance de photo doit être comprise entre la date du jour + 1 et date du jour + 15 (incluse)";
                        return new ValidationResult(errorMessage);
                    }

                    //if()
                    //{
                    //    var errorMessage = "o	La date pour un rendez-vous doit être unique pour date, horaire, photographe.";
                    //    return new ValidationResult(errorMessage);
                    //}

                    //if (dateTimeAVerifier.Date)
                    //{
                    //    var errorMessage = "o	Pour la même date et le même photographe il devra y avoir un minimum de 4h entre 2 rendez-vous";
                    //    return new ValidationResult(errorMessage);
                    //}
                }
            }
            return ValidationResult.Success;
        }
    }
}