using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Orcamento : BaseEntityGuid
    {
        public DateTime Validade { get; set; }
        public DateTime Emissao { get; set; }
        public decimal ValorTotal { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string? Observacao { get; set; }
        public EnumStatusOrcamento Status { get; set; }

        public long CodigoAutor { get; set; }
        public Guid CodigoCliente { get; set; }
        public virtual ICollection<ItemOrcamento> Itens { get; set; } = new List<ItemOrcamento>();
    }
}
