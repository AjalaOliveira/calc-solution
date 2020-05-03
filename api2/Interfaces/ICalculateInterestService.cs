using System.Threading.Tasks;

namespace api2.Interfaces
{
    public interface ICalculateInterestService
    {
        Task<string> CalculateCompoundInterest(decimal initialValue, int months);
        Task<string> CalculateCompoundInterestStringValue(string initialValue, int months);
    }
}
