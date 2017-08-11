using CuKhoaiCuSan.Model.Models;

namespace CuKhoaiCuSan.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private KhoaiSanDbContext dbContext;

        public KhoaiSanDbContext Init()
        {
            return dbContext ?? (dbContext = new KhoaiSanDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}