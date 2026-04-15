using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;
using Meetzy.Domain.Exceptions;

namespace Meetzy.Application.UseCases.Sections.Commands.ActivateSection
{
    public class ActivateSectionUseCase : IRequestHandler<ActivateSectionCommand>
    {
        private readonly ISectionsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateSectionUseCase(ISectionsRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ActivateSectionCommand command)
        {
            Section? section = await _repository.GetByIdAsync(command.Id);

            if (section is null) 
            {
                throw new BussinessRuleExceptions($"No existe sección con id '{command.Id}'");
            }

            try
            {
                section.Activate();
                _repository.Update(section);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}