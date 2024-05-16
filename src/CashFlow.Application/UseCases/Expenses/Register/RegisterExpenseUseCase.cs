using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute (RequestExpenseJson request)
        {
            Validate(request);

            return new ResponseRegisterExpenseJson { };
        }

        private void Validate(RequestExpenseJson request)
        {
            var titleIsEmpty = string.IsNullOrEmpty(request.Title);

            if (titleIsEmpty)
            {
                throw new ArgumentException("The title is required.");
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0.");
            }

            var resultado = DateTime.Compare(request.Date, DateTime.UtcNow);

            if (resultado > 0)
            {
                throw new ArgumentException("Expenses cannot be for the future");
            }

            var isPaymentTypeValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

            if (!isPaymentTypeValid)
            {
                throw new ArgumentException("Invalid payment type");
            }
        }
    }
}
