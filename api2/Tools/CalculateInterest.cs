using api2.Validations;
using System;
using System.Globalization;

namespace api2.Tools
{
    public class CalculateInterest
    {
        public string CalculateCompoundInterest(decimal initialValue, double interestRate, int months)
        {
            var validateInterestRate = CheckIfInterestRateHasNegativeValue(interestRate);

            if (!string.IsNullOrEmpty(validateInterestRate))
            {
                return validateInterestRate;
            }

            var validationResult = new ValidateParameters().Validate(initialValue, months);

            if (!string.IsNullOrEmpty(validationResult))
            {
                return validationResult;
            }

            return (Math.Truncate(100 * (initialValue * (decimal)Math.Pow((1 + interestRate), (double)months))) / 100).ToString("#0.00"); ;
        }

        public string CalculateCompoundInterestStringValue(string initialValue, double interestRate, int months)
        {
            var validateInterestRate = CheckIfInterestRateHasNegativeValue(interestRate);

            if (!string.IsNullOrEmpty(validateInterestRate))
            {
                return validateInterestRate;
            }

            var validateParameters = new ValidateStringParameter();

            var validationStringParameterResult = validateParameters.Validate(initialValue, months);

            if (!string.IsNullOrEmpty(validationStringParameterResult))
            {
                return validationStringParameterResult;
            }

            var validDecimalParameter = validateParameters.ValidateDecimal(initialValue);

            if (!string.IsNullOrEmpty(validDecimalParameter))
            {
                return validDecimalParameter;
            }

            initialValue = initialValue.Replace(".", ",");
            var initialValueUsed = decimal.Parse(initialValue, CultureInfo.GetCultureInfo("pt-BR"));

            return (Math.Truncate(100 * (initialValueUsed * (decimal)Math.Pow((1 + interestRate), (double)months))) / 100).ToString("#0.00"); ;
        }

        private string CheckIfInterestRateHasNegativeValue(double interestRate)
        {
            if (interestRate < 0)
            {
                return $"[API1] - O serviço integrado retornou um valor para taxa de juros negativo. Resposta: {interestRate}";
            }
            return string.Empty;
        }
    }
}
