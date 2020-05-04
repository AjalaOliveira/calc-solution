using api1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        InterestRateService interestRateService = new InterestRateService();

        [HttpGet]
        [AllowAnonymous]
        [Route("taxaJuros")]
        public IActionResult GetInterestRate()
        {
            return Ok(interestRateService.GetInterestRate());
        }
    }
}
