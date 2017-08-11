﻿using CuKhoaiCuSan.Data.Infrastructure;
using CuKhoaiCuSan.Model.Models;

namespace CuKhoaiCuSan.Data.Repositoris
{
    public interface IItemRepository
    {
    }

    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}