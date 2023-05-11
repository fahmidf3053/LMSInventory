using Microsoft.Extensions.DependencyInjection;

using LMS.API.DataAccessLayer.Services;

namespace LMS.API.DataAccessLayer.Extensions
{
    public static class DataAccessDependencyGroup
    {
        public static IServiceCollection AddDataAccessDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IDataAccessService, DataAccessService>();

            return services;
        }
    }
}
