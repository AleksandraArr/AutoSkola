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
        private int idKorisnika;
        public Boolean ZavrsenoKreiranje { get; private set; } = true;

        public KreirajPolaznikController(UCKreirajPolaznik ucPolaznik)
        {
            this.ucPolaznik = ucPolaznik;
        }

        internal void KreirajPolaznika()
        {
            Response response = Communication.Instance.KreirajPolaznik(new Polaznik());
            try
            {
                if (response.IsSuccess)
                {
                    idKorisnika = ((Polaznik)response.Data).IdPolaznik;
                    MessageBox.Show("Sistem je kreirao polaznika!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ucPolaznik.TxtIme.Enabled = true;
                    ucPolaznik.TxtPrezime.Enabled = true;
                    ucPolaznik.TxtKontaktTelefon.Enabled = true;
                    ucPolaznik.DtpDatumRodjenja.Enabled = true;
                    ucPolaznik.BtnUbaci.Enabled = true;
                    ucPolaznik.BtnKreiraj.Enabled = false;
                    ZavrsenoKreiranje = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da kreirao polaznika.\n" + ex.Message);
            }
        }
        internal void PromeniPolaznik()
        {
            try
            {
                if (!ucPolaznik.Validacija())
                {
                    MessageBox.Show("Molim vas unesite sva polja!");
                }
                Polaznik polaznik = new Polaznik();
                polaznik.IdPolaznik = idKorisnika;
                polaznik.Ime = ucPolaznik.TxtIme.Text;
                polaznik.Prezime = ucPolaznik.TxtPrezime.Text;
                polaznik.DatumRodjenja = ucPolaznik.DtpDatumRodjenja.Value;
                polaznik.Telefon = ucPolaznik.TxtKontaktTelefon.Text;

                Communication.Instance.PromeniPolaznik(polaznik);
                ZavrsenoKreiranje = true;
                MessageBox.Show("Sistem je zapamtio polaznika!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti polaznika.\n" + ex.Message);
            }
        }
    }
}
