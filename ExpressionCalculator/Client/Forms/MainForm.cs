using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using ExpressionCalculator.Client.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            this.KeyPreview = true;
            this.KeyPress += AnyKeyPress;
        }

        private void AnyKeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                sendButton.PerformClick();
                return;
            }

            // lista de caracteres permitidos
            string allowedChars = "0123456789+-*/()^~&|%,.";

            if (allowedChars.Contains(e.KeyChar) || e.KeyChar == '\b') // \b es para permitir la tecla backspace
            {
                e.Handled = true;
                if (e.KeyChar == '\b')
                {
                    if (expressionTextBox.Text.Length > 0)
                    {
                        expressionTextBox.Text = expressionTextBox.Text.Substring(0, expressionTextBox.Text.Length - 1);
                        expressionTextBox.SelectionStart = expressionTextBox.Text.Length;
                    }
                }
                else
                {
                    expressionTextBox.Text += e.KeyChar;
                    expressionTextBox.SelectionStart = expressionTextBox.Text.Length;
                }
            }
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

        private void deleteAll_Click(object sender, EventArgs e)
        {
            expressionTextBox.Clear();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BACKSPACE}");
            expressionTextBox.Focus();
        }

        private void paren1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{(}");
            expressionTextBox.Focus();
        }

        private void paren2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{)}");
            expressionTextBox.Focus();
        }

        private void buttonXOR_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            int cursorPosition = expressionTextBox.SelectionStart;
            expressionTextBox.Text = expressionTextBox.Text.Insert(cursorPosition, "^");
            expressionTextBox.SelectionStart = cursorPosition + 1;
        }

        private void button7t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("7");
        }

        private void button8t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("8");
        }

        private void button9t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("9");
        }

        private void buttonNot_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("{~}");
        }

        private void button4t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("4");
        }

        private void button5t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("5");
        }

        private void button6t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("6");
        }

        private void buttonDisyun_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("|");
        }

        private void button1t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("1");
        }

        private void button2t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("2");
        }

        private void button3t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("3");
        }

        private void buttonConjun_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("&");
        }

        private void button0t_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("0");
        }

        private void buttonCuadrado_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("**");
        }

        private void buttonPorcent_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("{%}");
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("/");
        }

        private void buttonSuma_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("{+}");
        }

        private void buttonResta_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("-");
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            expressionTextBox.Focus();
            SendKeys.Send("*");
        }

        private void sendButton_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}