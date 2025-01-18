using System;
using System.Windows.Forms;
using Client.Forms;

namespace ExpressionCalculator.Client
{
    static class Program
    {
        [STAThread]
        static void Main() // clase principal de la app
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware); // ajusta la calidad
            Application.EnableVisualStyles(); // para que adopte estilos de OS
            Application.Run(new MainForm()); // ejecuta el forms principal
        }
    }
}