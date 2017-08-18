using CuKhoaiCuSan.Model.Models;
using CuKhoaiCuSan.Web.Models;

namespace CuKhoaiCuSan.Web.Infrastructure.Extensions
{
    public static class EntityExtensisons
    {
        public static void UpdateItemCategory(this ItemCategory itemCategory, ItemCategoryViewModel itemCategoryVm)
        {
            itemCategory.Id = itemCategoryVm.Id;
            itemCategory.Code = itemCategoryVm.Code;
            itemCategory.ItemCategoryName = itemCategoryVm.ItemCategoryName;
            itemCategory.ParentId = itemCategoryVm.ParentId;
            itemCategory.Description = itemCategoryVm.Description;
            itemCategory.Status = itemCategoryVm.Status;
        }

        public static void UpdateItem(this Item item, ItemViewModel itemVm)
        {
            item.ItemID = itemVm.ItemID;
            item.Barcode = itemVm.Barcode;
            item.Name = itemVm.Name;
            item.CreateDate = itemVm.CreateDate;
            item.CreateBy = itemVm.CreateBy;
            item.Unit = itemVm.Unit;
            item.Brand = itemVm.Brand;
            item.Tags = itemVm.Tags;
            item.Weigh = itemVm.Weigh;
            item.BranchID = itemVm.BranchID;
            item.StockID = itemVm.StockID;
            item.ItemCategoryID = itemVm.ItemCategoryID;
            item.ModifiedDate = itemVm.ModifiedDate;
            item.ModifiedBy = itemVm.ModifiedBy;
            item.TaxRate = itemVm.TaxRate;
            item.Status = itemVm.Status;
        }

        public static void Update(this ItemOption itemOption, ItemOptionViewModel itemOpitionVm)
        {
            itemOption.ID = itemOpitionVm.ID;
            itemOption.Color = itemOpitionVm.Color;
            itemOption.Size = itemOpitionVm.Size;
            itemOption.Material = itemOpitionVm.Material;
            itemOption.SalePrice = itemOpitionVm.SalePrice;
            itemOption.PurchasePrice = itemOpitionVm.PurchasePrice;
            itemOption.ItemID = itemOpitionVm.ItemID;
            itemOption.Image1 = itemOpitionVm.Image1;
            itemOption.Image2 = itemOpitionVm.Image2;
            itemOption.Image3 = itemOpitionVm.Image3;
            itemOption.Image4 = itemOpitionVm.Image4;
            itemOption.Status = itemOpitionVm.Status;
        }
    }
}