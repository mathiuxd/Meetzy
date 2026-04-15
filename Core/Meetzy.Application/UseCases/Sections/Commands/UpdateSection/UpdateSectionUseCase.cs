using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;
using Meetzy.Domain.Exceptions;

namespace Meetzy.Application.UseCases.Sections.Commands.UpdateSection
{
    public class UpdateSectionUseCase : IRequestHandler<UpdateSectionCommand>
    {
        private readonly ISectionsRepository _sectionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSectionUseCase(ISectionsRepository sectionsRepository, IUnitOfWork unitOfWork)
        {
            _sectionsRepository = sectionsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateSectionCommand command)
        {
            Section? section = await _sectionsRepository.GetByIdAsync(command.Id);

            if (section == null)
            {
                throw new BussinessRuleExceptions("La sección no existe.");
            }

            section.UpdateName(command.Name);

            if (command.IsActive)
            {
                section.Activate();
            }
            else
            {
                section.Deactivate();
            }

            try
            {
                _sectionsRepository.Update(section);
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
