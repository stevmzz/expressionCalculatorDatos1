namespace Client.Forms
{
    partial class MainForm
    {
        private System.Windows.Forms.Label helloLabel;

        private void InitializeComponent()
        {
            this.helloLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.helloLabel.Location = new System.Drawing.Point(150, 130);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(100, 21);
            this.helloLabel.TabIndex = 0;
            this.helloLabel.Text = "¡Hola!";
            this.helloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.helloLabel);
            this.Name = "MainForm";
            this.Text = "Ventana de Bienvenida";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
