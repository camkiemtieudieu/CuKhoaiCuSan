using System;

namespace CuKhoaiCuSan.Web.Models
{
    public class ItemOptionViewModel
    {
        public Guid ID { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Material { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal? PurchasePrice { get; set; }

        public Guid ItemID { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public virtual ItemViewModel Item { get; set; }
        public bool Status { get; set; }
    }
}