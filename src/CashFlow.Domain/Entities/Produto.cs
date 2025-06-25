

namespace CashFlow.Domain.Entities
{
    public class Produto : BaseEntityGuid
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal ValorBase { get; set; }
        public bool Ativo { get; set; } = true;

        public virtual ICollection<ComposicaoProduto> Composicoes { get; set; } = new List<ComposicaoProduto>();
    }
}