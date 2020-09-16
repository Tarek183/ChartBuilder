namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shop__Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop__Product()
        {
            Shop__Tarif____88____Shop__Product____88____Shop__Commande = new HashSet<Shop__Tarif____88____Shop__Product____88____Shop__Commande>();
        }

        [Key]
        public Guid ID_ { get; set; }

        [StringLength(50)]
        public string Product__Name { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public decimal? Poids { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop__Tarif____88____Shop__Product____88____Shop__Commande> Shop__Tarif____88____Shop__Product____88____Shop__Commande { get; set; }
    }
}
