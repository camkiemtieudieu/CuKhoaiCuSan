namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoucherCheck")]
    public partial class VoucherCheck
    {
        [Key]
        public Guid VoucherID { get; set; }

        public int? VoucherType { get; set; }

        public DateTime? VoucherDate { get; set; }

        public Guid? ObjectID { get; set; }

        public Guid? StockID { get; set; }

        [StringLength(50)]
        public string Tags { get; set; }

        [StringLength(250)]
        public string Note { get; set; }
    }
}
