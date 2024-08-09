using CashFlow.Application.UseCases.Incomes;
using CashFlow.Communication.Requests.Incomes;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomesController: ControllerBase
    {
        private readonly IIncomesService _incomesService;
        public IncomesController(IIncomesService incomesService)
        {
            _incomesService = incomesService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateIncome([FromBody] CreateIncomeRequest request)
        {
            var id = await _incomesService.CreateIncome(request);    

            return Created("", id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Income>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var user = HttpContext.Items["CodigoUsuario"];
            
            var incomes = await _incomesService.GetAll((long)user!);

            return Ok(incomes);
        }

        [HttpGet("totalizador")]
        [ProducesResponseType(typeof(DashboardTotalResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTotalExpenses()
        {
            var user = HttpContext.Items["CodigoUsuario"];

            var total = await _incomesService.GetTotalIncomes((long)user!);

            return Ok(total);
        }
    }
}
