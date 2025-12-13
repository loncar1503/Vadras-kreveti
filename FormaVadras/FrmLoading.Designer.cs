namespace FormaVadras
{
    partial class FrmLoading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPiramida = new Button();
            brnBrdo = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnPiramida
            // 
            btnPiramida.Anchor = AnchorStyles.None;
            btnPiramida.Location = new Point(107, 204);
            btnPiramida.Name = "btnPiramida";
            btnPiramida.Size = new Size(187, 125);
            btnPiramida.TabIndex = 0;
            btnPiramida.Text = "Piramida";
            btnPiramida.UseVisualStyleBackColor = true;
            btnPiramida.Click += btnPiramida_Click;
            // 
            // brnBrdo
            // 
            brnBrdo.Anchor = AnchorStyles.None;
            brnBrdo.Location = new Point(462, 204);
            brnBrdo.Name = "brnBrdo";
            brnBrdo.Size = new Size(192, 123);
            brnBrdo.TabIndex = 1;
            brnBrdo.Text = "Banovo brdo";
            brnBrdo.UseVisualStyleBackColor = true;
            brnBrdo.Click += brnBrdo_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(300, 147);
            label1.Name = "label1";
            label1.Size = new Size(163, 41);
            label1.TabIndex = 2;
            label1.Text = "Koji lokal?";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.vadras21;
            pictureBox1.Location = new Point(273, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(209, 106);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // FrmLoading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(73, 107, 108);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(brnBrdo);
            Controls.Add(btnPiramida);
            Name = "FrmLoading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Izaberite lokal u kome se nalazite";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPiramida;
        private Button brnBrdo;
        private Label label1;
        private PictureBox pictureBox1;
    }
}