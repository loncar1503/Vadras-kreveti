using QuestPDF.Infrastructure;

namespace FormaVadras
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string izabraniLokal = null;

            // 1. Prvo otvaramo formu za izbor lokala kao DIJALOG
            using (var frmIzbor = new FrmLoading())
            {
                var result = frmIzbor.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(frmIzbor.IzabraniLokal))
                {
                    izabraniLokal = frmIzbor.IzabraniLokal;
                }
                else
                {
                    // korisnik zatvorio ili ništa nije izabrao ? izlaz iz aplikacije
                    return;
                }
            }

            // 2. Tek sada startujemo GLAVNU formu, sa izabranim lokalom
            Application.Run(new FrmLogin(izabraniLokal));
        }
    }
}