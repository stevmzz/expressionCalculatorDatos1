// En Services/ClientSocket.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculator.Client.Services
{
    public class ClientSocket
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private readonly string _serverIp;
        private readonly int _serverPort;

        public ClientSocket(string serverIp = "192.168.100.45", int serverPort = 8888)
        {
            _serverIp = serverIp;
            _serverPort = serverPort;
        }

        public async Task ConnectAsync()
        {
            _client = new TcpClient();
            await _client.ConnectAsync(_serverIp, _serverPort);
            _stream = _client.GetStream();
        }

        public async Task SendExpressionAsync(string expression)
        {
            if (_stream == null) throw new InvalidOperationException("No conectado al servidor");

            byte[] data = Encoding.UTF8.GetBytes(expression + "\n");
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<string> ReceiveResponseAsync()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}