namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Branch")]
    public partial class Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch()
        {
            Stock = new HashSet<Stock>();
        }
        [Key]
        public Guid BranchID { get; set; }

        [StringLength(50)]
        public string BranchCode { get; set; }

        [StringLength(10)]
        public string BranchName { get; set; }

        [StringLength(10)]
        public string Address { get; set; }

        [StringLength(10)]
        public string TelephoneNumber { get; set; }

        [StringLength(10)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
