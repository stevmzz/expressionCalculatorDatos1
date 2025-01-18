using System;
using System.Windows.Forms;
using ExpressionCalculator.Client.Services;

namespace Client.Forms
{
    public partial class MainForm : Form // clase parcial que deriva del form principal
    {
        private readonly ClientSocket _clientSocket; // coneccion con server del cliente

        public MainForm()
        {
            InitializeComponent();
            _clientSocket = new ClientSocket();
            sendButton.Click += SendButton_Click;
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
        }

        private async void MainForm_Load(object sender, EventArgs e) // se ejecuta cuando carga el formulario, osea intenta conectarse al server
        {
            try
            {
                await _clientSocket.ConnectAsync();
                resultLabel.Text = "Conectado al servidor";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void SendButton_Click(object sender, EventArgs e) // se ejecuta al dar clicl al boton
        {
            try
            {
                await _clientSocket.SendExpressionAsync(expressionTextBox.Text); // envia la expresion al server
                string response = await _clientSocket.ReceiveResponseAsync(); // espera la respuesta del server
                resultLabel.Text = $"Resultado: {response}"; // muestra el mensaje en el servidor
            }
            catch (Exception ex) // maneja errores
            {
                MessageBox.Show($"Error al enviar expresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) // metodo para desconectar cliente al cerrar formulario
        {
            _clientSocket.Disconnect();
        }
    }
}