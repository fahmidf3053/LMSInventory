using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;

namespace LMS.API.BusinessLogicLayer.Interfaces
{
    public interface IElementManager
    {
        List<ElementResDTO> GetAllElements(int pageSize, int pageNumber);
        ElementResDTO GetElementById(int id);
        ElementResDTO SaveElement(ElementReqDTO reqDTO);
        ElementResDTO EditElement(ElementReqDTO reqDTO);
        ResponseDTO DeleteElement(int id);
    }
}
