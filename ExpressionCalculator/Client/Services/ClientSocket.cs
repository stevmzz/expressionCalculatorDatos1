using System.Net.Sockets;

namespace ExpressionCalculator.Client.Services
{
    public class ClientSocket
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private const int Port = 8888; // Puerto por defecto
        private const string Server = "127.0.0.1"; // localhost
    }
}