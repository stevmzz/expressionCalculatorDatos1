using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculator.Server.Services
{
    public class ServerSocket
    {
        private TcpListener _tcpListener;
        private readonly int _port;
        private bool _isRunning;

        public ServerSocket(int port = 8888)
        {
            _port = port;
            _isRunning = false;
        }

        public async Task startAsync()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Any, _port);
                _tcpListener.Start();
                _isRunning = true;
                Console.WriteLine($"Servidor iniciado en puerto: {_port}");

                while (_isRunning)
                {
                    TcpClient client = await _tcpListener.AcceptTcpClientAsync();
                    Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
                    _ = handleClientAsync(client);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error del servidor: {ex.Message}");
                Stop();
            }
        }

        private async Task handleClientAsync(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    StringBuilder messageBuilder = new StringBuilder();

                    while (client.Connected)
                    {
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                        if (bytesRead == 0) // cliente desconectado
                        {
                            break;
                        }

                        string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        messageBuilder.Append(receivedData);

                        if (receivedData.EndsWith("\n"))
                        {
                            string expression = messageBuilder.ToString().Trim();
                            Console.WriteLine($"Expresión recibida: {expression}");

                            string result = "Resultado provisional";

                            byte[] response = Encoding.UTF8.GetBytes(result + "\n");
                            await stream.WriteAsync(response, 0, response.Length);

                            messageBuilder.Clear();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error manejando cliente: {ex.Message}");
            }

            finally
            {
                client.Close();
                Console.WriteLine("Cliente desconectado");
            }
        }

        public void Stop()
        {
            _isRunning = false;
            _tcpListener.Stop();
            Console.WriteLine("Servidor detenido");
        }
    }
}