namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shop__Tarif____88____Shop__Product____88____Shop__Commande
    {
        [Key]
        public Guid ID_ { get; set; }

        public Guid? ID____Shop__Commande { get; set; }

        public Guid? ID____Shop__Product { get; set; }

        public Guid? ID____Shop__Tarif { get; set; }

        [StringLength(10)]
        public string Quantite { get; set; }

        public virtual Shop__Commande Shop__Commande { get; set; }

        public virtual Shop__Product Shop__Product { get; set; }

        public virtual Shop__Tarif Shop__Tarif { get; set; }
    }
}
