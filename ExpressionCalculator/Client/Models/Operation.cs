namespace ExpressionCalculator.Client.Models
{
    public class Operation // clase que maneja los datos de cada operacion
    {
        public string Expression { get; set; } = string.Empty;
        public double Result { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string ClientId { get; set; } = string.Empty;

        public Operation() { }

        public Operation(string expression, double result, string clientId)
        {
            Expression = expression;
            Result = result;
            ClientId = clientId;
            Timestamp = DateTime.Now;
        }
    }
}