using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.Threading.Tasks;
using ExpressionCalculator.Server.Models;

namespace ExpressionCalculator.Server.Services
{
    public class ServerSocket // clase del servidor tcp
    {
        private TcpListener _tcpListener; // escuchar conecciones
        private readonly int _port; // puerto en el que escucha conecciones
        private bool _isRunning; // indica si el server corre
        private ExpressionEvaluator _evaluator; // para evaluar las expresiones
        private OperationLogger _logger; // registra operaciones de los clientes

        public ServerSocket(int port = 8888) // constructor
        {
            _port = port;
            _isRunning = false;
            _evaluator = new ExpressionEvaluator();
            _logger = new OperationLogger();
        }

        public async Task startAsync() // metodo para iniciar server
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Any, _port); // escucha cualquier ip y el puerto especifico
                _tcpListener.Start();
                _isRunning = true;
                Console.WriteLine($"Servidor iniciado en puerto: {_port}");

                while (_isRunning) // bucle para aceptar conecciones
                {
                    TcpClient client = await _tcpListener.AcceptTcpClientAsync(); // en espera de coneccion
                    Console.WriteLine($"Cliente conectado: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
                    _ = handleClientAsync(client); // maneja el cliente independientemente
                }
            }

            catch (Exception ex) // manejo de errores
            {
                Console.WriteLine($"Error del servidor: {ex.Message}");
                Stop();
            }
        }

        private string GenerateUniqueClientId() // metodo para generar id unico para cada cliente nuevo
        {
            return Guid.NewGuid().ToString();
        }

        private async Task handleClientAsync(TcpClient client) // metodo para manejar la coneccion con un cliente
        {
            string clientId = GenerateUniqueClientId(); // genera un id para cada cliente

            try
            {
                using (NetworkStream stream = client.GetStream()) // usando red del cliente
                {
                    byte[] clientIdBytes = Encoding.UTF8.GetBytes($"CLIENT_ID:{clientId}\n"); // convierte el id del cliente a bytes.
                    await stream.WriteAsync(clientIdBytes, 0, clientIdBytes.Length);
                    byte[] buffer = new byte[1024]; // buffer para leer datos
                    StringBuilder messageBuilder = new StringBuilder(); // construye mensaje recibido

                    while (client.Connected) // mientras el cliente está conectado
                    {
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length); // lee datos del cliente

                        if (bytesRead == 0) // cliente desconectado
                        {
                            break;
                        }

                        string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead); // convierte datos a string
                        messageBuilder.Append(receivedData); // agrega los datos al mensaje

                        if (receivedData.EndsWith("\n")) // si el mensaje está completo
                        {
                            string expression = messageBuilder.ToString().Trim();

                            if (!string.IsNullOrWhiteSpace(expression)) // para evitar que se procesen lineas vacías
                            {
                                Console.WriteLine("------------------------");
                                Console.WriteLine($"Expresión recibida: {expression}");

                                try
                                {
                                    if (expression == "GET_HISTORY") // Si el cliente solicita el historial de operaciones.
                                    {
                                        var history = _logger.GetOperationsByClientId(clientId); // Obtiene el historial del cliente.

                                        string historyCsv = string.Join("\n", history.Select(op =>
                                            $"{op.Timestamp:yyyy-MM-dd},{op.Expression},{op.Result},{op.ClientId}")); // Convierte el historial a formato CSV.

                                        byte[] responseData = Encoding.UTF8.GetBytes(historyCsv + "\n"); // Convierte el historial a bytes.
                                        await stream.WriteAsync(responseData, 0, responseData.Length); // Envía el historial al cliente.
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Intentando evaluar expresión: {expression}");
                                        double result = _evaluator.EvaluateExpression(expression); // para guardar el resultado de la expresion
                                        Console.WriteLine($"Resultado calculado: {result}");

                                        Operation operation = new Operation
                                        {
                                            Expression = expression,
                                            Result = result,
                                            ClientId = clientId
                                        };
                                        _logger.LogOperation(operation); // registra la operación en el historial

                                        string response = result.ToString() + "\n";
                                        byte[] responseData = Encoding.UTF8.GetBytes(response); // convierte en bytes y lo manda al cliente
                                        await stream.WriteAsync(responseData, 0, responseData.Length);
                                    }
                                }
                                catch (Exception ex) // manejo de errores
                                {
                                    Console.WriteLine($"Error al procesar: {ex.Message}");
                                    string errorResponse = $"Error: {ex.Message}\n";
                                    byte[] errorData = Encoding.UTF8.GetBytes(errorResponse);
                                    await stream.WriteAsync(errorData, 0, errorData.Length);
                                }

                                messageBuilder.Clear(); // limpia para el siguiente cliente
                            }
                        }
                    }
                }
            }

            catch (Exception ex) // manejo de errores durante la comunicacion
            {
                Console.WriteLine($"Error manejando cliente: {ex.Message}");
            }

            finally // se asegura que el cliente se desconecte
            {
                client.Close();
                Console.WriteLine("Cliente desconectado");
                Console.WriteLine("------------------------");
            }
        }

        public void Stop() // metodo para detener el server
        {
            _isRunning = false;
            _tcpListener.Stop();
            Console.WriteLine("Servidor detenido");
        }
    }
}