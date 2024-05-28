using System.Net;

namespace CashFlow.Exception.ExceptionsBase
{
    public class EntityAlreadyExists : CashFlowException
    {
        public EntityAlreadyExists(string message) : base(message)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
