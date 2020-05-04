using api2.ApiStartup;
using api2.Interfaces;
using api2.Validations;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace api2.Services
{
    public class CalculateInterestService : ICalculateInterestService
    {
        private readonly Api1Settings _api1Settings;
        private double _interestRate;
        private string _api1IntegrationStatus;


        public CalculateInterestService(IOptions<Api1Settings> api1Settings)
        {
            _api1Settings = api1Settings.Value;
        }

        public async Task<string> CalculateCompoundInterest(decimal initialValue, int months)
        {
            var validationResult = new ValidateParameters().Validate(initialValue, months);

            if (!string.IsNullOrEmpty(validationResult))
            {
                return validationResult;
            }

            await GetAndSetInterestRate();

            if (!string.IsNullOrEmpty(_api1IntegrationStatus))
            {
                return _api1IntegrationStatus;
            }

            return (Math.Truncate(100 * (initialValue * (decimal)Math.Pow((1 + _interestRate), (double)months))) / 100).ToString("#0.00");
        }

        public async Task<string> CalculateCompoundInterestStringValue(string initialValue, int months)
        {
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

            await GetAndSetInterestRate();

            if (!string.IsNullOrEmpty(_api1IntegrationStatus))
            {
                return _api1IntegrationStatus;
            }

            initialValue = initialValue.Replace(".", ",");
            var initialValueUsed = decimal.Parse(initialValue, CultureInfo.GetCultureInfo("pt-BR"));

            return (Math.Truncate(100 * (initialValueUsed * (decimal)Math.Pow((1 + _interestRate), (double)months))) / 100).ToString("#0.00");
        }

        private async Task GetAndSetInterestRate()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync(_api1Settings.Address);

                    if (string.IsNullOrEmpty(response))
                    {
                        _api1IntegrationStatus = "[API1] - O serviço integrado não retornou nenhum valor.";
                    }
                    else
                    {
                        try
                        {
                            _interestRate = double.Parse(response);
                        }
                        catch (Exception)
                        {
                            _api1IntegrationStatus = $"[API1] - O serviço integrado retornou um valor em formato inválido. Resposta: {response}";
                        }
                    }
                }
            }
            catch (Exception)
            {
                _api1IntegrationStatus = "[API1] - Ocorreu uma falha durante tentativa de integração com o serviço.";
            }
        }
    }
}
