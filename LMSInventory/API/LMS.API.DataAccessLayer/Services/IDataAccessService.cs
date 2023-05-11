using LMS.API.DataAccessLayer.Models;

namespace LMS.API.DataAccessLayer.Services
{
    public interface IDataAccessService
    {
        IQueryable<Store> GetAllStores();
        IQueryable<Store> GetAllStores(int pageSize = int.MaxValue, int pageNumber = int.MaxValue);
        Store GetStoreById(int id);
        void UpdateStores(params Store[] stores);
        void AddStores(params Store[] stores);
        void DeleteStores(params Store[] stores);

    }
}