using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaVadras
{
    public partial class FrmLoading : Form
    {
        public string IzabraniLokal { get; private set; } = "";

        public FrmLoading()
        {
            InitializeComponent();
        }

        private void btnPiramida_Click(object sender, EventArgs e)
        {
            IzabraniLokal = "Piramida";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void brnBrdo_Click(object sender, EventArgs e)
        {
            IzabraniLokal = "Banovo brdo";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
