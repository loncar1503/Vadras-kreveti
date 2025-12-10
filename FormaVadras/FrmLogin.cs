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
    public partial class FrmLogin : Form
    {
        public string lokal;

        public FrmLogin(string lokal)
        {
            InitializeComponent();
            this.lokal = lokal;
        }

        private void btnLokal_Click(object sender, EventArgs e)
        {

            using (var frmIzbor = new FrmLoading())
            {
                var result = frmIzbor.ShowDialog(this);

                if (result == DialogResult.OK && !string.IsNullOrEmpty(frmIzbor.IzabraniLokal))
                {
                    lokal = frmIzbor.IzabraniLokal;

                    // ovde možeš da refresuješ podatke za novi lokal
                    // UcitajPodatkeZaLokal(_lokal);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMain frmMain = new FrmMain(lokal);
            frmMain.ShowDialog();
        }
    }
}
