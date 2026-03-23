using Meetzy.Application.Utilities.Mediator;

namespace Meetzy.Application.UseCases.Sections.Commands.CreateSection
{
    public class CreateSectionUseCase : IRequestHandler<CreateSectionCommand, Guid>
    {
        public Task<Guid> Handle(CreateSectionCommand request)
        {
            throw new NotImplementedException();
        }
    }
}