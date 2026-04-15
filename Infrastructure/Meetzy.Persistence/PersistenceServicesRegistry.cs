using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Persistence.Repositories;
using Meetzy.Persistence.UnitOfWorks;

namespace Meetzy.Persistence.Repositories
{
	public static class PersistenceServicesRegistry
	{
		public static IServiceCollection AddPersistenceRepositories(this IServiceCollection services)
		{
			services.AddDbContext<DataContext>(options =>
			{
				options.UseSqlServer("name=MeetzyConnectionString");
			});

			services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
			services.AddScoped<ISectionsRepository, SectionsRepository>();
			return services;
		}
	}
}
