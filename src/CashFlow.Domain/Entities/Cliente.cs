namespace CashFlow.Domain.Entities
{
    public class Cliente : BaseEntityGuid
    {
        public string Nome { get; set; } = "";
        public string CNPJ { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string CEP { get; set; } = "";
        public string Rua { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string Estado { get; set; } = "";
    }
}
