// En Services/ClientSocket.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculator.Client.Services
{
    public class ClientSocket // clase para la comunicación del cliente
    {
        private TcpClient _client; // cliente para manejar coneccion con server
        private NetworkStream _stream; // flujo para enviar y recibir informacion
        private readonly string _serverIp; // ip del server
        private readonly int _serverPort; // puerto del server

        public ClientSocket(string serverIp = "192.168.100.45", int serverPort = 8888)
        {
            _serverIp = serverIp;
            _serverPort = serverPort;
        }

        public async Task ConnectAsync() // metodo para conectarse de forma asincronica
        {
            _client = new TcpClient(); // crea un cliente
            await _client.ConnectAsync(_serverIp, _serverPort); // intenta conectarse
            _stream = _client.GetStream(); // obtiene flujo de datos
        }

        public async Task SendExpressionAsync(string expression) // metodo para enviar expresion
        {
            if (_stream == null) throw new InvalidOperationException("No conectado al servidor");

            byte[] data = Encoding.UTF8.GetBytes(expression + "\n");
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<string> ReceiveResponseAsync() // metodo para recibir respuesta del server
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        }

        public void Disconnect() // metodo para desconectar cliente del server
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}