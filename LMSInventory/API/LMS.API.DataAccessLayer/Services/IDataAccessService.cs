using LMS.API.DataAccessLayer.Models;

namespace LMS.API.DataAccessLayer.Services
{
    public interface IDataAccessService
    {
        IQueryable<Store> GetAllStores();
        IQueryable<Store> GetAllStores(int pageSize, int pageNumber);
        Store GetStoreById(int id);
        void UpdateStores(params Store[] stores);
        void AddStores(params Store[] stores);
        void DeleteStores(params Store[] stores);

        IQueryable<Rack> GetAllRacks();
        IQueryable<Rack> GetAllRacks(int pageSize, int pageNumber);
        Rack GetRackById(int id);
        void UpdateRacks(params Rack[] racks);
        void AddRacks(params Rack[] racks);
        void DeleteRacks(params Rack[] racks);

        IQueryable<Element> GetAllElements();
        IQueryable<Element> GetAllElements(int pageSize, int pageNumber);
        Element GetElementById(int id);
        void UpdateElements(params Element[] elements);
        void AddElements(params Element[] elements);
        void DeleteElements(params Element[] elements);
    }
}