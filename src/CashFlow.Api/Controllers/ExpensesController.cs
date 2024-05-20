using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] RequestExpenseJson request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();

                var response = useCase.Execute(request);

                return Created("", response);
            } catch (ErrorOnValidationException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Errors);

                return BadRequest(errorResponse);
            } catch
            {
                var errorResponse = new ResponseErrorJson("Unknown error");

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
