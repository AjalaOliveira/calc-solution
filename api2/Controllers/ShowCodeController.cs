using api2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers
{
    [ApiController]
    public class ShowCodeController : ControllerBase
    {
        ShowCodeService showCodeService = new ShowCodeService();

        [HttpGet]
        [AllowAnonymous]
        [Route("showmethecode")]
        public IActionResult GetRepositoryCode()
        {
            return Ok(showCodeService.ShowCodeRepositoryOnGitHub());
        }
    }
}
