namespace lab_41_entity_code_first
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrangeModel : DbContext
    {
        public OrangeModel()
            : base("name=OrangeModel2")
        {
        }

        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Orange> Oranges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
