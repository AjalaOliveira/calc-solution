using System.Linq;

namespace api2.Validations
{
    public class ValidateStringParameter
    {
        public string Validate(string initialValue)
        {
            if (initialValue.Contains(",") ||
                initialValue.ToString().Count(dot => dot == '.') > 1)
            {
                return "[ERRO] Valor inicial informado está em formato inválido. Valor informado '" + initialValue + "'. O Formato esperado é '0.00'";
            }

            return string.Empty;
        }
    }
}
