namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoucherCheckDetail")]
    public partial class VoucherCheckDetail
    {
        public Guid VoucherCheckDetailID { get; set; }

        public Guid? VoucherCheckID { get; set; }

        public Guid? ItemID { get; set; }

        public decimal? InStock { get; set; }

        public decimal? AfterCheck { get; set; }

        [StringLength(150)]
        public string Reason { get; set; }

        [StringLength(250)]
        public string Result { get; set; }
    }
}
