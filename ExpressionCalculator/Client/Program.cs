using System;
using System.Threading.Tasks;
using ExpressionCalculator.Client.Services;

namespace ExpressionCalculator.Client
{
    class Program
    {
        static async Task Main(string[] args) // metodo para ejecutar cliente
        {
            var client = new ClientSocket(); // instancia de cliente

            try
            {
                await client.ConnectAsync(); // intenta conectarse con el server

                while (true)
                {
                    string input = Console.ReadLine(); // lee la entrada del usuario
                    string response = await client.ReceiveResponseAsync(); // espera la respuesta del server
                    Console.WriteLine($"Respuesta del servidor: {response}");
                }
            }
            catch (Exception ex) // manejo de exepciones
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally // se asegura que el cliente se desconecte
            {
                client.Disconnect();
            }
        }
    }
}