namespace CashFlow.Communication.Requests.Orcamento
{
    public class CreateOrcamentoRequest
    {
        public DateTime Validade { get; set; }
        public Guid CodigoCliente { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
