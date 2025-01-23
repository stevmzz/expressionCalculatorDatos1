namespace ExpressionCalculator.Server.Models
{
    public class ExpressionTree
    {
        private Node? Root {  get; set; }

        public ExpressionTree()
        {
            Root = null;
        }

        public void BuildFromPostFix(string[] tokens) // construye el arbol a partir de una expresión en notacion postfija
        {
            Stack<Node> stack = new Stack<Node>(); // pila para almacenar nodos durante la construccion del arbol

            foreach (string token in tokens) // recorremos cada token de la expresion postfija
            {
                Node node = new Node(token); 

                if (!node.IsOperator()) // si el token es no es un operador lo agrega a la pila
                {
                    stack.Push(node);
                }
                else
                {
                    if (stack.Count < 2) // por si no ingresa mas de un operando
                    {
                        throw new InvalidOperationException("Expresión inválida: faltan operandos");
                    }

                    node.Right = stack.Pop(); // el operando mas reciente es el hijo derecho
                    node.Left = stack.Pop(); // el operando anterior es el hijo izquierdo
                    stack.Push(node); // el nodo operador con sus hijos se agrega a la pila
                }
            }

            Root = stack.Count > 0 ? stack.Pop() : null; // asignamos el nodo raiz

        }

        public double Evaluate() // evalua la expresion completa
        {
            if (Root == null) // si no hay ramas el arbol esta vacio
            {
                throw new InvalidOperationException("El árbol está vacío");
            }

            return EvaluateNode(Root);
        }

        public double EvaluateNode(Node? node) // metodo auxiliar para evaluar cada nodo recursivamente
        {
            if (node == null) // si el nodo es nulo tira una excepcion
            {
                throw new ArgumentNullException(nameof(node));
            }

            // si es un numero, lo convertimos y retornamos
            if (!node.IsOperator())
            {
                if (!double.TryParse(node.Value, out double value))
                {
                    throw new ArgumentException($"Valor inválido: {node.Value}");
                }
                return value;
            }

            // evaluamos recursivamente los subarboles
            double leftValue = EvaluateNode(node.Left);
            double rightValue = EvaluateNode(node.Right);

            // evaluación basica de operadores
            return node.Value switch
            {
                "+" => leftValue + rightValue,
                "-" => leftValue - rightValue,
                "*" => leftValue * rightValue,
                "/" => rightValue != 0
                    ? leftValue / rightValue
                    : throw new DivideByZeroException(),
                "%" => (leftValue / 100) * rightValue,
                "**" => Math.Pow(leftValue, rightValue),
		"&" => Convert.ToDouble(Convert.ToBoolean(leftValue) && Convert.ToBoolean(rightValue)),
		"|" => Convert.ToDouble(Convert.ToBoolean(leftValue) || Convert.ToBoolean(rightValue)),
		"^" => Convert.ToDouble(Convert.ToBoolean(leftValue) != Convert.ToBoolean(rightValue)),
		// "~" => (double)(~(int)rightValue), // Nota: operador unario, solo usa rightValue
                _ => throw new ArgumentException($"Operador no soportado: {node.Value}")
            };
        }

        public override string ToString() // obtiene una representacion string del arbol
        {
            return ToString(Root); 
        }

        public string ToString(Node? node) // para transformar a string
        {
            if (node == null) return "";

            if (node.IsOperator())
            {
                return $"({ToString(node.Left)} {node.Value} {ToString(node.Right)})";
            }

            return node.Value;
        }
    }
}
