using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;

namespace LMS.API.BusinessLogicLayer.Interfaces
{
    public interface IRackManager
    {
        List<RackResDTO> GetAllRacks(int pageSize, int pageNumber);
        RackResDTO GetRackById(int id);
        RackResDTO SaveRack(RackReqDTO reqDTO);
        RackResDTO EditRack(RackReqDTO reqDTO);
        ResponseDTO DeleteRack(int id);
    }
}
