using CsvHelper;

namespace ExpressionCalculator.Server.Services
{
    public class OperationLogger
    {
        private const string LogFile = "operations.csv";
        private readonly object _lockObject = new object();
    }
}