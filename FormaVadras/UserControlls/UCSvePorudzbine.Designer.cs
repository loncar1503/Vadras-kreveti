namespace FormaVadras.UserControlls
{
    partial class UCSvePorudzbine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSvePorudzbine = new DataGridView();
            btnRacun = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSvePorudzbine).BeginInit();
            SuspendLayout();
            // 
            // dgvSvePorudzbine
            // 
            dgvSvePorudzbine.BackgroundColor = SystemColors.ButtonFace;
            dgvSvePorudzbine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSvePorudzbine.Location = new Point(60, 89);
            dgvSvePorudzbine.Name = "dgvSvePorudzbine";
            dgvSvePorudzbine.RowHeadersWidth = 51;
            dgvSvePorudzbine.Size = new Size(833, 405);
            dgvSvePorudzbine.TabIndex = 0;
            // 
            // btnRacun
            // 
            btnRacun.Location = new Point(914, 110);
            btnRacun.Name = "btnRacun";
            btnRacun.Size = new Size(140, 51);
            btnRacun.TabIndex = 1;
            btnRacun.Text = "Napravi racun";
            btnRacun.UseVisualStyleBackColor = true;
            btnRacun.Click += btnRacun_Click;
            // 
            // UCSvePorudzbine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            Controls.Add(btnRacun);
            Controls.Add(dgvSvePorudzbine);
            Name = "UCSvePorudzbine";
            Size = new Size(1087, 601);
            ((System.ComponentModel.ISupportInitialize)dgvSvePorudzbine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSvePorudzbine;
        private Button btnRacun;
    }
}
