namespace CashFlow.Communication.Requests.Incomes
{
    public class CreateIncomeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
