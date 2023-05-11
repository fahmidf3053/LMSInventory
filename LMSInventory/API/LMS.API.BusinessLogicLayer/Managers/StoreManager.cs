using LMS.API.BusinessLogicLayer.Interfaces;
using LMS.API.BusinessLogicLayer.Services;
using LMS.API.DataAccessLayer.Models;
using LMS.API.DataAccessLayer.Services;
using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;

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

            List<StoreResDTO> result = new();
            List<Store> stores = new();

            if (pageSize == 0 || pageNumber == 0)
            {
                stores = _dataAccessService.GetAllStores().ToList();
            }
            else
            {
                stores = _dataAccessService.GetAllStores(pageSize, pageNumber).ToList();
            }

            result = stores.Select(MapperService.ToStoreResDTOMap).ToList();

            return result;
        }

        public StoreResDTO SaveStore(StoreReqDTO reqDTO)
        {

           StoreResDTO result = new();



            return result;
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
