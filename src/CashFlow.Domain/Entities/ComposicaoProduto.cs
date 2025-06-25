

namespace CashFlow.Domain.Entities
{
    public class ComposicaoProduto : BaseEntity
    {
        public Guid CodigoProduto { get; set; }
        public Guid CodigoPeca { get; set; }
        public int Quantidade { get; set; }

        public virtual Peca Peca { get; set; } = null!;
    }
}