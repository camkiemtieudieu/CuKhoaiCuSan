using CuKhoaiCuSan.Model.Models;
using System;

namespace CuKhoaiCuSan.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KhoaiSanDbContext Init();
    }
}