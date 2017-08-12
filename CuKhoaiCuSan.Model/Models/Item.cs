namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [Key]
        public Guid ItemID { get; set; }

        [StringLength(15)]
        public string Barcode { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(150)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(150)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Tags { get; set; }

        [StringLength(10)]
        public string Weigh { get; set; }

        public Guid? BranchID { get; set; }

        public Guid? StockID { get; set; }

        public Guid? ItemCategoryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(150)]
        public string ModifiedBy { get; set; }

        public decimal? TaxRate { get; set; }

        public bool Status { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }

        [ForeignKey("ItemID")]
        public virtual ICollection<ItemOption> ItemOption { get; set; }
    }
}
