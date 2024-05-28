namespace CashFlow.Domain.Entities
{
    public class ValorPeca : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int CodigoPeca { get; set; }
    }
}
