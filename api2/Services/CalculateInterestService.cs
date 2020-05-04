using api2.ApiStartup;
using api2.Interfaces;
using api2.Tools;
using Microsoft.Extensions.Options;
using System;
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
            await GetAndSetInterestRate();

            if (!string.IsNullOrEmpty(_api1IntegrationStatus))
            {
                return _api1IntegrationStatus;
            }

            return new CalculateInterest().CalculateCompoundInterest(initialValue, _interestRate, months);
        }

        public async Task<string> CalculateCompoundInterestStringValue(string initialValue, int months)
        {
            await GetAndSetInterestRate();

            if (!string.IsNullOrEmpty(_api1IntegrationStatus))
            {
                return _api1IntegrationStatus;
            }

            return new CalculateInterest().CalculateCompoundInterestStringValue(initialValue, _interestRate, months);
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
