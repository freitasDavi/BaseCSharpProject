namespace CashFlow.Communication.Requests
{
    public class UpdateItemOrcamentoValorRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public Guid CodigoItemOrcamento { get; set; }
    }
}
