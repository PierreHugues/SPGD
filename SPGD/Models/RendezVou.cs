//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPGD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RendezVou
    {
        public bool Completee { get; set; }
        public System.DateTime DateHeureRendezVous { get; set; }
        public int DureeRendezVousReel { get; set; }
        public int NbPhotoReel { get; set; }
        public int VisiteVirtuelleNbPanoramas { get; set; }
        public bool VisiteImmersiveEstFaite { get; set; }
        public string Commentaire { get; set; }
        public int RendezVouID { get; set; }
    
        public virtual Seance Seance { get; set; }
    }
}
