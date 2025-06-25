using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Pecas;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Pecas
{
    public class PecasService : IPecasService
    {
        private readonly IPecasRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PecasService(
            IPecasRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Create(Peca request)
        {
            var id = await _repository.Create(request);
            await _unitOfWork.Commit();

            return id;
        }

        public async Task<List<Peca>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Peca> GetById(Guid id)
        {
            var peca = await _repository.GetById(id);

            return peca is null ? throw new NotFoundException("Peça") : peca;
        }

        public Task Update(Guid id, Peca request)
        {
            throw new NotImplementedException();
        }
    }
}
