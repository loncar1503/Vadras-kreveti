using FormaVadras.Controllers;
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Unesite username i password");
                return;
            }

            var success = await AuthContr.LoginAsync(username, password);

            if (!success.IsSuccess)
            {
                MessageBox.Show("Pogrešan username ili lozinka");
                txtPassword.Text = "";
                txtUsername.Text = "";
                return;
            }

            MessageBox.Show("Dobrodosao, "+ success.Radnik.ImePrezime);
            this.Hide();
            FrmMain frmMain = new FrmMain(lokal,success.Radnik);
            frmMain.ShowDialog();
        }
    }
}
