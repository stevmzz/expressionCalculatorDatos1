    using ExpressionCalculator.Server.Services;
    using System;
    using System.Threading.Tasks;

    namespace ExpressionCalculator.Server
    {
        class Program
        {
            static async Task Main(string[] args) // inicia el server
            {
                Console.WriteLine("Iniciando servidor...");

                var server = new ServerSocket();
                await server.startAsync();

                Console.WriteLine("Presione cualquier tecla para detener el servidor...");
                Console.ReadKey();

                server.Stop();
            }
        }
    }