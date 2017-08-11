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

        [Key]
        [Column(Order = 1)]
        public Guid VoucherID { get; set; }

        public Guid? ItemID { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public Guid? FromStockID { get; set; }

        public Guid? ToStockID { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal QuantityConvert { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal UnitPriceConvert { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal Amount { get; set; }

        public Guid? ConfrontingVoucherID { get; set; }

        public Guid? EmployeeID { get; set; }

        public Guid? ObjectID { get; set; }

        public Guid? StatisticItemID { get; set; }

        public int? SortOrder { get; set; }

        [StringLength(20)]
        public string UnitConvert { get; set; }

        public decimal? ConvertRate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public virtual StockTransfer StockTransfer { get; set; }
    }
}
