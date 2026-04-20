using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.UseCases.Users.Commands.CreateUser;
using Meetzy.Application.UseCases.Users.Commands.LoginUser;
using Meetzy.Application.UseCases.Events.Commands.CreateEvent;
using Meetzy.Application.UseCases.Events.Commands.DeleteEvent;
using Meetzy.Application.UseCases.Events.Commands.UpdateEvent;
using Meetzy.Application.UseCases.Events.Queries.GetAllEvents;
using Meetzy.Application.UseCases.Events.Queries.GetEventById;
using Meetzy.Application.UseCases.Communities.Commands.CreateCommunity;
using Meetzy.Application.UseCases.Communities.Commands.DeleteCommunity;
using Meetzy.Application.UseCases.Communities.Commands.UpdateCommunity;
using Meetzy.Application.UseCases.Communities.Queries.GetAllCommunities;
using Meetzy.Application.UseCases.Communities.Queries.GetCommunityById;
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

            // Communities
            services.AddTransient<IRequestHandler<CreateCommunityRequest, CreateCommunityResponse>, CreateCommunityHandler>();
            services.AddTransient<IRequestHandler<UpdateCommunityRequest, UpdateCommunityResponse>, UpdateCommunityHandler>();
            services.AddTransient<IRequestHandler<DeleteCommunityRequest, DeleteCommunityResponse>, DeleteCommunityHandler>();
            services.AddTransient<IRequestHandler<GetAllCommunitiesRequest, IEnumerable<GetAllCommunitiesResponse>>, GetAllCommunitiesHandler>();
            services.AddTransient<IRequestHandler<GetCommunityByIdRequest, GetCommunityByIdResponse>, GetCommunityByIdHandler>();

            return services;
        }
    }
}