namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleDetail")]
    public partial class RoleDetail
    {
        [Key]
        [Column(Order = 0)]
        public Guid RoleID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid AccountID { get; set; }

        public int? Status { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
