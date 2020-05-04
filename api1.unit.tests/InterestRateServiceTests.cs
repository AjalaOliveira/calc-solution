using api1.Services;
using Xunit;

namespace api1.unit.tests
{
    public class InterestRateControllerTests
    {

        [Fact]
        public void InterestRateController_ShoulReturnInterestRate()
        {
            InterestRateService interestRateService = new InterestRateService();

            var result = interestRateService.GetInterestRate();

            Assert.Contains($"0,01", result);
        }

        [Fact]
        public void InterestRateController_ShoulNotReturnEmptyOrNullValue()
        {
            InterestRateService interestRateService = new InterestRateService();

            var result = interestRateService.GetInterestRate();

            Assert.NotNull(result.ToString());
            Assert.NotEmpty(result.ToString());
        }
    }
}