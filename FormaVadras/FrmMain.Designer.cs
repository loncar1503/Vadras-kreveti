namespace FormaVadras
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            početniEkranToolStripMenuItem = new ToolStripMenuItem();
            porudzbineToolStripMenuItem = new ToolStripMenuItem();
            kreirajPorudzbinuToolStripMenuItem = new ToolStripMenuItem();
            pregledPorudzbinaToolStripMenuItem = new ToolStripMenuItem();
            izlogujSeToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.CadetBlue;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { početniEkranToolStripMenuItem, porudzbineToolStripMenuItem, izlogujSeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1087, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // početniEkranToolStripMenuItem
            // 
            početniEkranToolStripMenuItem.BackColor = Color.PowderBlue;
            početniEkranToolStripMenuItem.Name = "početniEkranToolStripMenuItem";
            početniEkranToolStripMenuItem.Size = new Size(111, 24);
            početniEkranToolStripMenuItem.Text = "Početni ekran";
            početniEkranToolStripMenuItem.Click += početniEkranToolStripMenuItem_Click;
            // 
            // porudzbineToolStripMenuItem
            // 
            porudzbineToolStripMenuItem.BackColor = Color.PowderBlue;
            porudzbineToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajPorudzbinuToolStripMenuItem, pregledPorudzbinaToolStripMenuItem });
            porudzbineToolStripMenuItem.Name = "porudzbineToolStripMenuItem";
            porudzbineToolStripMenuItem.Size = new Size(97, 24);
            porudzbineToolStripMenuItem.Text = "Porudzbine";
            // 
            // kreirajPorudzbinuToolStripMenuItem
            // 
            kreirajPorudzbinuToolStripMenuItem.Name = "kreirajPorudzbinuToolStripMenuItem";
            kreirajPorudzbinuToolStripMenuItem.Size = new Size(223, 26);
            kreirajPorudzbinuToolStripMenuItem.Text = "Kreiraj porudzbinu";
            kreirajPorudzbinuToolStripMenuItem.Click += kreirajPorudzbinuToolStripMenuItem_Click;
            // 
            // pregledPorudzbinaToolStripMenuItem
            // 
            pregledPorudzbinaToolStripMenuItem.Name = "pregledPorudzbinaToolStripMenuItem";
            pregledPorudzbinaToolStripMenuItem.Size = new Size(223, 26);
            pregledPorudzbinaToolStripMenuItem.Text = "Pregled porudzbina";
            pregledPorudzbinaToolStripMenuItem.Click += pregledPorudzbinaToolStripMenuItem_Click;
            // 
            // izlogujSeToolStripMenuItem
            // 
            izlogujSeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            izlogujSeToolStripMenuItem.BackColor = Color.Gold;
            izlogujSeToolStripMenuItem.Name = "izlogujSeToolStripMenuItem";
            izlogujSeToolStripMenuItem.Size = new Size(86, 24);
            izlogujSeToolStripMenuItem.Text = "Izloguj se";
            izlogujSeToolStripMenuItem.Click += izlogujSeToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.vadras_logo_1;
            pictureBox1.Location = new Point(437, 225);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 152);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(73, 107, 108);
            panel1.Location = new Point(0, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(1087, 601);
            panel1.TabIndex = 6;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(73, 107, 108);
            ClientSize = new Size(1087, 631);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMain";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem porudzbineToolStripMenuItem;
        private ToolStripMenuItem kreirajPorudzbinuToolStripMenuItem;
        private ToolStripMenuItem pregledPorudzbinaToolStripMenuItem;
        private PictureBox pictureBox1;
        private Panel panel1;
        private ToolStripMenuItem početniEkranToolStripMenuItem;
        private ToolStripMenuItem izlogujSeToolStripMenuItem;
    }
}
