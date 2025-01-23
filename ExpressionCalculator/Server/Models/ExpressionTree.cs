using System.Globalization;

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

            Console.WriteLine("Tokens procesados: " + string.Join(", ", tokens)); // Mostrar tokens para depuración

            foreach (string token in tokens) // recorremos cada token de la expresion postfija
            {
                Node node = new Node(token);

                if (!node.IsOperator()) // si el token no es un operador lo agrega a la pila
                {
                    Console.WriteLine($"Push en pila: {token}"); // Depuración
                    stack.Push(node);
                }
                else
                {
                    if (stack.Count < 2) // por si no ingresa más de un operando
                    {
                        throw new InvalidOperationException($"Expresión inválida: faltan operandos al procesar '{token}'");
                    }

                    node.Right = stack.Pop(); // el operando más reciente es el hijo derecho
                    node.Left = stack.Pop(); // el operando anterior es el hijo izquierdo
                    Console.WriteLine($"Nodo operador creado: {token}, Left: {node.Left.Value}, Right: {node.Right.Value}"); // Depuración
                    stack.Push(node); // el nodo operador con sus hijos se agrega a la pila
                }
            }

            Root = stack.Count > 0 ? stack.Pop() : null; // asignamos el nodo raíz
            if (stack.Count > 0)
            {
                throw new InvalidOperationException("Expresión inválida: sobran operandos");
            }
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
                if (!double.TryParse(node.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)) // para validar el uso de decimales se usa cultureinfo
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
                "%" => rightValue != 0
                    ? leftValue % rightValue
                    : throw new DivideByZeroException(),
                "**" => Math.Pow(leftValue, rightValue),
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