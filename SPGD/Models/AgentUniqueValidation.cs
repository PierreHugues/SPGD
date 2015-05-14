using SPGD.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPGD.Models
{
    public class AgentUniqueValidation : ValidationAttribute
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public AgentUniqueValidation()
            : base()
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {

                var agentsPresent = unitOfWork.AgentRepository.GetAgents();   
  
                Agent agentAjout = (Agent)validationContext.ObjectInstance;

                //var resultatRecherche = from agent in agentsPresent
                //              where agent.Nom == agentAjout.Nom && agent.Prenom == agentAjout.Prenom &&
                //                    agent.Telephone1 == agentAjout.Telephone1   
                //              select agent;

                var resultatRecherche = (from agent in agentsPresent
                                        where agent.Nom.Contains(agentAjout.Nom) &&
                                        agent.Prenom.Contains(agentAjout.Prenom) &&
                                        agent.Telephone1.Contains(agentAjout.Telephone1)
                                        select agent).Count();

                if (resultatRecherche != 0)
                {
                    var errorMessage = "Il y a déjà un agent ayant ce Nom, Prénom et Numéro de Téléphone d'enregistrer";
                    return new ValidationResult(errorMessage);
                }
               
            }
            return ValidationResult.Success;
        }

    }
}