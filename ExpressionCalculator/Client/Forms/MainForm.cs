using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using ExpressionCalculator.Client.Services;

namespace Client.Forms
{
    public partial class MainForm : Form // clase parcial que deriva del form principal
    {
        private readonly ClientSocket _clientSocket; // coneccion con server del cliente
        private readonly ExpressionValidator _validator;

        public MainForm()
        {
            InitializeComponent();
            _clientSocket = new ClientSocket();
            _validator = new ExpressionValidator();
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
                string expression = expressionTextBox.Text.Trim();
                var (isValid, errorMessage) = _validator.ValidateExpression(expression); // validamos la expresion antes de enviarla

                if (!isValid)
                {
                    MessageBox.Show(errorMessage, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cleanExpression = _validator.CleanExpression(expression); // limpiamos la expresion
                await _clientSocket.SendExpressionAsync(expressionTextBox.Text); // envia la expresion al server
                string response = await _clientSocket.ReceiveResponseAsync(); // espera la respuesta del server
                resultLabel.Text = $"Resultado: {response}"; // muestra el mensaje en el servidor
                expressionTextBox.Clear(); // limpiamos el textbox despues del envio exitoso
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

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void historyGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}