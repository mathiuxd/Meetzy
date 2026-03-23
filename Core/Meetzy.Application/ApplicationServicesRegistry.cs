using Meetzy.Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Meetzy.Application
{
    public static class ApplicationServicesRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();

            return services;
        }
    }
}