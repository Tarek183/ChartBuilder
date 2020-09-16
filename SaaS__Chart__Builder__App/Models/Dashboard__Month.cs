namespace SaaS__Chart__Builder__App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dashboard__Month
    {
        [Key]
        public Guid ID_ { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int? Numero { get; set; }
    }
}
