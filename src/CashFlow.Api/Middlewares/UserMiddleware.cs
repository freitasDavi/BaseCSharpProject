using CashFlow.Application.UseCases.Users;
using Microsoft.AspNetCore.Authentication;

namespace CashFlow.Api.Middlewares
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;

        public UserMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke (HttpContext context, IUsersService usersService)
        {
            var token = await context.GetTokenAsync("access_token");

            if (token is not null)
            {
                var userData = await usersService.GetUserByToken(token);

                context.Items["CodigoUsuario"] = userData.Id;
            }

            await _next(context);
        }
    }
}
