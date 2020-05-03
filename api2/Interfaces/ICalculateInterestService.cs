using System.Threading.Tasks;

namespace api2.Interfaces
{
    public interface ICalculateInterestService
    {
        Task<string> CalculateCompoundInterest(decimal initialValue, int months);
        Task<string> CalculateCompoundInterest(string initialValue, int months);
    }
}
