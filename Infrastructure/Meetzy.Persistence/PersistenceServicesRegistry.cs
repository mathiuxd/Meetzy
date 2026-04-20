using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Persistence.Repositories;
using Meetzy.Persistence.UnitOfWorks;

namespace Meetzy.Persistence;

public static class PersistenceServicesRegistry
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
        services.AddScoped<ISectionsRepository, SectionsRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICommunityRepository, EfCoreCommunityRepository>();

        return services;
    }
}