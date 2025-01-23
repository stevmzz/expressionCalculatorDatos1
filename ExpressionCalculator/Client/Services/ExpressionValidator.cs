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

            if (HasMixedOperators(expression))
            {
                return (false, "No se pueden mezclar operadores lógicos y matemáticos en la misma expresión.");
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

        private bool IsOperator(string c) // metodo para verificar si es un operador
        {
            return MathOperators.Contains(c) || LogicalOperators.Contains(c);
        }

        private bool HasInvalidOperatorSequence(string expression)
        {
            for (int i = 0; i < expression.Length - 1; i++)
            {
                string currentChar = expression[i].ToString();
                string nextChar = expression[i + 1].ToString();

                // permitir numeros negativos despues de operadores o al inicio de la expresion
                if (currentChar == "-")
                {
                    // si es el primer caracter o viene despues de un operador o parentesis de apertura
                    if (i == 0 || IsOperator(expression[i - 1].ToString()) || expression[i - 1] == '(')
                    {
                        continue;
                    }
                }

                // manejo especial para potencia (**)
                if (currentChar == "*" && nextChar == "*")
                {
                    i++; // saltar el siguiente *
                    continue;
                }

                // verificar operadores consecutivos que no sean parte de un numero negativo
                if (IsOperator(currentChar) && IsOperator(nextChar) && nextChar != "-")
                {
                    return true;
                }
            }
            return false;
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

            if (expression[0] == '-' || expression[0] == '~') // el negativo y el not pueden estar al inicio o al final de la expresion
            {
                // verificar si el siguiente caracter es un numero o un parentesis
                if (expression.Length > 1 && (char.IsDigit(expression[1]) || expression[1] == '('))
                {
                    return false;
                }
            }

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

                if (nextChar == "-" || nextChar == "~") // permite negativos y not despues de un operador
                {
                    // permitir negativos despues de operadores o parentesis de apertura
                    if (IsOperator(currentChar) || currentChar == "(")
                    {
                        continue;
                    }
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

            foreach (var op in MathOperators) // removemos los operadores matematicos
            {
                temp = temp.Replace(op, " ");
            }

            foreach (var op in LogicalOperators)
            {
                temp = temp.Replace(op, " ");
            }

            var numbers = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // separamos los numeros

            foreach (var number in numbers) // verificamos que cada número sea un 0 o 1
            {
                if (IsOperatorInExpression(expression))
                {
                    if (!IsValidLogicalNumber(number)) // validacion para valores logicos
                    {
                        return false;
                    }
                }
                else
                {
                    if (!double.TryParse(number, out _)) // verificacion general para numeros validos
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool IsOperatorInExpression(string expression) // verifica si la expresion contiene operadores logicos
        {
            return LogicalOperators.Any(op => expression.Contains(op));
        }
        private bool IsValidLogicalNumber(string number)
        {
            return number == "0" || number == "1"; // acepta solo 0 o 1
        }

        public string CleanExpression(string expression) // metodo para obtener una representacion limpia de la expresion
        {
            // eliminar espacios extras
            return string.Join(" ", expression.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries));
        }
    }
}