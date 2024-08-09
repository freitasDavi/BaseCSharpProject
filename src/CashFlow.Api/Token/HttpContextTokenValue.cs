using CashFlow.Infrastructure.Services.Tokens;

namespace CashFlow.Api.Token
{
    public class HttpContextTokenValue : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public HttpContextTokenValue(IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext;
        }
        public string TokenOnRequest()
        {
            var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authorization.Replace("Bearer ", "").Trim();
        }
    }
}
