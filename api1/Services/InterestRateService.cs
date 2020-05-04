using api1.Interfaces;

namespace api1.Services
{
    public class InterestRateService : IInterestRateService
    {
        public string GetInterestRate()
        {
            return "0,01";
        }
    }
}
