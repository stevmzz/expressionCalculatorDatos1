using ExpressionCalculator.Server.Models;

namespace ExpressionCalculator.Server.Services
{
    public class ExpressionEvaluator // maneja la conversión de la expresión infija (como la ingresa el usuario) a postfija
    {

            private static int  GetOperatorPrecedence(string op) // obtiene la precedencia de los operadores
        {
            return op switch // define la prioridad de los operadores
            {
                "~" => 6,  // Mayor precedencia para NOT
                "**" => 5,
                "*" or "/" or "%" => 4,
                "+" or "-" => 3,
                "&" or "|" or "^" => 2,
                "(" or ")" => 1,
                _ => throw new ArgumentException($"Operador no válido: {op}")
            };
        }

        private static string[] TokenizeExpression(string expression) // separa la expresión en tokens individuales
        {
            var tokens = new List<string>(); // lista para almacenar tokens
            var currentNumber = ""; // variable temporal para acumular digitos
            bool lastWasOperator = true; // para detectar numeros negativos

            for (int i = 0; i < expression.Length; i++) // recorremos la expresíon completa
            {
                char c = expression[i];

                if (char.IsWhiteSpace(c)) // si hay espacion en blanco
                {
                    continue;
                }

                if (c == '-' && lastWasOperator || char.IsDigit(c) ||  c == ',' || c == '.') // si el character es digito o decimal
                {
                    currentNumber += c;
                    lastWasOperator = false;
                }
                else
                {
                    if (currentNumber.Length > 0)
                    {
                        tokens.Add(currentNumber); // agrega el numero acumulado como token
                        currentNumber = ""; // reincia
                    }

                    if (c == '*' && i + 1 < expression.Length && expression[i + 1] == '*') // si es potencia
                    {
                        tokens.Add("**"); 
                        i++;
                    }
                    else
                    {
                        tokens.Add(c.ToString()); // agrega cualquier otro operador como token
                    }

                    lastWasOperator = c != ')';
                }
            }

            if (currentNumber.Length > 0) // si currentNumber contiene un numero lo agrega a la lista
            {
                tokens.Add(currentNumber);
            }

            return tokens.ToArray(); // convierte la lista de tokens en un arreglo
        }

        private static string[] InfixToPostfix(string[] tokens) // convierte de notacion infija a postfija
        {
            var output = new List<string>();
            var operators = new Stack<string>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _)) // si es un numero va a la salida
                {
                    output.Add(token);
                }
                else if (token == "(") // si abre parentesis
                {
                    operators.Push(token);
                }
                else if (token == ")") // si cierra parentesis
                {
                    while (operators.Count > 0 && operators.Peek() != "(") // mientras no encontremos un parentesis de apertura en la pila
                    {
                        output.Add(operators.Pop()); // movemos operadores desde la pila a la salida
                    }

                    if (operators.Count > 0 && operators.Peek() == "(") // si se encuntra un parentesis que abre, se elimina de la pila
                    {
                        operators.Pop();
                    }
                    else // si no encontramos un parentesis de apertura, hay un error
                    {
                        throw new ArgumentException("Paréntesis incorrectos");
                    }
                }
                else // si es un operador
                {
                    while (operators.Count > 0 && operators.Peek() != "(" && // mientras haya operadores en la pila
                           GetOperatorPrecedence(operators.Peek()) >= GetOperatorPrecedence(token))
                    {
                        output.Add(operators.Pop()); // movemos operadores a la salida
                    }
                    operators.Push(token); // agregamos el operador actual a la pila
                }
            }

            while (operators.Count > 0) // procesamos cualquier operador restante en la pila
            {
                if (operators.Peek() == "(")
                {
                    throw new ArgumentException("Paréntesis no balanceados");
                }
                output.Add(operators.Pop());
            }

            return output.ToArray(); // convertimos la lista de salida a un arreglo y lo devolvemos
        }

        public double EvaluateExpression(string expression) // metodo para manejar una expresion
        {
            try
            {

                // Primero manejamos los casos especiales de NOT de forma directa
                if (expression.Contains("~"))
                {
                    // Reemplazamos ~1 por 0 y ~0 por 1
                    expression = expression.Replace("~1", "0");
                    expression = expression.Replace("~0", "1");
                }

                var tokens = TokenizeExpression(expression); // tokenizamos la expresión
                var postfixTokens = InfixToPostfix(tokens); // convertimos a postfija

                // creamos y evaluamos el árbol
                var tree = new Models.ExpressionTree();
                tree.BuildFromPostFix(postfixTokens);
                return tree.Evaluate();
            }
            // manejador de excepciones
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("División por cero en la expresión");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Error en la expresión: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al evaluar la expresión: {ex.Message}");
            }
        }
    }
}