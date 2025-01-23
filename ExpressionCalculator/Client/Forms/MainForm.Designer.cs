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
            deleteAll = new Button();
            delete = new Button();
            paren1 = new Button();
            paren2 = new Button();
            button9t = new Button();
            button8t = new Button();
            button7t = new Button();
            buttonXOR = new Button();
            button3t = new Button();
            button2t = new Button();
            button1t = new Button();
            buttonDisyun = new Button();
            button6t = new Button();
            button5t = new Button();
            button4t = new Button();
            buttonNot = new Button();
            buttonMulti = new Button();
            buttonResta = new Button();
            buttonSuma = new Button();
            buttonDiv = new Button();
            buttonPorcent = new Button();
            buttonCuadrado = new Button();
            button0t = new Button();
            buttonConjun = new Button();
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
            sendButton.Click += sendButton_Click_1;
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
            historyPanel.Location = new Point(469, 25);
            historyPanel.Name = "historyPanel";
            historyPanel.Padding = new Padding(10);
            historyPanel.Size = new Size(421, 449);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            historyGridView.Size = new Size(376, 380);
            historyGridView.TabIndex = 1;
            historyGridView.CellContentClick += historyGridView_CellContentClick;
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
            // deleteAll
            // 
            deleteAll.BackColor = Color.FromArgb(75, 75, 75);
            deleteAll.Cursor = Cursors.Hand;
            deleteAll.FlatAppearance.BorderSize = 0;
            deleteAll.FlatStyle = FlatStyle.Flat;
            deleteAll.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            deleteAll.ForeColor = SystemColors.ButtonHighlight;
            deleteAll.Location = new Point(41, 196);
            deleteAll.Name = "deleteAll";
            deleteAll.RightToLeft = RightToLeft.Yes;
            deleteAll.Size = new Size(94, 43);
            deleteAll.TabIndex = 4;
            deleteAll.Text = "C";
            deleteAll.UseVisualStyleBackColor = false;
            deleteAll.Click += deleteAll_Click;
            // 
            // delete
            // 
            delete.BackColor = Color.FromArgb(75, 75, 75);
            delete.Cursor = Cursors.Hand;
            delete.FlatAppearance.BorderSize = 0;
            delete.FlatStyle = FlatStyle.Flat;
            delete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            delete.ForeColor = SystemColors.ButtonHighlight;
            delete.Location = new Point(139, 196);
            delete.Name = "delete";
            delete.RightToLeft = RightToLeft.Yes;
            delete.Size = new Size(94, 43);
            delete.TabIndex = 5;
            delete.Text = "⌫";
            delete.UseVisualStyleBackColor = false;
            delete.Click += delete_Click;
            // 
            // paren1
            // 
            paren1.BackColor = Color.FromArgb(75, 75, 75);
            paren1.Cursor = Cursors.Hand;
            paren1.FlatAppearance.BorderSize = 0;
            paren1.FlatStyle = FlatStyle.Flat;
            paren1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paren1.ForeColor = SystemColors.ButtonHighlight;
            paren1.Location = new Point(237, 196);
            paren1.Name = "paren1";
            paren1.RightToLeft = RightToLeft.Yes;
            paren1.Size = new Size(94, 43);
            paren1.TabIndex = 6;
            paren1.Text = ")";
            paren1.UseVisualStyleBackColor = false;
            paren1.Click += paren1_Click;
            // 
            // paren2
            // 
            paren2.BackColor = Color.FromArgb(75, 75, 75);
            paren2.Cursor = Cursors.Hand;
            paren2.FlatAppearance.BorderSize = 0;
            paren2.FlatStyle = FlatStyle.Flat;
            paren2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paren2.ForeColor = SystemColors.ButtonHighlight;
            paren2.Location = new Point(335, 196);
            paren2.Name = "paren2";
            paren2.RightToLeft = RightToLeft.Yes;
            paren2.Size = new Size(94, 43);
            paren2.TabIndex = 7;
            paren2.Text = "(";
            paren2.UseVisualStyleBackColor = false;
            paren2.Click += paren2_Click;
            // 
            // button9t
            // 
            button9t.BackColor = Color.FromArgb(64, 64, 64);
            button9t.Cursor = Cursors.Hand;
            button9t.FlatAppearance.BorderSize = 0;
            button9t.FlatStyle = FlatStyle.Flat;
            button9t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9t.ForeColor = SystemColors.ButtonHighlight;
            button9t.Location = new Point(335, 243);
            button9t.Name = "button9t";
            button9t.RightToLeft = RightToLeft.Yes;
            button9t.Size = new Size(94, 43);
            button9t.TabIndex = 11;
            button9t.Text = "9";
            button9t.UseVisualStyleBackColor = false;
            button9t.Click += button9t_Click;
            // 
            // button8t
            // 
            button8t.BackColor = Color.FromArgb(64, 64, 64);
            button8t.Cursor = Cursors.Hand;
            button8t.FlatAppearance.BorderSize = 0;
            button8t.FlatStyle = FlatStyle.Flat;
            button8t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8t.ForeColor = SystemColors.ButtonHighlight;
            button8t.Location = new Point(237, 243);
            button8t.Name = "button8t";
            button8t.RightToLeft = RightToLeft.Yes;
            button8t.Size = new Size(94, 43);
            button8t.TabIndex = 10;
            button8t.Text = "8";
            button8t.UseVisualStyleBackColor = false;
            button8t.Click += button8t_Click;
            // 
            // button7t
            // 
            button7t.BackColor = Color.FromArgb(64, 64, 64);
            button7t.Cursor = Cursors.Hand;
            button7t.FlatAppearance.BorderSize = 0;
            button7t.FlatStyle = FlatStyle.Flat;
            button7t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7t.ForeColor = SystemColors.ButtonHighlight;
            button7t.Location = new Point(139, 243);
            button7t.Name = "button7t";
            button7t.RightToLeft = RightToLeft.Yes;
            button7t.Size = new Size(94, 43);
            button7t.TabIndex = 9;
            button7t.Text = "7";
            button7t.UseVisualStyleBackColor = false;
            button7t.Click += button7t_Click;
            // 
            // buttonXOR
            // 
            buttonXOR.BackColor = Color.FromArgb(75, 75, 75);
            buttonXOR.Cursor = Cursors.Hand;
            buttonXOR.FlatAppearance.BorderSize = 0;
            buttonXOR.FlatStyle = FlatStyle.Flat;
            buttonXOR.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            buttonXOR.ForeColor = SystemColors.ButtonHighlight;
            buttonXOR.Location = new Point(41, 243);
            buttonXOR.Name = "buttonXOR";
            buttonXOR.RightToLeft = RightToLeft.Yes;
            buttonXOR.Size = new Size(94, 43);
            buttonXOR.TabIndex = 8;
            buttonXOR.Text = "⊕";
            buttonXOR.UseVisualStyleBackColor = false;
            buttonXOR.Click += buttonXOR_Click;
            // 
            // button3t
            // 
            button3t.BackColor = Color.FromArgb(64, 64, 64);
            button3t.Cursor = Cursors.Hand;
            button3t.FlatAppearance.BorderSize = 0;
            button3t.FlatStyle = FlatStyle.Flat;
            button3t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3t.ForeColor = SystemColors.ButtonHighlight;
            button3t.Location = new Point(335, 337);
            button3t.Name = "button3t";
            button3t.RightToLeft = RightToLeft.Yes;
            button3t.Size = new Size(94, 43);
            button3t.TabIndex = 19;
            button3t.Text = "3";
            button3t.UseVisualStyleBackColor = false;
            button3t.Click += button3t_Click;
            // 
            // button2t
            // 
            button2t.BackColor = Color.FromArgb(64, 64, 64);
            button2t.Cursor = Cursors.Hand;
            button2t.FlatAppearance.BorderSize = 0;
            button2t.FlatStyle = FlatStyle.Flat;
            button2t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2t.ForeColor = SystemColors.ButtonHighlight;
            button2t.Location = new Point(237, 337);
            button2t.Name = "button2t";
            button2t.RightToLeft = RightToLeft.Yes;
            button2t.Size = new Size(94, 43);
            button2t.TabIndex = 18;
            button2t.Text = "2";
            button2t.UseVisualStyleBackColor = false;
            button2t.Click += button2t_Click;
            // 
            // button1t
            // 
            button1t.BackColor = Color.FromArgb(64, 64, 64);
            button1t.Cursor = Cursors.Hand;
            button1t.FlatAppearance.BorderSize = 0;
            button1t.FlatStyle = FlatStyle.Flat;
            button1t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1t.ForeColor = SystemColors.ButtonHighlight;
            button1t.Location = new Point(139, 337);
            button1t.Name = "button1t";
            button1t.RightToLeft = RightToLeft.Yes;
            button1t.Size = new Size(94, 43);
            button1t.TabIndex = 17;
            button1t.Text = "1";
            button1t.UseVisualStyleBackColor = false;
            button1t.Click += button1t_Click;
            // 
            // buttonDisyun
            // 
            buttonDisyun.BackColor = Color.FromArgb(75, 75, 75);
            buttonDisyun.Cursor = Cursors.Hand;
            buttonDisyun.FlatAppearance.BorderSize = 0;
            buttonDisyun.FlatStyle = FlatStyle.Flat;
            buttonDisyun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDisyun.ForeColor = SystemColors.ButtonHighlight;
            buttonDisyun.Location = new Point(41, 337);
            buttonDisyun.Name = "buttonDisyun";
            buttonDisyun.RightToLeft = RightToLeft.Yes;
            buttonDisyun.Size = new Size(94, 43);
            buttonDisyun.TabIndex = 16;
            buttonDisyun.Text = "∨";
            buttonDisyun.UseVisualStyleBackColor = false;
            buttonDisyun.Click += buttonDisyun_Click;
            // 
            // button6t
            // 
            button6t.BackColor = Color.FromArgb(64, 64, 64);
            button6t.Cursor = Cursors.Hand;
            button6t.FlatAppearance.BorderSize = 0;
            button6t.FlatStyle = FlatStyle.Flat;
            button6t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6t.ForeColor = SystemColors.ButtonHighlight;
            button6t.Location = new Point(335, 290);
            button6t.Name = "button6t";
            button6t.RightToLeft = RightToLeft.Yes;
            button6t.Size = new Size(94, 43);
            button6t.TabIndex = 15;
            button6t.Text = "6";
            button6t.UseVisualStyleBackColor = false;
            button6t.Click += button6t_Click;
            // 
            // button5t
            // 
            button5t.BackColor = Color.FromArgb(64, 64, 64);
            button5t.Cursor = Cursors.Hand;
            button5t.FlatAppearance.BorderSize = 0;
            button5t.FlatStyle = FlatStyle.Flat;
            button5t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5t.ForeColor = SystemColors.ButtonHighlight;
            button5t.Location = new Point(237, 290);
            button5t.Name = "button5t";
            button5t.RightToLeft = RightToLeft.Yes;
            button5t.Size = new Size(94, 43);
            button5t.TabIndex = 14;
            button5t.Text = "5";
            button5t.UseVisualStyleBackColor = false;
            button5t.Click += button5t_Click;
            // 
            // button4t
            // 
            button4t.BackColor = Color.FromArgb(64, 64, 64);
            button4t.Cursor = Cursors.Hand;
            button4t.FlatAppearance.BorderSize = 0;
            button4t.FlatStyle = FlatStyle.Flat;
            button4t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4t.ForeColor = SystemColors.ButtonHighlight;
            button4t.Location = new Point(139, 290);
            button4t.Name = "button4t";
            button4t.RightToLeft = RightToLeft.Yes;
            button4t.Size = new Size(94, 43);
            button4t.TabIndex = 13;
            button4t.Text = "4";
            button4t.UseVisualStyleBackColor = false;
            button4t.Click += button4t_Click;
            // 
            // buttonNot
            // 
            buttonNot.BackColor = Color.FromArgb(75, 75, 75);
            buttonNot.Cursor = Cursors.Hand;
            buttonNot.FlatAppearance.BorderSize = 0;
            buttonNot.FlatStyle = FlatStyle.Flat;
            buttonNot.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            buttonNot.ForeColor = SystemColors.ButtonHighlight;
            buttonNot.Location = new Point(41, 290);
            buttonNot.Name = "buttonNot";
            buttonNot.RightToLeft = RightToLeft.Yes;
            buttonNot.Size = new Size(94, 43);
            buttonNot.TabIndex = 12;
            buttonNot.Text = "¬";
            buttonNot.UseVisualStyleBackColor = false;
            buttonNot.Click += buttonNot_Click;
            // 
            // buttonMulti
            // 
            buttonMulti.BackColor = Color.FromArgb(75, 75, 75);
            buttonMulti.Cursor = Cursors.Hand;
            buttonMulti.FlatAppearance.BorderSize = 0;
            buttonMulti.FlatStyle = FlatStyle.Flat;
            buttonMulti.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonMulti.ForeColor = SystemColors.ButtonHighlight;
            buttonMulti.Location = new Point(335, 431);
            buttonMulti.Name = "buttonMulti";
            buttonMulti.RightToLeft = RightToLeft.Yes;
            buttonMulti.Size = new Size(94, 43);
            buttonMulti.TabIndex = 27;
            buttonMulti.Text = "x";
            buttonMulti.UseVisualStyleBackColor = false;
            buttonMulti.Click += buttonMulti_Click;
            // 
            // buttonResta
            // 
            buttonResta.BackColor = Color.FromArgb(75, 75, 75);
            buttonResta.Cursor = Cursors.Hand;
            buttonResta.FlatAppearance.BorderSize = 0;
            buttonResta.FlatStyle = FlatStyle.Flat;
            buttonResta.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            buttonResta.ForeColor = SystemColors.ButtonHighlight;
            buttonResta.Location = new Point(237, 431);
            buttonResta.Name = "buttonResta";
            buttonResta.RightToLeft = RightToLeft.Yes;
            buttonResta.Size = new Size(94, 43);
            buttonResta.TabIndex = 26;
            buttonResta.Text = "-";
            buttonResta.UseVisualStyleBackColor = false;
            buttonResta.Click += buttonResta_Click;
            // 
            // buttonSuma
            // 
            buttonSuma.BackColor = Color.FromArgb(75, 75, 75);
            buttonSuma.Cursor = Cursors.Hand;
            buttonSuma.FlatAppearance.BorderSize = 0;
            buttonSuma.FlatStyle = FlatStyle.Flat;
            buttonSuma.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonSuma.ForeColor = SystemColors.ButtonHighlight;
            buttonSuma.Location = new Point(139, 431);
            buttonSuma.Name = "buttonSuma";
            buttonSuma.RightToLeft = RightToLeft.Yes;
            buttonSuma.Size = new Size(94, 43);
            buttonSuma.TabIndex = 25;
            buttonSuma.Text = "+";
            buttonSuma.UseVisualStyleBackColor = false;
            buttonSuma.Click += buttonSuma_Click;
            // 
            // buttonDiv
            // 
            buttonDiv.BackColor = Color.FromArgb(75, 75, 75);
            buttonDiv.Cursor = Cursors.Hand;
            buttonDiv.FlatAppearance.BorderSize = 0;
            buttonDiv.FlatStyle = FlatStyle.Flat;
            buttonDiv.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            buttonDiv.ForeColor = SystemColors.ButtonHighlight;
            buttonDiv.Location = new Point(41, 431);
            buttonDiv.Name = "buttonDiv";
            buttonDiv.RightToLeft = RightToLeft.Yes;
            buttonDiv.Size = new Size(94, 43);
            buttonDiv.TabIndex = 24;
            buttonDiv.Text = "÷";
            buttonDiv.UseVisualStyleBackColor = false;
            buttonDiv.Click += buttonDiv_Click;
            // 
            // buttonPorcent
            // 
            buttonPorcent.BackColor = Color.FromArgb(75, 75, 75);
            buttonPorcent.Cursor = Cursors.Hand;
            buttonPorcent.FlatAppearance.BorderSize = 0;
            buttonPorcent.FlatStyle = FlatStyle.Flat;
            buttonPorcent.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPorcent.ForeColor = SystemColors.ButtonHighlight;
            buttonPorcent.Location = new Point(335, 384);
            buttonPorcent.Name = "buttonPorcent";
            buttonPorcent.RightToLeft = RightToLeft.Yes;
            buttonPorcent.Size = new Size(94, 43);
            buttonPorcent.TabIndex = 23;
            buttonPorcent.Text = "%";
            buttonPorcent.UseVisualStyleBackColor = false;
            buttonPorcent.Click += buttonPorcent_Click;
            // 
            // buttonCuadrado
            // 
            buttonCuadrado.BackColor = Color.FromArgb(75, 75, 75);
            buttonCuadrado.Cursor = Cursors.Hand;
            buttonCuadrado.FlatAppearance.BorderSize = 0;
            buttonCuadrado.FlatStyle = FlatStyle.Flat;
            buttonCuadrado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCuadrado.ForeColor = SystemColors.ButtonHighlight;
            buttonCuadrado.Location = new Point(237, 384);
            buttonCuadrado.Name = "buttonCuadrado";
            buttonCuadrado.RightToLeft = RightToLeft.Yes;
            buttonCuadrado.Size = new Size(94, 43);
            buttonCuadrado.TabIndex = 22;
            buttonCuadrado.Text = "x²";
            buttonCuadrado.UseVisualStyleBackColor = false;
            buttonCuadrado.Click += buttonCuadrado_Click;
            // 
            // button0t
            // 
            button0t.BackColor = Color.FromArgb(64, 64, 64);
            button0t.Cursor = Cursors.Hand;
            button0t.FlatAppearance.BorderSize = 0;
            button0t.FlatStyle = FlatStyle.Flat;
            button0t.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button0t.ForeColor = SystemColors.ButtonHighlight;
            button0t.Location = new Point(139, 384);
            button0t.Name = "button0t";
            button0t.RightToLeft = RightToLeft.Yes;
            button0t.Size = new Size(94, 43);
            button0t.TabIndex = 21;
            button0t.Text = "0";
            button0t.UseVisualStyleBackColor = false;
            button0t.Click += button0t_Click;
            // 
            // buttonConjun
            // 
            buttonConjun.BackColor = Color.FromArgb(75, 75, 75);
            buttonConjun.Cursor = Cursors.Hand;
            buttonConjun.FlatAppearance.BorderSize = 0;
            buttonConjun.FlatStyle = FlatStyle.Flat;
            buttonConjun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonConjun.ForeColor = SystemColors.ButtonHighlight;
            buttonConjun.Location = new Point(41, 384);
            buttonConjun.Name = "buttonConjun";
            buttonConjun.RightToLeft = RightToLeft.Yes;
            buttonConjun.Size = new Size(94, 43);
            buttonConjun.TabIndex = 20;
            buttonConjun.Text = "∧";
            buttonConjun.UseVisualStyleBackColor = false;
            buttonConjun.Click += buttonConjun_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(916, 498);
            Controls.Add(buttonMulti);
            Controls.Add(buttonResta);
            Controls.Add(buttonSuma);
            Controls.Add(buttonDiv);
            Controls.Add(buttonPorcent);
            Controls.Add(buttonCuadrado);
            Controls.Add(button0t);
            Controls.Add(buttonConjun);
            Controls.Add(button3t);
            Controls.Add(button2t);
            Controls.Add(button1t);
            Controls.Add(buttonDisyun);
            Controls.Add(button6t);
            Controls.Add(button5t);
            Controls.Add(button4t);
            Controls.Add(buttonNot);
            Controls.Add(button9t);
            Controls.Add(button8t);
            Controls.Add(button7t);
            Controls.Add(buttonXOR);
            Controls.Add(paren2);
            Controls.Add(paren1);
            Controls.Add(delete);
            Controls.Add(deleteAll);
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
        private Button deleteAll;
        private Button delete;
        private Button paren1;
        private Button paren2;
        private Button button9t;
        private Button button8t;
        private Button button7t;
        private Button buttonXOR;
        private Button button3t;
        private Button button2t;
        private Button button1t;
        private Button buttonDisyun;
        private Button button6t;
        private Button button5t;
        private Button button4t;
        private Button buttonNot;
        private Button buttonMulti;
        private Button buttonResta;
        private Button buttonSuma;
        private Button buttonDiv;
        private Button buttonPorcent;
        private Button buttonCuadrado;
        private Button button0t;
        private Button buttonConjun;
    }
}