namespace CashFlow.Communication.Requests
{
    public class UpdateItemOrcamentoRequest
    {
        public required CreateItemOrcamentoRequest ItemOrcamento { get; set; }
        public required List<UpdateItemOrcamentoValorRequest> Valores { get; set; }
    }
}
