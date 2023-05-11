using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;

namespace LMS.API.BusinessLogicLayer.Interfaces
{
    public interface IStoreManager
    {
        List<StoreResDTO> GetAllStores(int pageSize, int pageNumber);
        StoreResDTO SaveStore(StoreReqDTO reqDTO);
    }
}
