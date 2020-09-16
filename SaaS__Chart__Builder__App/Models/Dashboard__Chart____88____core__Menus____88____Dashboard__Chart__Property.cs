namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property
    {
        [Key]
        public Guid ID_ { get; set; }

        public Guid? ID____Dashboard__Chart__Property { get; set; }

        public Guid? ID____Dashboard__Chart____88____core__Menus { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        public virtual Dashboard__Chart____88____core__Menus Dashboard__Chart____88____core__Menus { get; set; }

        public virtual Dashboard__Chart__Property Dashboard__Chart__Property { get; set; }
    }
}
