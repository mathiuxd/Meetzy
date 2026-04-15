using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;
using Meetzy.Domain.Exceptions;

namespace Meetzy.Application.UseCases.Sections.Commands.CreateSection
{
    public class CreateSectionUseCase : IRequestHandler<CreateSectionCommand, Guid>
    {
        private readonly ISectionsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSectionUseCase(ISectionsRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateSectionCommand command)
        {
            Section section = new Section(command.Name, Guid.Empty, command.Description);

            try
            {
                await _repository.AddAsync(section);
                await _unitOfWork.CommitAsync();
                return section.Id;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}