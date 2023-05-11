using static LMS.API.Utils.Constants;

namespace LMS.API.DataAccessLayer.Interfaces
{

    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }
}
