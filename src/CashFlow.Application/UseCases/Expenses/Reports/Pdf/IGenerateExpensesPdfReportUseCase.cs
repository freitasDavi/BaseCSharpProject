namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public interface IGenerateExpensesPdfReportUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}
