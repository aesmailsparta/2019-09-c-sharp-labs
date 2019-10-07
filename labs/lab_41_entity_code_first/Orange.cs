namespace lab_41_entity_code_first
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orange")]
    public partial class Orange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orange()
        {
            Batches = new HashSet<Batch>();
        }

        public int OrangeID { get; set; }

        [StringLength(50)]
        public string OrangeName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateHarvested { get; set; }

        public bool? IsLuxuryGrade { get; set; }

        public int? CategoryID { get; set; }

        public int MaxOrangesPerCrate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batch> Batches { get; set; }

        public virtual Category Category { get; set; }
    }
}
