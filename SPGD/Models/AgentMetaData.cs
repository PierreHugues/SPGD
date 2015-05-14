using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPGD.Models
{
    [MetadataType(typeof(AgentMetaData))]
    public partial class Agent
    {
        internal sealed class AgentMetaData
         {
             [Key]
             public int AgentID { get; set; }

             [Required]
             [MaxLength(50)]
             [AgentUniqueValidation]
             public string Nom { get; set; }


             [Required]
             [MaxLength(50)]
             [AgentUniqueValidation]
             public string Prenom { get; set; }


             [Required]
             [MaxLength(10)]
             [RegularExpression("([0-9]+)", ErrorMessage = "Ce champ doit contenir que des chiffres")]
             [AgentUniqueValidation]
             public string Telephone1 { get; set; }


             [Required]
             [DataType(DataType.EmailAddress, ErrorMessage = "Veuillez entrer un format d'adresse email valide")]
             public string Courriel1 { get; set; }
             
         }
    }
}