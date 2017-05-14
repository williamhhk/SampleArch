namespace SampleArch.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class Country : Entity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Person = new HashSet<Person>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual IEnumerable<Person> Person { get; set; }
    }
}
