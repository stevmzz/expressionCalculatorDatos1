namespace ExpressionCalculator.Client.Services
{
    public class ExpressionValidator
    {
        // separamos los operadores en diferentes categorias
        private static readonly string[] Operators = { "+", "-", "*", "/", "%", "**", "&", "|", "^", "~" };
        private static readonly string[] Parentheses = { "(", ")" };

        public (bool isValid, string? errorMessage) ValidateExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return (false, "La expresión no puede estar vacía.");
            }

            expression = expression.Replace(" ", ""); // eliminar espacios en blanco

            if (!ContainsOnlyValidCharacters(expression))
            {
                return (false, "La expresión contiene caracteres no válidos.");
            }

            if (!HasBalancedParentheses(expression))
            {
                return (false, "Los paréntesis no están balanceados.");
            }

            if (StartsOrEndsWithOperator(expression))
            {
                return (false, "La expresión no puede empezar ni terminar con un operador.");
            }

            if (HasConsecutiveOperators(expression))
            {
                return (false, "No pueden haber operadores consecutivos.");
            }

            if (!HasValidNumbers(expression))
            {
                return (false, "Formato de números inválido.");
            }

            return (true, null);
        }

        private bool ContainsOnlyValidCharacters(string expression)
        {
            foreach (char c in expression)
            {
                if (!char.IsDigit(c) &&
                    !Operators.Contains(c.ToString()) &&
                    !Parentheses.Contains(c.ToString()) &&
                    c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool HasBalancedParentheses(string expression)
        {
            int count = 0;
            foreach (char c in expression)
            {
                if (c == '(')
                    count++;
                else if (c == ')')
                    count--;

                if (count < 0)
                    return false;
            }
            return count == 0;
        }

        private bool StartsOrEndsWithOperator(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return true;

            char firstChar = expression[0];
            char lastChar = expression[^1];

            return Operators.Contains(expression[0].ToString()) ||
                   Operators.Contains(expression[^1].ToString());
        }

        private bool HasConsecutiveOperators(string expression)
        {
            for (int i = 0; i < expression.Length - 1; i++)
            {
                string currentChar = expression[i].ToString();
                string nextChar = expression[i + 1].ToString();

                if (currentChar == "*" && nextChar == "*") // especial para la potencia
                {
                    i++; // saltar el siguiente *
                    continue;
                }

                if (Operators.Contains(currentChar) && Operators.Contains(nextChar))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasValidNumbers(string expression)
        {
            string temp = expression; // creamos una copia de la expresion para manipularla
            temp = temp.Replace("(", " ").Replace(")", " "); // removemos los parentesis

            foreach (var op in Operators) // removemos los operadores
            {
                temp = temp.Replace(op, " ");
            }

            var numbers = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // separamos los numeros

            foreach (var number in numbers) // verificamos que cada token sea un numero
            {
                if (!double.TryParse(number, out _))
                {
                    return false;
                }
            }
            return true;
        }

        public string CleanExpression(string expression) // metodo para obtener una representacion limpia de la expresion
        {
            // eliminar espacios extras
            return string.Join(" ", expression.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries));
        }
    }
}