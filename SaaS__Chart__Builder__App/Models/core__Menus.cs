namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class core__Menus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public core__Menus()
        {
            Dashboard__Chart____88____core__Menus = new HashSet<Dashboard__Chart____88____core__Menus>();
        }

        [Key]
        public Guid ID_ { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dashboard__Chart____88____core__Menus> Dashboard__Chart____88____core__Menus { get; set; }
    }
}
