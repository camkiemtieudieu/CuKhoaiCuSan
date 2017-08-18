using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuKhoaiCuSan.Web.Models
{
    public class ItemViewModel
    {
        public Guid ItemID { get; set; }

        public string Barcode { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public string Unit { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Tags { get; set; }

        public string Weigh { get; set; }

        public Guid? BranchID { get; set; }

        public Guid? StockID { get; set; }

        public Guid? ItemCategoryID { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public decimal? TaxRate { get; set; }

        public bool Status { get; set; }

        public virtual ItemCategoryViewModel ItemCategory { get; set; }

        public virtual ICollection<ItemOptionViewModel> ItemOption { get; set; }
    }
}