using Microsoft.Extensions.DependencyInjection;

using LMS.API.BusinessLogicLayer.Extensions;


namespace LMS.API.Extensions
{
    public static class APIDependencyGroup
    {
        public static IServiceCollection AddAPIDependencyGroup(this IServiceCollection services)
        {
            // register Managers
            services.AddManagersDependencyGroup();

            return services;
        }
    }
}
