using API_Vadras.DTO.Porudzbina;
using FormaVadras.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Fluent;

namespace FormaVadras.UserControlls
{
    public partial class UCSvePorudzbine : UserControl
    {
        PorudzbinaContr porudzbinaContr;

        public UCSvePorudzbine()
        {
            InitializeComponent();
            porudzbinaContr = new PorudzbinaContr();

            RefreshDgv();

        }



        public async void RefreshDgv()
        {
            dgvSvePorudzbine.DataSource = await porudzbinaContr.VratiSvePorudzbine();
            dgvSvePorudzbine.Columns["Id"].Visible = false;

        }
        private async void btnRacun_Click(object sender, EventArgs e)
        {
            if (dgvSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali porudžbinu.");
                return;
            }

            int id = (int)dgvSvePorudzbine.SelectedRows[0].Cells["Id"].Value;

            var porudzbina = await porudzbinaContr.VratiPorudzbinu(id);

            var doc = new RacunPorudzbinaDocument(
                porudzbina,
                headerImagePath: @"Resources/MemorandumHeader.jpg",
                footerImagePath: @"Resources/MemorandumFooter.jpg"
            );

            // putanja do Desktop-a
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            // naš folder na desktopu
            var folder = Path.Combine(desktop, "Vadras_Dokumenti");

            // kreiraj folder ako ne postoji
            Directory.CreateDirectory(folder);

            var safeBrRacuna = porudzbina.BrRacuna
                .Replace("/", "-")
                .Replace("\\", "-");

            string path = Path.Combine(
                folder,
                $"Racun_{safeBrRacuna}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            doc.GeneratePdf(path);

            Process.Start(new ProcessStartInfo(path)
            {
                UseShellExecute = true
            });
        }

        private void dgvSvePorudzbine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dgvSvePorudzbine_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header

            var dto = (UcitajSvePorudzbineDTO)dgvSvePorudzbine.Rows[e.RowIndex].DataBoundItem;

            int id = dto.Id; // ili string brRacuna, šta god imaš

            var frm = new FrmIzmeniPorudzbinu(id);
            frm.ShowDialog();
            RefreshDgv();
        }
    }
}
