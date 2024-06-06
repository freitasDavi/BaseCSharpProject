using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Orcamentos;
using CashFlow.Domain.Repositories.Pecas;
using CashFlow.Exception.ExceptionsBase;

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
        public async Task<List<ItemOrcamentoValor>> Create(ItemOrcamento request)
        {
            _unitOfWork.BeginTransaction();

            await _repository.Create(request);

            var pecas = await _pecasRepository.GetValoresPeca(request.CodigoPeca);

           List<ItemOrcamentoValor> itensOrcamento = [];

            if (pecas.Any())
            {
                itensOrcamento = pecas.Select(p => new ItemOrcamentoValor
                {
                    CodigoItemOrcamento = request.Id,
                    Nome = p.Nome,
                    Valor = p.Valor
                }).ToList();

                itensOrcamento.ForEach(async io => await _repository.SalvarItensValores(io));
            }

            await _unitOfWork.Commit();

            return itensOrcamento;
        }

        public async Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento)
        {
            return await _repository.GetItens(codigoOrcamento);
        }

        public async Task<List<ItemOrcamentoValor>> GetValoresItemOrcamento(Guid codigoItemOrcamento)
        {
            return await _repository.GetValoresItemOrcamento(codigoItemOrcamento);
        }

        public async Task UpdateItemOrcamento(Guid id, UpdateItemOrcamentoRequest request)
        {
            _unitOfWork.BeginTransaction();

            var item = await _repository.GetItemOrcamentoEValores(id);

            if (item == null)
            {
                throw new NotFoundException("");
            }

            await _repository.RemoveItemsParaInsercao(id);

            var valores = MapearItemValorParaEdicao(request.Valores);

            item.Descricao = request.ItemOrcamento.Descricao;
            item.Nome = request.ItemOrcamento.Nome;
            item.Quantidade = request.ItemOrcamento.Quantidade;
            item.ValorTotal = request.ItemOrcamento.ValorTotal;

            _repository.UpdateItemOrcamento(item);
            await _repository.SalvarItensValores(valores);

            await _unitOfWork.Commit();
        }

        private List<ItemOrcamentoValor> MapearItemValorParaEdicao(List<UpdateItemOrcamentoValorRequest> valores)
        {
            List<ItemOrcamentoValor> items = valores.Select(vl => new ItemOrcamentoValor
            {
                CodigoItemOrcamento = vl.CodigoItemOrcamento,
                Id = vl.Id,
                Nome = vl.Nome,
                Valor = vl.Valor,
            }).ToList();

            return items;
        }
    }
}
