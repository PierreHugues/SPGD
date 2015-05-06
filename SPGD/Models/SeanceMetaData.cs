using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPGD.Models
{
    [MetadataType(typeof(SeanceMetaData))]
    public partial class Seance
    {
        internal sealed class SeanceMetaData
        {
            [Key]
            public int SeanceID { get; set; }

            public int AgentID { get; set; }
            public int MaisonID {get; set;}
            public string StatusSeance { get; set; }
            public int TypeForfaitDeBaseVoulu {get;set;}
            public string Commentaire { get; set; }
        }
    }
}