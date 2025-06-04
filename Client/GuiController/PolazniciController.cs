using Client.UserControls.Polaznik;
using Common.Communication;
using Common.Domain;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class PolazniciController
    {
        private UCPolaznici ucPolaznici;

        public PolazniciController(UCPolaznici ucPolaznici) {
            this.ucPolaznici = ucPolaznici;
        }

        internal void VratiListuSviPolaznik()
        {
            try
            {
                List<Polaznik> polaznici = (List<Polaznik>)Communication.Instance.VratiListuSviPolaznik().Data;

                if (polaznici == null | polaznici.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih korisnika.");
                    ucPolaznici.DgvPolaznici.DataSource = null;
                    return;
                }
                PostaviPolaznik(polaznici);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da učita korisnike.\n" + ex.Message);

            }
        }
        public void PretraziPolaznika()
        {
            Response response = Communication.Instance.PretraziPolaznik(ucPolaznici.TxtImeIPrezime.Text);
            List<Polaznik> polaznici = (List<Polaznik>)response.Data;
            if (response.IsSuccess)
            {
                if (polaznici.Count == 0)
                    MessageBox.Show("Sistem nije našao polaznike po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else { MessageBox.Show("Sistem je našao polaznike po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                PostaviPolaznik(polaznici);
            }
            else
                MessageBox.Show("Sistem je ne može da nađe evidencione obrasce po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void PretraziPolaznikaChanged()
        {
            Response response = Communication.Instance.PretraziPolaznik(ucPolaznici.TxtImeIPrezime.Text);
            List<Polaznik> polaznici = (List<Polaznik>)response.Data;
            if (response.IsSuccess)
            {
                PostaviPolaznik(polaznici);
            }
            else
                MessageBox.Show("Sistem je ne može da nađe evidencione obrasce po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal void PrikaziPolaznika()
        {
            try
            {
                List<Polaznik> polaznici = VratiListuPolaznik();
                if (polaznici == null || polaznici.Count == 0)
                {
                    MessageBox.Show("Sistem ne može da nađe polaznika.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                };
                    MessageBox.Show("Sistem je našao polaznika.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Polaznik polaznik = polaznici[0];
                    ucPolaznici.TxtIme.Text = polaznik.Ime;
                    ucPolaznici.TxtPrezime.Text = polaznik.Prezime;
                    ucPolaznici.DateTimePicker1.Value = polaznik.DatumRodjenja;
                    ucPolaznici.TxtKontaktTelefon.Text = polaznik.Telefon;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da prikaže evidencioni obrazac.\n" + ex.Message);
            }
        }

        internal void PromeniPolaznik()
        {
            try
            {
                List<Polaznik> polaznici = VratiListuPolaznik();
                if (polaznici == null) return;
                if (!ucPolaznici.Validacija()) {
                    MessageBox.Show("Molim vas unesite sva polja!");
                }
                Polaznik polaznik = polaznici[0];
                polaznik.Ime = ucPolaznici.TxtIme.Text;
                polaznik.Prezime = ucPolaznici.TxtPrezime.Text;
                polaznik.DatumRodjenja = ucPolaznici.DateTimePicker1.Value;
                polaznik.Telefon = ucPolaznici.TxtKontaktTelefon.Text;

                Communication.Instance.PromeniPolaznik(polaznik);
                MessageBox.Show("Sistem je promenio polaznika!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da promeni polaznika.\n" + ex.Message);
            }
        }

        internal void ObrisiPolaznik()
        {
            List<Polaznik> polaznici = VratiListuPolaznik();
            try
            {
                if (polaznici != null)
                {
                    Communication.Instance.ObrisiPolaznik(polaznici[0]);
                    MessageBox.Show("Sistem je obrisao polaznika!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obrisao polaznika.\n" + ex.Message);
            }
        }

        private void PostaviPolaznik(List<Polaznik> polaznici)
        {
            ucPolaznici.DgvPolaznici.DataSource = polaznici;

            ucPolaznici.DgvPolaznici.Columns["IdPolaznik"].Visible = false;
            ucPolaznici.DgvPolaznici.Columns["TableName"].Visible = false;
            ucPolaznici.DgvPolaznici.Columns["Values"].Visible = false;
            ucPolaznici.DgvPolaznici.Columns["UpdateText"].Visible = false;
            ucPolaznici.DgvPolaznici.Columns["WhereCondition"].Visible = false;
            ucPolaznici.DgvPolaznici.Columns["ImeIPrezime"].Visible = false;

        }

        private List<Polaznik> VratiListuPolaznik()
        {
            if (ucPolaznici.DgvPolaznici.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite polaznika za prikaz!");
                return null;
            }
            DataGridViewRow red = ucPolaznici.DgvPolaznici.SelectedRows[0];
            Polaznik polaznik = (Polaznik)red.DataBoundItem;
            Response response = Communication.Instance.VratiListuPolaznik(polaznik);
            return (List<Polaznik>)response.Data;
        }
    }
}
