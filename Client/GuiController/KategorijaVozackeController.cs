using Client.UserControls.Kategorija_vozacke;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class KategorijaVozackeController
    {
        public KategorijaVozackeController(UCUbaciKategorijaVozacke uc) {
            ucUbaciKategorijaVozacke = uc;
        }

        private UCUbaciKategorijaVozacke ucUbaciKategorijaVozacke;

        public void UbaciKategorijaVozacke(object sender, EventArgs e)
        {
            if (!ucUbaciKategorijaVozacke.Validacija())
                return;
            KategorijaVozacke kategorija = new KategorijaVozacke
            {
                JacinaMotora = ucUbaciKategorijaVozacke.TxtJacinaMotora.Text,
                Kategorija = ucUbaciKategorijaVozacke.TxtKategorija.Text
            };
            Response response = Communication.Instance.UbaciKategorijaVozacke(kategorija);
            if (response.IsSuccess)
                MessageBox.Show("Sistem je zapamtio kategoriju vozačke.", "Ubaci kategoriju vozačke", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Sistem ne može da zapamti kategoriju vozačke.", "Ubaci kategoriju vozačke", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
