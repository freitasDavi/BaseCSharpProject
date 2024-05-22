namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public interface IGenerateExpensesreportExcelUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}
