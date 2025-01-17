using System;
using System.Threading.Tasks;
using ExpressionCalculator.Client.Services;

namespace ExpressionCalculator.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Cliente de prueba para calculadora de expresiones");

            var client = new ClientSocket();

            try
            {
                Console.WriteLine("Conectando al servidor...");
                await client.ConnectAsync();
                Console.WriteLine("¡Conectado!");

                while (true)
                {
                    Console.Write("\nIngrese una expresión (o 'exit' para salir): ");
                    string input = Console.ReadLine();

                    if (input?.ToLower() == "exit")
                        break;

                    Console.WriteLine("Enviando expresión al servidor...");
                    await client.SendExpressionAsync(input);

                    string response = await client.ReceiveResponseAsync();
                    Console.WriteLine($"Respuesta del servidor: {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.Disconnect();
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}