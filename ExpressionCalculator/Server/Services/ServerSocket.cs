using System.Net;
using System.Net.Sockets;

namespace ExpressionCalculator.Server.Services
{
    public class ServerSocket
    {
        private TcpListener _listener;
        private readonly List<TcpClient> _clients;
        private const int Port = 8888;
        private bool _isRunning;

        public ServerSocket()
        {
            _clients = new List<TcpClient>();
            _isRunning = false;
        }
    }
}