using System.Globalization;

namespace api2.Validations
{
    public class ValidateParameters
    {
        public string Validate(decimal initialValue, int months)
        {
            string result = null;
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.GetCultureInfo("pt-BR");

            //Verifica se valorInicial é um número decimal válido e se é maior que zero (0).
            if (!decimal.TryParse(initialValue.ToString(), style, culture, out _))
            {
                result = "O valor '" + initialValue.ToString() + "' atribuido ao parâmetro 'valorinicial' deve ser um número decimal válido.\n";
            }
            else if (initialValue <= 0)
            {
                result += "O valor atribuido ao parâmetro 'valorinicial' deve ser um número decimal maior que zero (0).\n";
            }

            //Verifica se meses é um número inteiro válido e se é maior que zero (0).
            if (!int.TryParse(months.ToString(), style, culture, out _))
            {
                result = "O valor '" + months.ToString() + "' atribuido ao parâmetro 'meses' deve ser um número inteiro válido.\n";
            }
            else if (months <= 0)
            {
                result += "O valor atribuido ao parâmetro 'meses' deve ser um número inteiro maior que zero (0).";
            }

            return result;
        }
    }
}