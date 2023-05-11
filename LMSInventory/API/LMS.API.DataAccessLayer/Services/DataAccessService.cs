using System.Data;
using Microsoft.EntityFrameworkCore;

using LMS.API.DataAccessLayer.Interfaces;
using LMS.API.DataAccessLayer.Models;
using LMS.API.DataAccessLayer.Repositories;

namespace LMS.API.DataAccessLayer.Services
{
    public class DataAccessService : IDataAccessService, IDisposable
    {
        private readonly IStoreRepository _storeRepository;


        public DataAccessService()
        {
            _storeRepository = new StoreRepository();
        }


        public IQueryable<Store> GetAllStores()
        {
            return _storeRepository.GetAll().Include(r => r.Racks).Include("Racks.Elements");
        }

        public IQueryable<Store> GetAllStores(int pageSize, int pageNumber)
        {
            return _storeRepository.GetAll().Include(x => x.Racks).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public Store GetStoreById(int id)
        {
            return _storeRepository.GetAll().Where(x => x.Id == id).Include(x => x.Racks).FirstOrDefault();
        }

        public void UpdateStores(params Store[] stores)
        {
            _storeRepository.Update(stores);
        }

        public void AddStores(params Store[] stores)
        {
            _storeRepository.Add(stores);
        }

        public void DeleteStores(params Store[] stores)
        {
            _storeRepository.Remove(stores);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _storeRepository.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
