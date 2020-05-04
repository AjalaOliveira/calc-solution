using api2.Tools;
using Xunit;

namespace api2.unit.tests
{

    public class CalculateInterestTest
    {

        [Fact]
        public void CalculateInterestCompound_ShoulReturn105_10()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 100;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"105,10", result);
        }

        [Fact]
        public void CalculateInterestCompound_ShoulReturn105_10_1()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 100.00M;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"105,10", result);
        }

        [Fact]
        public void CalculateInterestCompound_ShoulReturn0_10()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 0.1M;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"0,10", result);
        }

        [Fact]
        public void CalculateInterestCompound_ShoulReturnErrorWhenInitialValueIsLessThanZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = -0.1M;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"[ERRO] O Valor inicial informado deve ser um número decimal maior que zero (0). Valor informado '{initialValue}'.", result);
        }

        [Fact]
        public void CalculateInterestCompound_ShoulReturnErrorWhenInitialValueIsZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 0;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"[ERRO] O Valor inicial informado deve ser um número decimal maior que zero (0). Valor informado '{initialValue}'.", result);
        }

        [Fact]
        public void CalculateInterestCompound_ShoulReturnErrorWhenMonthsIsLessThanZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 1;
            double interestRate = 0.01;
            int months = -1;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0). Valor informado '{months}'.", result);
        }

        [Fact]
        public void CalculateInterestCompound_ShoulReturnErrorWhenMonthsIsZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 1;
            double interestRate = 0.01;
            int months = 0;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0). Valor informado '{months}'.", result);
        }

        [Fact]
        public void CalculateInterestCompound_ShoulReturnErrorWhenInterestRateIsLessThanZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 1;
            double interestRate = -0.01;
            int months = 0;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Contains($"[API1] - O serviço integrado retornou um valor para taxa de juros negativo. Resposta: {interestRate}", result);
        }

    }
}
