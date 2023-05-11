using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;

namespace LMS.API.BusinessLogicLayer.Interfaces
{
    public interface IStoreManager
    {
        List<StoreResDTO> GetAllStores(int pageSize, int pageNumber);
        StoreResDTO GetStoreById(int id);
        StoreResDTO SaveStore(StoreReqDTO reqDTO);
        StoreResDTO EditStore(StoreReqDTO reqDTO);
        ResponseDTO DeleteStore(int id);
    }
}
