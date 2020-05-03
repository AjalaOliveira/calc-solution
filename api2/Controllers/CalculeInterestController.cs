using api2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api2.Controllers
{
    [ApiController]
    public class CalculeInterestController : ControllerBase
    {
        private readonly ICalculateInterestService _calculateInterestService;

        public CalculeInterestController(ICalculateInterestService calculateInterestService)
        {
            _calculateInterestService = calculateInterestService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("calculajuros")]
        public async Task<IActionResult> GetCompoundInterestResult([FromQuery(Name = "valorinicial")] decimal valorinicial,
                                                                   [FromQuery(Name = "meses")] int meses)
        {
            return Ok(await _calculateInterestService.CalculateCompoundInterest(valorinicial, meses));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("calculajurosString")]
        public async Task<IActionResult> GetCompoundInterestResult([FromQuery(Name = "valorinicial")] string valorinicial,
                                                                   [FromQuery(Name = "meses")] int meses)
        {
            return Ok(await _calculateInterestService.CalculateCompoundInterest(valorinicial, meses));
        }
    }
}
