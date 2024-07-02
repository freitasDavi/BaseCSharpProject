namespace CashFlow.Communication.Requests.Orcamento
{
    public class UpdateOrcamentoRequest : CreateOrcamentoRequest
    {
        public decimal? ValorTotal { get; set; }
    }
}
