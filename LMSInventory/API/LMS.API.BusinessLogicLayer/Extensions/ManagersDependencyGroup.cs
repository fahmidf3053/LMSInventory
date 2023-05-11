using Microsoft.Extensions.DependencyInjection;

using LMS.API.BusinessLogicLayer.Interfaces;
using LMS.API.BusinessLogicLayer.Managers;
using LMS.API.DataAccessLayer.Extensions;

namespace LMS.API.BusinessLogicLayer.Extensions
{
    public static class ManagersDependencyGroup
    {
        public static IServiceCollection AddManagersDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IJWTManager, JWTManager>();
            services.AddScoped<IStoreManager, StoreManager>();           

            // register DataAccess
            services.AddDataAccessDependencyGroup();

            return services;
        }
    }
}
