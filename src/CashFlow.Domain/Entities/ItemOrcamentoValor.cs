namespace CashFlow.Domain.Entities
{
    public class ItemOrcamentoValor : BaseEntityGuid
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; } 
        public Guid CodigoItemOrcamento {  get; set; }
    }
}
