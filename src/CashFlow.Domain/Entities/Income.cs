using System.ComponentModel.DataAnnotations;

namespace CashFlow.Domain.Entities
{
    public class Income
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
