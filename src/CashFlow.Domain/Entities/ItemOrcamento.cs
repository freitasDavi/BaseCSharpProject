namespace CashFlow.Domain.Entities
{
    public class ItemOrcamento : BaseEntityGuid
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao {  get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid CodigoOrcamento { get; set; }
        public Guid CodigoPeca { get; set; }
    }
}
