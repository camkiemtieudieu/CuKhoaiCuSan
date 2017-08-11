namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoucherType")]
    public partial class VoucherType
    {
        [Key]
        [Column("VoucherType")]
        public int VoucherType1 { get; set; }

        [StringLength(250)]
        public string VoucherName { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
    }
}
