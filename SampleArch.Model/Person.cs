namespace SampleArch.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person : AuditableEntity<long>
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }


        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
