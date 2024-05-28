using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Peca : BaseEntity
    {
        public EnumTamanhoPeca TamanhoPeca { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Porcentagem { get; set; }    
    }
}
