namespace CashFlow.Domain.Entities
{
    public class Orcamento : BaseEntityGuid
    {
        public DateTime Validade { get; set; }
        public DateTime Emissao { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid CodigoCliente { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
