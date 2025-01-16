namespace ExpressionCalculator.Client.Services
{
    public class ExpressionValidator
    {
        private readonly HashSet<char> _validOperators;

        public ExpressionValidator()
        {
            _validOperators = new HashSet<char> { '+', '-', '*', '/', '%', '&', '|', '^', '~', '(', ')' };
        }
    }
}