namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        public Guid StockID { get; set; }

        [StringLength(150)]
        public string StockName { get; set; }

        [StringLength(150)]
        public string StockCode { get; set; }

        [StringLength(500)]
        public string Desription { get; set; }

        public bool? Status { get; set; }

        public Guid? BranchID { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
