namespace ExpressionCalculator.Server.Models
{
    public class Node
    {
        public string Value { get; set; } // valor del nodo (operando u operador)
        public Node? Left { get; set; } // hijo izquierdo
        public Node? Right { get; set; } // hijo derecho

        public Node(string value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public bool IsOperator()
        {
            return Value is "+" or "-" or "*" or "/" or "%" or "**" or "&" or "|" or "^" or "~";
        }
    }
}