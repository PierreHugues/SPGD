using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPGD.Models
{
    [MetadataType(typeof(RendezVouMetaData))]
    public partial class RendezVou
    {
        internal sealed class RendezVouMetaData
        {
            public bool Completee { get; set; }
            [DataType(DataType.DateTime)]
            [RDVDateRangeValidation]
            public System.DateTime DateHeureRendezVous { get; set; }

            [RDVdureeZero]
            public int DureeRendezVousReel { get; set; }

            [RDVModifierNbPhotoValidation]
            [RDVnbPhotoZero]
            public int NbPhotoReel { get; set; }
            public string Commentaire { get; set; }

            [Key, ForeignKey("Seance")]
            public int RendezVouID { get; set; }

        }
    }
}