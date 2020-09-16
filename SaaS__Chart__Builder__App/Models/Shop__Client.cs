namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shop__Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop__Client()
        {
            Shop__Commande = new HashSet<Shop__Commande>();
        }

        [Key]
        public Guid ID_ { get; set; }

        [StringLength(50)]
        public string First__Name { get; set; }

        [StringLength(50)]
        public string Last__Name { get; set; }

        [StringLength(100)]
        public string Adress { get; set; }

        [StringLength(50)]
        public string GSM { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop__Commande> Shop__Commande { get; set; }
    }
}
