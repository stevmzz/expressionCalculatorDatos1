namespace ExpressionCalculator.Server.Models
{
    public class Operation
    {
        public string Expression { get; set; }
        public double Result { get; set; }
        public DateTime Timestamp { get; set; }
        public string ClientId { get; set; }

        public Operation()
        {
            Timestamp = DateTime.Now;
        }
    }
}