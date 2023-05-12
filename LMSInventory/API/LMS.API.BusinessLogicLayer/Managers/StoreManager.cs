using LMS.API.BusinessLogicLayer.Interfaces;
using LMS.API.BusinessLogicLayer.Services;
using LMS.API.DataAccessLayer.Models;
using LMS.API.DataAccessLayer.Services;
using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;
using LMS.API.Exceptions;
using static LMS.API.Utils.Constants;

namespace LMS.API.BusinessLogicLayer.Managers
{
    public class StoreManager : IStoreManager
    {
        private readonly IDataAccessService _dataAccessService;

        public StoreManager(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        #region Public Methods

        public List<StoreResDTO> GetAllStores(int pageSize, int pageNumber)
        {
            List<Store> stores = new();

            if (pageSize == 0 || pageNumber == 0)
            {
                stores = _dataAccessService.GetAllStores().ToList();
            }
            else
            {
                stores = _dataAccessService.GetAllStores(pageSize, pageNumber).ToList();
            }

            List<StoreResDTO> result = stores.Select(MapperService.ToStoreResDTOMap).ToList();

            return result;
        }

        public StoreResDTO GetStoreById(int id)
        {

            Store store = _dataAccessService.GetStoreById(id);

            if (store == null)
                throw new StoreException(StoreExceptions.StoreInfoNotFound);

            StoreResDTO result = MapperService.ToStoreResDTOMap(store);

            return result;
        }

        public StoreResDTO SaveStore(StoreReqDTO reqDTO)
        {

            Store storeToBeAdded = MapperService.ToStoreModelMap(reqDTO);

            storeToBeAdded.EntityState = EntityState.Added;

            _dataAccessService.AddStores(storeToBeAdded);

            if(storeToBeAdded.Id == 0)
                throw new StoreException(StoreExceptions.StoreSaveFailed);

            StoreResDTO result = MapperService.ToStoreResDTOMap(_dataAccessService.GetStoreById(storeToBeAdded.Id));

            return result;
        }

        public StoreResDTO EditStore(StoreReqDTO reqDTO)
        {
            Store storeToBeUpdated = _dataAccessService.GetStoreById(reqDTO.Id);

            if (storeToBeUpdated == null)
                throw new StoreException(StoreExceptions.WrongStoreInfo);

            storeToBeUpdated.Name = reqDTO.Name;
            storeToBeUpdated.Country = reqDTO.Country;
            storeToBeUpdated.EntityState = EntityState.Modified;
            storeToBeUpdated.Racks = null;

            _dataAccessService.UpdateStores(storeToBeUpdated);

            StoreResDTO result = MapperService.ToStoreResDTOMap(_dataAccessService.GetStoreById(storeToBeUpdated.Id));

            return result;
        }

        public ResponseDTO DeleteStore(int id)
        {
            Store storeToBeDeleted = _dataAccessService.GetStoreById(id);

            if (storeToBeDeleted == null)
                throw new StoreException(StoreExceptions.WrongStoreInfo);

            storeToBeDeleted.EntityState = EntityState.Deleted;

            _dataAccessService.DeleteStores(storeToBeDeleted);

            Store store = _dataAccessService.GetStoreById(id);

            if (store != null)
                throw new StoreException(StoreExceptions.StoreDeleteFailed);

            return new ResponseDTO
            {
                Status = SUCCESS_CODE,
                Message = SUCCESS_MSG
            };
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
