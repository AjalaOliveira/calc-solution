using api2.ApiStartup;
using api2.Interfaces;
using Microsoft.Extensions.Options;

namespace api2.Services
{
    public class ShowCodeService : IShowCodeService
    {
        public string ShowCodeRepositoryOnGitHub()
        {
            return "https://github.com/AjalaOliveira/calc-solution";
        }
    }
}
