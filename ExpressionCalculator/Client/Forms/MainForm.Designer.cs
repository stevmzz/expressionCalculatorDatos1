namespace Client.Forms
{
    partial class MainForm
    {
        private System.Windows.Forms.TextBox expressionTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label resultLabel;

        private void InitializeComponent()
        {
            expressionTextBox = new TextBox();
            sendButton = new Button();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // expressionTextBox
            // 
            expressionTextBox.Location = new Point(57, 93);
            expressionTextBox.Margin = new Padding(3, 4, 3, 4);
            expressionTextBox.Name = "expressionTextBox";
            expressionTextBox.Size = new Size(342, 27);
            expressionTextBox.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(156, 128);
            sendButton.Margin = new Padding(3, 4, 3, 4);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(114, 40);
            sendButton.TabIndex = 2;
            sendButton.Text = "Enviar";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font("Segoe UI", 10F);
            resultLabel.Location = new Point(12, 368);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(94, 23);
            resultLabel.TabIndex = 3;
            resultLabel.Text = "Resultado: ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 400);
            Controls.Add(expressionTextBox);
            Controls.Add(sendButton);
            Controls.Add(resultLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Calculadora de Expresiones";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}