using System.Threading.Tasks;
using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;

namespace Meetzy.Application.UseCases.Events.Commands.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, CreateEventResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        //Agrupa repositorios
        public CreateEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Maneja la lógica de negocio para crear un evento
        public async Task<CreateEventResponse> Handle(CreateEventRequest request)
        {
            var @event = new Event(
                request.Title,
                request.Location,
                request.City,
                request.DateTime,
                request.CreatorId,
                request.Description,
                request.MaxAttendees,
                request.CommunityId
            );

            //Guarda en la base de datos
            await _unitOfWork.Events.AddAsync(@event);
            await _unitOfWork.SaveChangesAsync();

            //Retorna la respuesta
            return new CreateEventResponse(
                @event.EventId,
                @event.Title,
                @event.Location,
                @event.City,
                @event.EventDateTime,
                @event.CreatorId,
                @event.CommunityId,
                @event.CreatedAt
            );
        }
    }
}
