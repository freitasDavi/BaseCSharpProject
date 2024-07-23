﻿using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Responses;
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
    }
}
