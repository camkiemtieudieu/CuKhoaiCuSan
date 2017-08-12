namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PricePolicy")]
    public partial class PricePolicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PricePolicy()
        {
            ObjectCategory = new HashSet<ObjectCategory>();
        }
        [Key]
        public Guid PricePolicyID { get; set; }

        [StringLength(50)]
        public string PricePolicyCode { get; set; }

        [StringLength(150)]
        public string PricePolicyName { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectCategory> ObjectCategory { get; set; }
    }
}
