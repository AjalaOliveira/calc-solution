using System;
using System.Globalization;
using System.Linq;

namespace api2.Validations
{
    public class ValidateStringParameter
    {
        public string Validate(string initialValue, int months)
        {
            if (initialValue.Contains(",") ||
                initialValue.ToString().Count(dot => dot == '.') > 1)
            {
                return $"[ERRO] O Valor inicial informado está em formato inválido. Valor informado '{initialValue}'. O Formato esperado é '0.00'";
            }

            if (months <= 0)
            {
                return $"[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0). Valor informado '{months}'.";
            }

            return string.Empty;
        }

        public string ValidateDecimal(string initialValue)
        {
            try
            {
                initialValue = initialValue.Replace(".", ",");
                var value = decimal.Parse(initialValue, CultureInfo.GetCultureInfo("pt-BR"));
                if (value <= 0)
                {
                    return $"[ERRO] O Valor inicial informado deve ser um número decimal maior que zero (0). Valor informado '{initialValue}'.";
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return $"[ERRO] O Valor inicial informado está em formato inválido. Valor informado '{initialValue}'. O Formato esperado é '0.00'";
            }
        }
    }
}
