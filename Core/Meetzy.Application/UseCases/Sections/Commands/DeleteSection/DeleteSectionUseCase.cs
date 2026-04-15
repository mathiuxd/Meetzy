using Meetzy.Application.Contracts.Persistence;
using Meetzy.Application.Contracts.Repositories;
using Meetzy.Application.Utilities.Mediator;
using Meetzy.Domain;
using Meetzy.Domain.Exceptions;

namespace Meetzy.Application.UseCases.Sections.Commands.DeleteSection
{
    public class DeleteSectionUseCase : IRequestHandler<DeleteSectionCommand>
    {
        private readonly ISectionsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSectionUseCase(ISectionsRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteSectionCommand command)
        {
            Section? section = await _repository.GetByIdAsync(command.Id);

            if (section is null)
            {
                throw new BussinessRuleExceptions($"No existe sección con id '{command.Id}'");
            }

            // TODO: Validar que no tenga articulos asociados

            try
            {
                _repository.Delete(section);
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
