

namespace CashFlow.Communication.Requests.Produtos;

public record UpdateProdutoRequest(Guid Id, string Nome, string Descricao, decimal ValorBase, bool Ativo = false) : CreateProdutoRequest(Nome, Descricao, ValorBase, Ativo);