using api2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers
{
    [ApiController]
    public class ShowCodeController : ControllerBase
    {
        private readonly IShowCodeService _showCodeService;

        public ShowCodeController(IShowCodeService showCodeService)
        {
            _showCodeService = showCodeService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("showmethecode")]
        public IActionResult GetRepositoryCode()
        {
            return Ok(_showCodeService.ShowCodeRepositoryOnGitHub());
        }
    }
}
