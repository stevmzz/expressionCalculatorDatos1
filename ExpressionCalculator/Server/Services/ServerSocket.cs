﻿using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculator.Server.Services
{
    public class ServerSocket // clase del servidor tcp
    {
        private TcpListener _tcpListener; // escuchar conecciones
        private readonly int _port; // puerto en el que escucha conecciones
        private bool _isRunning; // indica si el server corre
        private ExpressionEvaluator _evaluator; // para evaluar las expresiones

        public ServerSocket(int port = 8888) // constructor
        {
            _port = port;
            _isRunning = false;
            _evaluator = new ExpressionEvaluator();
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

        private async Task handleClientAsync(TcpClient client) // metodo para manejar la coneccion con un cliente
        {
            try
            {
                using (NetworkStream stream = client.GetStream()) // usando red del cliente
                {
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
                                    Console.WriteLine($"Intentando evaluar expresión: {expression}");
                                    double result = _evaluator.EvaluateExpression(expression); // para guardar el resultado de la expresion
                                    Console.WriteLine($"Resultado calculado: {result}");
                                    string response = result.ToString() + "\n";
                                    byte[] responseData = Encoding.UTF8.GetBytes(response); // convierte en bytes y lo manda al cliente
                                    await stream.WriteAsync(responseData, 0, responseData.Length);
                                }
                                catch (Exception ex) // manejo de errores
                                {
                                    Console.WriteLine($"Error al procesar: {ex.Message}");
                                    Console.WriteLine($"Stack trace: {ex.StackTrace}");
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
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
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