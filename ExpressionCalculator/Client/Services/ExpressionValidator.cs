namespace ExpressionCalculator.Client.Services
{
    public class ExpressionValidator
    {
        // separamos los operadores en diferentes categorias
        private static readonly string[] MathOperators = { "+", "-", "*", "/", "%", "**" };
        private static readonly string[] LogicalOperators = { "&", "|", "^", "~" };
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

        private bool ContainsOnlyValidCharacters(string expression) // metodo que recorre cada token y verifica que sean validos
        {
            var allOperators = MathOperators.Concat(LogicalOperators).Concat(Parentheses);
            foreach (char c in expression)
            {
                if (!char.IsDigit(c) &&
                    !allOperators.Contains(c.ToString()) &&
                    c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool HasMixedOperators(string expression) // metodo para verificar si combina operadores
        {
            bool hasMathOperator = MathOperators.Any(op => expression.Contains(op));
            bool hasLogicalOperator = LogicalOperators.Any(op => expression.Contains(op));

            return hasMathOperator && hasLogicalOperator;
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

        private bool StartsOrEndsWithOperator(string expression) // metodo para verifiacar si termina o empieza con un operador
        {
            if (string.IsNullOrEmpty(expression)) return true;

            var allOperators = MathOperators.Concat(LogicalOperators);
            return allOperators.Contains(expression[0].ToString()) ||
                   allOperators.Contains(expression[^1].ToString());
        }

        private bool HasConsecutiveOperators(string expression) // metodo para verificar si contiene dos operadores seguidos
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

                var allOperators = MathOperators.Concat(LogicalOperators);
                if (allOperators.Contains(currentChar) && allOperators.Contains(nextChar))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasValidNumbers(string expression) // metodo para verificar que son numeros validos
        {
            string temp = expression; // creamos una copia de la expresion para manipularla
            temp = temp.Replace("(", " ").Replace(")", " "); // removemos los parentesis

            foreach (var op in MathOperators.Concat(LogicalOperators)) // removemos los operadores
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