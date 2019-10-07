namespace lab_41_entity_code_first
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Batch")]
    public partial class Batch
    {
        public int BatchID { get; set; }

        public int? OrangeID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DispatchDate { get; set; }

        public virtual Orange Orange { get; set; }
    }
}
