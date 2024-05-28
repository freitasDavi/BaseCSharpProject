using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
        [FromBody] RequestCreateUser request,
        [FromServices] IUsersService service)
        {
            await service.Register(request);

            return Created("", new { msg = "Salvo com sucesso" });
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Login(
        [FromBody] RequestLogin request,
        [FromServices] IUsersService service)
        {
            var token = await service.Login(request);

            return Created("", new { msg = token });
        }
    }
}
