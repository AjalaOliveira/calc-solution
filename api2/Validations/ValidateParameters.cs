namespace api2.Validations
{
    public class ValidateParameters
    {
        public string Validate(decimal initialValue, int months)
        {
            if (initialValue <= 0)
            {
                return $"[ERRO] O Valor inicial informado deve ser um número decimal maior que zero (0). Valor informado '{initialValue}'.";
            }

            if (months <= 0)
            {
                return $"[ERRO] O Valor informado no parâmetro 'meses' deve ser um número inteiro maior que zero (0). Valor informado '{months}'.";
            }

            return string.Empty;
        }
    }
}