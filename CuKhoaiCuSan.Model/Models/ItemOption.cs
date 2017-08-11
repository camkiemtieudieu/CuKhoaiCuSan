namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemOption")]
    public partial class ItemOption
    {
        public Guid ID { get; set; }

        [StringLength(150)]
        public string Color { get; set; }

        [StringLength(150)]
        public string Size { get; set; }

        [StringLength(150)]
        public string Material { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalePrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? PurchasePrice { get; set; }

        public Guid? ItemID { get; set; }

        [StringLength(150)]
        public string Image1 { get; set; }

        [StringLength(150)]
        public string Image2 { get; set; }

        [StringLength(150)]
        public string Image3 { get; set; }

        [StringLength(150)]
        public string Image4 { get; set; }
    }
}
