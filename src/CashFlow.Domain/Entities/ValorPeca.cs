namespace CashFlow.Domain.Entities
{
    public class ValorPeca : BaseEntityGuid
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public Guid CodigoPeca { get; set; }
    }
}
