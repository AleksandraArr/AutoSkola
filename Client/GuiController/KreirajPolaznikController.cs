using Client.UserControls.Polaznik;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class KreirajPolaznikController
    {
        private UCKreirajPolaznik ucPolaznik;
        private int idPolaznik;
        public Boolean ZavrsenoKreiranje { get; private set; } = true;

        public KreirajPolaznikController(UCKreirajPolaznik ucPolaznik)
        {
            this.ucPolaznik = ucPolaznik;
        }

        internal void KreirajPolaznika()
        {
            Response response = Communication.Instance.KreirajPolaznik(new Polaznik());
      
            if (response.IsSuccess)
            {
                idPolaznik = ((Polaznik)response.Data).IdPolaznik;
                MessageBox.Show("Sistem je kreirao polaznika!", "Kreiranje polaznika", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucPolaznik.TxtIme.Enabled = true;
                ucPolaznik.TxtPrezime.Enabled = true;
                ucPolaznik.TxtKontaktTelefon.Enabled = true;
                ucPolaznik.DtpDatumRodjenja.Enabled = true;
                ucPolaznik.BtnUbaci.Enabled = true;
                ucPolaznik.BtnKreiraj.Enabled = false;
                ZavrsenoKreiranje = false;
            }
            else MessageBox.Show("Sistem ne može da kreira polaznika.", "Kreiranje polaznika", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        internal void PromeniPolaznik()
        {
            if (!ucPolaznik.Validacija())
            {
                MessageBox.Show("Molim vas unesite sva polja!");
                return;
            }
            Polaznik polaznik = new Polaznik();
            polaznik.IdPolaznik = idPolaznik;
            polaznik.Ime = ucPolaznik.TxtIme.Text;
            polaznik.Prezime = ucPolaznik.TxtPrezime.Text;
            polaznik.DatumRodjenja = ucPolaznik.DtpDatumRodjenja.Value;
            polaznik.Telefon = ucPolaznik.TxtKontaktTelefon.Text;

            Response response = Communication.Instance.PromeniPolaznik(polaznik);
            if (response.IsSuccess) { 
                ZavrsenoKreiranje = true;
                MessageBox.Show("Sistem je zapamtio polaznika!", "Izmena polaznika", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Sistem ne može da zapamti polaznika.", "Izmena polaznika", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        internal void ObrisiPolaznik()
        {
            Response response = Communication.Instance.ObrisiPolaznik(new Polaznik() { IdPolaznik = idPolaznik });

            if (response.IsSuccess) return;
            else MessageBox.Show("Sistem ne može da obriše polaznika.");
        }
    }
}
