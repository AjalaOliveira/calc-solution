using api2.Tools;
using Xunit;

namespace api2.unit.tests
{

    public class CalculateInterestTest
    {

        [Fact]
        public void CalculateCompoundInterest_ShoulReturn105_10()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 100;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal($"105.10", result);
        }

        [Fact]
        public void CalculateCompoundInterest_ShoulReturn105_10_1()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 100.00M;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal($"105.10", result);
        }

        [Fact]
        public void CalculateCompoundInterest_ShoulReturn0_10()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 0.1M;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal($"0.10", result);
        }

        [Fact]
        public void CalculateCompoundInterest_ShoulReturnErrorWhenInitialValueIsLessThanZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = -0.1M;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor inicial informado deve ser um número decimal maior que zero (0).", result);
        }

        [Fact]
        public void CalculateCompoundInterest_ShoulReturnErrorWhenInitialValueIsZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 0;
            double interestRate = 0.01;
            int months = 5;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor inicial informado deve ser um número decimal maior que zero (0).", result);
        }

        [Fact]
        public void CalculateCompoundInterest_ShoulReturnErrorWhenMonthsIsLessThanZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 1;
            double interestRate = 0.01;
            int months = -1;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0).", result);
        }

        [Fact]
        public void CalculateCompoundInterest_ShoulReturnErrorWhenMonthsIsZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 1;
            double interestRate = 0.01;
            int months = 0;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0).", result);
        }

        [Fact]
        public void CalculateCompoundInterest_ShoulReturnErrorWhenInterestRateIsLessThanZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            decimal initialValue = 1;
            double interestRate = -0.01;
            int months = 0;

            var result = calculateInterest.CalculateCompoundInterest(initialValue, interestRate, months);

            Assert.Equal("[API1] - O serviço integrado retornou um valor para taxa de juros negativo.", result);
        }

        [Theory]
        [InlineData("0,1")]
        [InlineData("1,0")]
        [InlineData("1,1")]
        public void CalculateCompoundInterestStringValue__ShoulReturnErroWhenInitialValueHasAComma(string initialValue)
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            double interestRate = 0.01;
            int months = 1;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor inicial informado está em formato inválido.", result);
        }

        [Theory]
        [InlineData("1.250.120")]
        [InlineData("2.135.030")]
        [InlineData("25.045.915")]
        [InlineData("1.130.800.00")]
        [InlineData("20.354.320.050")]
        public void CalculateCompoundInterestStringValue__ShoulReturnErroWhenInitialValueHasMoreThanOneDot(string initialValue)
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            double interestRate = 0.01;
            int months = 1;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal($"[ERRO] O Valor inicial informado está em formato inválido.", result);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("%")]
        [InlineData("/")]
        public void CalculateCompoundInterestStringValue__ShoulReturnErroWhenInitialValueIsNotNumber(string initialValue)
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            double interestRate = 0.01;
            int months = 1;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor inicial informado está em formato inválido.", result.ToString());
        }

        [Theory]
        [InlineData("0.1")]
        [InlineData("1.0")]
        [InlineData("1.1")]
        public void CalculateCompoundInterestStringValue__ShoulReturnErroWhenMonthsIsLessThanZero(string initialValue)
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            double interestRate = 0.01;
            int months = -1;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0).", result);
        }

        [Theory]
        [InlineData("0.1")]
        [InlineData("1.0")]
        [InlineData("1.1")]
        public void CalculateCompoundInterestStringValue__ShoulReturnErroWhenMonthsIsZero(string initialValue)
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            double interestRate = 0.01;
            int months = 0;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0).", result);
        }

        [Fact]
        public void CalculateCompoundInterestStringValue__ShoulReturnErroWhenInitialValueIsZero()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            string initialValue = "0.00";
            double interestRate = 0.01;
            int months = 1;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("[ERRO] O Valor inicial informado deve ser um número decimal maior que zero (0).", result);
        }

        [Fact]
        public void CalculateCompoundInterestStringValue__ShoulNotReturnErroWhenInitialValueIsValidDecimal()
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            string initialValue = "0.01";
            double interestRate = 0.01;
            int months = 1;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("0.01", result);
        }

        [Theory]
        [InlineData("0.1")]

        public void CalculateCompoundInterestStringValue__ShoulNotReturnErroWhenInitialValueAndMonthsAreValid(string initialValue)
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            double interestRate = 0.01;
            int months = 1;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("0.10", result);
        }

        [Theory]
        [InlineData("0.1")]
        public void CalculateCompoundInterestStringValue__ShoulReturnErrorWhenInterestRateIsLessThanZero(string initialValue)
        {
            CalculateInterest calculateInterest = new CalculateInterest();
            double interestRate = -0.01;
            int months = 0;

            var result = calculateInterest.CalculateCompoundInterestStringValue(initialValue, interestRate, months);

            Assert.Equal("[API1] - O serviço integrado retornou um valor para taxa de juros negativo.", result);
        }
    }
}
