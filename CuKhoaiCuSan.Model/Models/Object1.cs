namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Object")]
    public partial class Object1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Object1()
        {
            User = new HashSet<User>();
        }
        [Key]
        public Guid ObjectID { get; set; }

        [StringLength(50)]
        public string ObjectCode { get; set; }

        [StringLength(255)]
        public string ObjectName { get; set; }

        public Guid? ObjectCategoryID { get; set; }

        [StringLength(255)]
        public string ObjectAddress { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string BankAccount { get; set; }

        [StringLength(255)]
        public string BankName { get; set; }

        [StringLength(50)]
        public string TaxCode { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountRate { get; set; }

        public DateTime? BirthdayDate { get; set; }

        public int? AccumulativePoint { get; set; }

        [Column(TypeName = "money")]
        public decimal? Debt { get; set; }

        public int? ObjectKind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }

        [ForeignKey("ObjectCategoryID")]
        public virtual ObjectCategory ObjectCategory { get; set; }
    }
}
