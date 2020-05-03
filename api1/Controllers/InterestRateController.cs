using api1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        private readonly IInterestRateService _interestRate;

        public InterestRateController(IInterestRateService interestRate)
        {
            _interestRate = interestRate;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("taxaJuros")]
        public IActionResult GetInterestRate()
        {
            return Ok(_interestRate.GetInterestRate());
        }
    }
}
