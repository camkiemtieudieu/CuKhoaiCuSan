﻿using CuKhoaiCuSan.Data.Infrastructure;
using CuKhoaiCuSan.Model.Models;

namespace CuKhoaiCuSan.Data.Repositoris
{
    public interface IItemOptionRepository
    {
    }

    public class ItemOptionRepository : RepositoryBase<ItemOption>, IItemOptionRepository
    {
        public ItemOptionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}