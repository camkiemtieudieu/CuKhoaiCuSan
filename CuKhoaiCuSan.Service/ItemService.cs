using CuKhoaiCuSan.Data.Infrastructure;
using CuKhoaiCuSan.Data.Repositoris;
using CuKhoaiCuSan.Model.Models;
using System.Collections.Generic;

namespace CuKhoaiCuSan.Service
{
    public interface IItemService
    {
        void Add(Item item);

        void Update(Item item);

        void Delete(int id);

        IEnumerable<Item> GetAll();

        IEnumerable<Item> GetAllPaging(int page, int pagesize, out int totalRow);

        Item GetByID(int id);

        void SaveChanges();
    }

    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository;
        private IUnitOfWork _unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this._itemRepository = itemRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Item item)
        {
            _itemRepository.Add(item);
        }

        public void Delete(int id)
        {
            _itemRepository.Delete(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll(new string[] { "ItemCategory" });
        }

        public IEnumerable<Item> GetAllPaging(int page, int pagesize, out int totalRow)
        {
            return _itemRepository.GetMultiPaging(x => x.Status, out totalRow, page, pagesize);
        }

        public Item GetByID(int id)
        {
            return _itemRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Item item)
        {
            _itemRepository.Update(item);
        }
    }
}