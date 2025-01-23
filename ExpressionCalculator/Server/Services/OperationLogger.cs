using CsvHelper; // para manejar el csv
using ExpressionCalculator.Server.Models;
using System.Globalization;
using System.IO;

namespace ExpressionCalculator.Server.Services
{
    public class OperationLogger
    {
        private const string LogFile = "operations.csv";
        private readonly object _lockObject = new object(); // sincroniza el acceso a los recursos compartidos

        public void LogOperation(Operation operation) // metodo para registrar una operacion en el csv
        {
            lock (_lockObject) // bloquea el acceso al csv
            {
                // abre o crea el archivo
                using (var stream = File.Open(LogFile, FileMode.Append))
                using (var writer = new StreamWriter(stream)) // crea un editor de texto
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecord(operation); // escribe el regitro en formato csv
                    csv.NextRecord(); // salto de linea
                }
            }
        }

        public List<Operation> GetOperationsByClientId(string clientId) // metodo para obtener operaciones filtradas por id
        {
            if (!File.Exists(LogFile)) return new List<Operation>(); // si el archivo no existe devuelve una lista vacia

            using (var reader = new StreamReader(LogFile)) // abre el archivo para lectura
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Operation>() // lee los registros de operation
                    .Where(op => op.ClientId == clientId) // filtra por id
                    .OrderByDescending(op => op.Timestamp) // ordenar por fecha más reciente
                    .ToList();
            }
        }
    }
}