using CuKhoaiCuSan.Data.Infrastructure;
using CuKhoaiCuSan.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuKhoaiCuSan.Data.Repositoris
{
    public interface IErrorRepository:IRepository<Error>
    {

    }
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
