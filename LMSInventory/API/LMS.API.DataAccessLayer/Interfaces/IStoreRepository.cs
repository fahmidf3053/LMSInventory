using LMS.API.DataAccessLayer.Models;
using System;

namespace LMS.API.DataAccessLayer.Interfaces
{
    public interface IStoreRepository : IGenericDataRepository<Store>, IDisposable
    {

    }
}
