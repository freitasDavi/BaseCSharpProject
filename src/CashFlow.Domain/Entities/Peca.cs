using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Peca : BaseEntityGuid
    {
        public EnumTamanhoPeca TamanhoPeca { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Porcentagem { get; set; }
        public decimal Valor { get; set; }
    }
}
