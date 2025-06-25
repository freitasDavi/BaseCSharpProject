
namespace CashFlow.Communication.Requests.Produtos;

public record CreateProdutoRequest(string Nome, string Descricao, decimal ValorBase, bool Ativo = false);