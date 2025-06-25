namespace CashFlow.Domain.Entities
{
    public class ItemOrcamento : BaseEntityGuid
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; } = 0;

        public Guid CodigoOrcamento { get; set; }
        public Guid CodigoProduto { get; set; }

        public virtual Produto Produto { get; set; } = null!;
        public virtual Orcamento Orcamento { get; set; } = null!;
    }
}
