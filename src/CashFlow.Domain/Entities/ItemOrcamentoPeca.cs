

namespace CashFlow.Domain.Entities
{
    public class ItemOrcamentoPeca : BaseEntity
    {
        public Guid CodigoItem { get; set; }
        public Guid CodigoPeca { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Peca Peca { get; set; } = null!;
        public virtual ItemOrcamento Item { get; set; } = null!;
    }
}