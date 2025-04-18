﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ExpressionCalculator.Client.Models;

namespace ExpressionCalculator.Client.Services
{
    public class ClientSocket // clase para la comunicación del cliente
    {
        private TcpClient _client; // cliente para manejar coneccion con server
        private NetworkStream _stream; // flujo para enviar y recibir informacion
        private readonly string _serverIp; // ip del server
        private readonly int _serverPort; // puerto del server
        public string ClientId { get; private set; } // getter y setter del id del cliente

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

            // recibir el id del cliente
            byte[] buffer = new byte[1024];
            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length); // lee y almacena los datos del server
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            if (response.StartsWith("CLIENT_ID:")) // comprueba si la respuesta contiene el clientid
            {
                ClientId = response.Substring("CLIENT_ID:".Length);
            }
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

        public async Task<List<Operation>> GetOperationsHistoryAsync()
        {
            await SendExpressionAsync("GET_HISTORY"); // solicita el historial
            string response = await ReceiveResponseAsync();

            return response.Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line =>
                {
                    var parts = line.Split(',');
                    return new Operation // datos de la operacion
                    {
                        Timestamp = DateTime.ParseExact(parts[0], "yyyy-MM-dd", null).Date,
                        Expression = parts[1],
                        Result = double.Parse(parts[2]),
                        ClientId = parts[3]
                    };
                })
                .Where(op => op.ClientId == ClientId) // filtra las operaciones que coinciden con el id
                .OrderByDescending(op => op.Timestamp) // ordena las operaciones
                .ToList(); // convierte la secuencia en una lsita de operaciones
        }

        public void Disconnect() // metodo para desconectar cliente del server
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}