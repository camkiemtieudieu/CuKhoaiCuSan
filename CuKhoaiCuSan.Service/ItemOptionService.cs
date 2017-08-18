using CuKhoaiCuSan.Data.Infrastructure;
using CuKhoaiCuSan.Data.Repositoris;
using CuKhoaiCuSan.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuKhoaiCuSan.Service
{
    public interface IItemOptionSercice
    {
        void Add(ItemOption itemOption);

        void Update(ItemOption itemOption);

        void Delete(Guid id);

        IEnumerable<ItemOption> GetAll();

        IEnumerable<ItemOption> GetAllPaging(int page, int pagesize, out int totalRow);

        ItemOption GetByID(Guid id);

        void SaveChanges();
    }
    public class ItemOptionService
    {
        private IItemOptionRepository _itemOptionRepository;
        private IUnitOfWork _unitOfWork;

        public ItemOptionService(IItemOptionRepository itemOptionRepository, IUnitOfWork unitOfWork)
        {
            this._itemOptionRepository = itemOptionRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ItemOption itemOption)
        {
            _itemOptionRepository.Add(itemOption);
        }

        public void Delete(Guid id)
        {
            _itemOptionRepository.Delete(id);
        }

        public IEnumerable<ItemOption> GetAll()
        {
            return _itemOptionRepository.GetAll(new string[] { "ItemID" });
        }

        public IEnumerable<ItemOption> GetAllPaging(int page, int pagesize, out int totalRow)
        {
            return _itemOptionRepository.GetMultiPaging(x => x.Status, out totalRow, page, pagesize);
        }

        public ItemOption GetByID(Guid id)
        {
            return _itemOptionRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ItemOption itemOption)
        {
            _itemOptionRepository.Update(itemOption);
        }
    }
}
