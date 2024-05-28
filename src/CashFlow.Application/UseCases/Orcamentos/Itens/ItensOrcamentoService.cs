using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Orcamentos;
using CashFlow.Domain.Repositories.Pecas;

namespace CashFlow.Application.UseCases.Orcamentos.Itens
{
    internal class ItensOrcamentoService : IItensOrcamentoService
    {
        private readonly IItensOrcamentoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPecasRepository _pecasRepository;
        public ItensOrcamentoService(
            IItensOrcamentoRepository repository,
            IUnitOfWork unitOfWork,
            IPecasRepository pecasRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _pecasRepository = pecasRepository;
        }
        public async Task<Guid> Create(ItemOrcamento request)
        {
            _unitOfWork.BeginTransaction();

            await _repository.Create(request);

            var pecas = await _pecasRepository.GetValoresPeca(request.CodigoPeca);

            if (pecas.Any())
            {
                var itensOrcamento = pecas.Select(p => new ItemOrcamentoValor
                {
                    CodigoItemOrcamento = request.Id,
                    Nome = p.Nome,
                    Valor = p.Valor
                }).ToList();

                itensOrcamento.ForEach(async io => await _repository.SalvarItensValores(io));
            }

            await _unitOfWork.Commit();

            return request.Id;
        }

        public async Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento)
        {
            return await _repository.GetItens(codigoOrcamento);
        }
    }
}
