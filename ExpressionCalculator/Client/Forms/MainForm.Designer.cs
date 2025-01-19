namespace Client.Forms
{
    partial class MainForm
    {
        private System.Windows.Forms.TextBox expressionTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label resultLabel;
        private Label titleLabel;
        private Panel historyPanel;
        private DataGridView historyGridView;
        private Label historyLabel;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            expressionTextBox = new TextBox();
            sendButton = new Button();
            resultLabel = new Label();
            titleLabel = new Label();
            historyPanel = new Panel();
            historyLabel = new Label();
            historyGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            historyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historyGridView).BeginInit();
            SuspendLayout();
            // 
            // expressionTextBox
            // 
            expressionTextBox.BackColor = Color.FromArgb(60, 60, 60);
            expressionTextBox.BorderStyle = BorderStyle.FixedSingle;
            expressionTextBox.Font = new Font("Segoe UI", 11F);
            expressionTextBox.ForeColor = Color.FromArgb(230, 230, 230);
            expressionTextBox.Location = new Point(57, 93);
            expressionTextBox.Name = "expressionTextBox";
            expressionTextBox.Size = new Size(239, 32);
            expressionTextBox.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.FromArgb(75, 75, 75);
            sendButton.Cursor = Cursors.Hand;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI", 10F);
            sendButton.ForeColor = Color.FromArgb(240, 240, 240);
            sendButton.Location = new Point(302, 93);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(114, 33);
            sendButton.TabIndex = 2;
            sendButton.Text = "Enviar";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font("Segoe UI Light", 11F);
            resultLabel.ForeColor = Color.FromArgb(200, 200, 200);
            resultLabel.Location = new Point(57, 150);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(100, 25);
            resultLabel.TabIndex = 3;
            resultLabel.Text = "Resultado: ";
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI Light", 18F);
            titleLabel.ForeColor = Color.FromArgb(240, 240, 240);
            titleLabel.Location = new Point(0, 25);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(455, 40);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Expression Calculator";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // historyPanel
            // 
            historyPanel.BackColor = Color.FromArgb(50, 50, 50);
            historyPanel.Controls.Add(historyLabel);
            historyPanel.Controls.Add(historyGridView);
            historyPanel.Location = new Point(27, 200);
            historyPanel.Name = "historyPanel";
            historyPanel.Padding = new Padding(10);
            historyPanel.Size = new Size(419, 267);
            historyPanel.TabIndex = 0;
            // 
            // historyLabel
            // 
            historyLabel.AutoSize = true;
            historyLabel.Font = new Font("Segoe UI Light", 12F);
            historyLabel.ForeColor = Color.FromArgb(230, 230, 230);
            historyLabel.Location = new Point(10, 10);
            historyLabel.Name = "historyLabel";
            historyLabel.Size = new Size(217, 28);
            historyLabel.TabIndex = 0;
            historyLabel.Text = "Historial de Operaciones";
            // 
            // historyGridView
            // 
            historyGridView.BackgroundColor = Color.FromArgb(50, 50, 50);
            historyGridView.BorderStyle = BorderStyle.None;
            historyGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            historyGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            historyGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            historyGridView.ColumnHeadersHeight = 30;
            historyGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 75, 75);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            historyGridView.DefaultCellStyle = dataGridViewCellStyle2;
            historyGridView.EnableHeadersVisualStyles = false;
            historyGridView.GridColor = Color.FromArgb(70, 70, 70);
            historyGridView.Location = new Point(23, 56);
            historyGridView.Name = "historyGridView";
            historyGridView.ReadOnly = true;
            historyGridView.RowHeadersVisible = false;
            historyGridView.RowHeadersWidth = 51;
            historyGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            historyGridView.Size = new Size(376, 183);
            historyGridView.TabIndex = 1;
            historyGridView.CellContentClick += historyGridView_CellContentClick;
            historyGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Fecha";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Expresión";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Resultado";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(471, 486);
            Controls.Add(historyPanel);
            Controls.Add(titleLabel);
            Controls.Add(expressionTextBox);
            Controls.Add(sendButton);
            Controls.Add(resultLabel);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Expression Calculator";
            historyPanel.ResumeLayout(false);
            historyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)historyGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}