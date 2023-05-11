using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;

namespace LMS.API.BusinessLogicLayer.Interfaces
{
    public interface IJWTManager
    {
        TokenResDTO Authenticate(UserReqDTO users);
    }
}
