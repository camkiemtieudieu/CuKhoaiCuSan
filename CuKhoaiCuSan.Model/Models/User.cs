namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            RoleDetail = new HashSet<RoleDetail>();
        }

        [Key]
        public Guid ID { get; set; }

        [StringLength(10)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public Guid? ObjectID { get; set; }

        public bool? Status { get; set; }

        public virtual Object1 Object { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleDetail> RoleDetail { get; set; }
    }
}
