using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;
using Meetzy.Domain.Exceptions;

namespace Meetzy.Application.UseCases.Sections.Commands.DeactiveSeccion
{
    public class DeactivateSeccionUseCase : IRequestHandler<DeactivateSeccionCommand>
    {
        private readonly ISectionsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeactivateSeccionUseCase(ISectionsRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeactivateSeccionCommand command)
        {
            Section? section = await _repository.GetByIdAsync(command.Id);

            if (section is null)
            {
                throw new BussinessRuleExceptions($"No existe sección con id '{command.Id}'");
            }

            try
            {
                section.Deactivate();
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
