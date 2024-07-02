using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
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
            //await service.Register(request);

            return Created("", new { msg = "Salvo com sucesso" });
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
        [FromBody] RequestLogin request,
        [FromServices] IUsersService service)
        {
            var response = await service.Login(request);

            return Ok(response);
        }
    }
}
