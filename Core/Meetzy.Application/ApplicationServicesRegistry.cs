using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.UseCases.Users.Commands.CreateUser;
using Meetzy.Application.UseCases.Users.Commands.LoginUser;
using Meetzy.Application.UseCases.Events.Commands.CreateEvent;
using Meetzy.Application.UseCases.Events.Commands.DeleteEvent;
using Meetzy.Application.UseCases.Events.Commands.UpdateEvent;
using Meetzy.Application.UseCases.Events.Queries.GetAllEvents;
using Meetzy.Application.UseCases.Events.Queries.GetEventById;
using Meetzy.Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Meetzy.Application
{
    public static class ApplicationServicesRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();

            // Users
            services.AddTransient<IRequestHandler<CreateUserRequest, CreateUserResponse>, CreateUserHandler>();
            services.AddTransient<IRequestHandler<LoginUserRequest, LoginUserResponse>, LoginUserHandler>();

            // Events
            services.AddTransient<IRequestHandler<CreateEventRequest, CreateEventResponse>, CreateEventHandler>();
            services.AddTransient<IRequestHandler<UpdateEventRequest, UpdateEventResponse>, UpdateEventHandler>();
            services.AddTransient<IRequestHandler<DeleteEventRequest, DeleteEventResponse>, DeleteEventHandler>();
            services.AddTransient<IRequestHandler<GetAllEventsRequest, IEnumerable<GetAllEventsResponse>>, GetAllEventsHandler>();
            services.AddTransient<IRequestHandler<GetEventByIdRequest, GetEventByIdResponse>, GetEventByIdHandler>();

            return services;
        }
    }
}