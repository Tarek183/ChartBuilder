namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shop__Commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop__Commande()
        {
            Shop__Tarif____88____Shop__Product____88____Shop__Commande = new HashSet<Shop__Tarif____88____Shop__Product____88____Shop__Commande>();
        }

        [Key]
        public Guid ID_ { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? Date__Commande { get; set; }

        public DateTime? Heure__Commande { get; set; }

        public Guid? ID____Shop__Client { get; set; }

        public Guid? ID____Dashboard__Month { get; set; }

        public virtual Shop__Client Shop__Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop__Tarif____88____Shop__Product____88____Shop__Commande> Shop__Tarif____88____Shop__Product____88____Shop__Commande { get; set; }
    }
}
