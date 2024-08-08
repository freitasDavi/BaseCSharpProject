using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Requests.Users;
using CashFlow.Communication.Responses;
using CashFlow.Communication.Responses.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IUsersService usersService,
            [FromBody] RequestRegisterUserJson request
            )
        {
            var response = await usersService.Register(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseUserProfileJson), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetProfile([FromServices] IUsersService useCase)
        {
            var response = await useCase.Get();

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromServices] IUsersService useCase, [FromBody] RequestUpdateUserJson request)
        {
            await useCase.Update(request);

            return NoContent();
        }

        [HttpPut("change-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromServices] IUsersService useCase, [FromBody] RequestChangePasswordJson request)
        {
            await useCase.ChangePassword(request);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<IActionResult> DeleteAccount([FromServices] IUsersService useCase)
        {
            await useCase.DeleteUserAccount();

            return NoContent();
        }
    }
}
