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
    
    public partial class Seance
    {
        public int SeanceID { get; set; }
        public int AgentID { get; set; }
        public int MaisonID { get; set; }
        public string StatusSeance { get; set; }
        public int TypeForfaitDeBaseVoulu { get; set; }
        public int NbPanoramasVoulu { get; set; }
        public bool VisiteImmersive { get; set; }
        public Nullable<decimal> FraisDeBaseReel { get; set; }
        public Nullable<decimal> FraisDeDeplacement { get; set; }
        public string Commentaire { get; set; }
        public Nullable<decimal> FraisAdditionnel { get; set; }
        public System.DateTime DateDebutDeSeance { get; set; }
        public Nullable<System.DateTime> DateRemisePhoto { get; set; }
        public Nullable<System.DateTime> DateRemisePanoramas { get; set; }
        public Nullable<System.DateTime> DateDePaymentRecu { get; set; }
        public Nullable<decimal> FraisPanoramas { get; set; }
        public Nullable<decimal> FraisVisiteImmersive { get; set; }
        public Nullable<decimal> FraisSeanceTotal { get; set; }
    
        public virtual RendezVou RendezVou { get; set; }
    }
}
