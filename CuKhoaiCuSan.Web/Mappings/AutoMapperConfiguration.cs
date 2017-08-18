using AutoMapper;
using CuKhoaiCuSan.Model.Models;
using CuKhoaiCuSan.Web.Models;

namespace CuKhoaiCuSan.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ItemCategory, ItemCategoryViewModel>().MaxDepth(2);
                cfg.CreateMap<Item, ItemViewModel>().MaxDepth(2);
                cfg.CreateMap<ItemOption, ItemViewModel>().MaxDepth(2);
            });
        }
    }
}