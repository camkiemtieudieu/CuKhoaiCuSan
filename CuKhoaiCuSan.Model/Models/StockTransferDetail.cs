namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockTransferDetail")]
    public partial class StockTransferDetail
    {
        [Key]
        [Column(Order = 0)]
        public Guid VoucherDetailID { get; set; }

        public Guid VoucherID { get; set; }

        public Guid ItemID { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public Guid FromStockID { get; set; }

        public Guid ToStockID { get; set; }
    
        public Guid? ConfrontingVoucherID { get; set; }

        public Guid EmployeeID { get; set; }

        public Guid ObjectID { get; set; }

        public Guid StatisticItemID { get; set; }

        public int? SortOrder { get; set; }

        [StringLength(20)]
        public string UnitConvert { get; set; }

        public decimal? ConvertRate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public virtual StockTransfer StockTransfer { get; set; }
    }
}
