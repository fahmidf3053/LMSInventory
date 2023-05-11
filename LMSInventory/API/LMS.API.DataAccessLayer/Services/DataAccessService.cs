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
        private readonly IRackRepository _rackRepository;
        private readonly IElementRepository _elementRepository;

        public DataAccessService()
        {
            _storeRepository = new StoreRepository();
            _rackRepository = new RackRepository();
            _elementRepository = new ElementRepository();
        }


        public IQueryable<Store> GetAllStores()
        {
            return _storeRepository.GetAll().Include(r => r.Racks).Include("Racks.Elements");
        }
        public IQueryable<Store> GetAllStores(int pageSize, int pageNumber)
        {
            return _storeRepository.GetAll().Include(x => x.Racks).Include("Racks.Elements")
                .Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public Store GetStoreById(int id)
        {
            return _storeRepository.GetAll().Where(x => x.Id == id).Include(x => x.Racks)
                .Include("Racks.Elements").FirstOrDefault();
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


        public IQueryable<Rack> GetAllRacks()
        {
            return _rackRepository.GetAll().Include(r => r.Elements);
        }
        public IQueryable<Rack> GetAllRacks(int pageSize, int pageNumber)
        {
            return _rackRepository.GetAll().Include(x => x.Elements).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public Rack GetRackById(int id)
        {
            return _rackRepository.GetAll().Where(x => x.Id == id).Include(x => x.Elements).FirstOrDefault();
        }
        public void UpdateRacks(params Rack[] racks)
        {
            _rackRepository.Update(racks);
        }
        public void AddRacks(params Rack[] racks)
        {
            _rackRepository.Add(racks);
        }
        public void DeleteRacks(params Rack[] racks)
        {
            _rackRepository.Remove(racks);
        }


        public IQueryable<Element> GetAllElements()
        {
            return _elementRepository.GetAll();
        }
        public IQueryable<Element> GetAllElements(int pageSize, int pageNumber)
        {
            return _elementRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public Element GetElementById(int id)
        {
            return _elementRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
        public void UpdateElements(params Element[] elements)
        {
            _elementRepository.Update(elements);
        }
        public void AddElements(params Element[] elements)
        {
            _elementRepository.Add(elements);
        }
        public void DeleteElements(params Element[] elements)
        {
            _elementRepository.Remove(elements);
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
