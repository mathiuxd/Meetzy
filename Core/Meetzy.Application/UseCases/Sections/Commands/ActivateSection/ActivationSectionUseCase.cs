using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain.Exceptions;
using static System.Collections.Specialized.BitVector32;

namespace Meetzy.Application.UseCases.Sections.Commands.ActivateSection
{
    public class ActivateSectionUseCase : IRequestHandler<ActivateSectionCommand>
    {
        private ISectionsRepository _repository;
        private IUnitOfWork _unitOfWork;

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
                throw new BussinesRuleException($"No existe sección con id '{command.Id}'");
            }

            try
            {
                section.Activate();
                await _repository.UpdateAsync(section);
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