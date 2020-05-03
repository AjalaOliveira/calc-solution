using api2.ApiStartup;
using api2.Interfaces;
using Microsoft.Extensions.Options;

namespace api2.Services
{
    public class ShowCodeService : IShowCodeService
    {
        private readonly RepositorySettings _repositorySettings;

        public ShowCodeService(IOptions<RepositorySettings> repositorySettings)
        {
            _repositorySettings = repositorySettings.Value;
        }
        public string ShowCodeRepositoryOnGitHub()
        {
            return _repositorySettings.Address;
        }
    }
}
