namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dashboard__Chart__Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dashboard__Chart__Property()
        {
            Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property = new HashSet<Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property>();
        }

        [Key]
        public Guid ID_ { get; set; }

        public Guid? ID____Dashboard__Chart { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public bool IsSelected { get; set; }

        public virtual Dashboard__Chart Dashboard__Chart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property> Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property { get; set; }
    }
}
