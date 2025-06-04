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
    public class UbaciPolaznikController
    {
        public UbaciPolaznikController(UCUbaciKategorijaVozacke uc) {
            ucUbaciKategorijaVozacke = uc;
        }

        private UCUbaciKategorijaVozacke ucUbaciKategorijaVozacke;


        public void UbaciPolaznik(object sender, EventArgs e)
        {
            if (!ucUbaciKategorijaVozacke.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja.");
                return;
            }

            KategorijaVozacke kategorija = new KategorijaVozacke
            {
                JacinaMotora = ucUbaciKategorijaVozacke.TxtJacinaMotora.Text,
                Kategorija = ucUbaciKategorijaVozacke.TxtKategorija.Text
            };
            Response response = Communication.Instance.UbaciKategorijaVozacke(kategorija);
            if (response.IsSuccess)
            {
                MessageBox.Show("Sistem je zapamtio kategoriju vozačke.");
            }
            else
            {
                MessageBox.Show(">>>" + response.ExceptionMessage);
            }
        }
    }
}
