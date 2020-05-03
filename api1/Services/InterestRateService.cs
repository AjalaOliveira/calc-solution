using api1.ApiStartup;
using api1.Interfaces;
using Microsoft.Extensions.Options;

namespace api1.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly InterestRateSettings _interestRate;

        public InterestRateService(IOptions<InterestRateSettings> interestRate)
        {
            _interestRate = interestRate.Value;
        }
        public string GetInterestRate()
        {
            return _interestRate.Value.ToString("#0.00");
        }
    }
}
