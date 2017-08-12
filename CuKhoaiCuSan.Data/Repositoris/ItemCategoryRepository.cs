using CuKhoaiCuSan.Data.Infrastructure;
using CuKhoaiCuSan.Model.Models;

namespace CuKhoaiCuSan.Data.Repositoris
{
    public interface IItemCategoryRepository:IRepository<ItemCategory>
    {
    }

    public class ItemCategoryRepository : RepositoryBase<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}