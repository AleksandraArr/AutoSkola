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
using System.Windows.Forms;

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
            Response response = Communication.Instance.VratiListuSviPolaznik();
            if (response.IsSuccess) { 
                List<Polaznik> polaznici = (List<Polaznik>)response.Data;
                if (polaznici == null | polaznici.Count == 0) {
                    MessageBox.Show("Trenutno nema unetih korisnika.");
                    ucPolaznici.DgvPolaznici.DataSource = null;
                    return;
                }
                PostaviPolaznik(polaznici);
            }
            else MessageBox.Show("Sistem ne može da nađe polaznike!", "Polaznici", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void PretraziPolaznika()
        {
            Response response = Communication.Instance.PretraziPolaznik(ucPolaznici.TxtImeIPrezime.Text);
            if (response.IsSuccess) {
                List<Polaznik> polaznici = (List<Polaznik>)response.Data;
                if (polaznici.Count == 0)
                    MessageBox.Show("Sistem nije našao polaznike po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Sistem je našao polaznike po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                PostaviPolaznik(polaznici);
            }
            else
                MessageBox.Show("Sistem ne može da nađe polaznike po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void PretraziPolaznikaChanged()
        {
            Response response = Communication.Instance.PretraziPolaznik(ucPolaznici.TxtImeIPrezime.Text);
            
            if (response.IsSuccess) {
                List<Polaznik> polaznici = (List<Polaznik>)response.Data;
                PostaviPolaznik(polaznici);
            }
            else MessageBox.Show("Sistem ne može da nađe polaznike po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal void PrikaziPolaznika()
        {
            List<Polaznik> polaznici = VratiListuPolaznik();
            if (polaznici == null || polaznici.Count == 0) 
                return;

            MessageBox.Show("Sistem je našao polaznika.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Polaznik polaznik = polaznici[0];
            ucPolaznici.TxtIme.Text = polaznik.Ime;
            ucPolaznici.TxtPrezime.Text = polaznik.Prezime;
            DateTime datum = polaznik.DatumRodjenja;

            if (datum < ucPolaznici.DateTimePicker1.MinDate)
            {
                ucPolaznici.DateTimePicker1.Value = ucPolaznici.DateTimePicker1.MinDate;
                ucPolaznici.DateTimePicker1.Checked = false;
            }
            else
            {
                ucPolaznici.DateTimePicker1.Value = datum;
                ucPolaznici.DateTimePicker1.Checked = true;
            }
            ucPolaznici.TxtKontaktTelefon.Text = polaznik.Telefon;
        }

        internal void PromeniPolaznik()
        {
            List<Polaznik> polaznici = VratiListuPolaznik();
            if (polaznici == null || polaznici.Count == 0)
                return;
            Polaznik polaznik = polaznici[0];
            polaznik.Ime = ucPolaznici.TxtIme.Text;
            polaznik.Prezime = ucPolaznici.TxtPrezime.Text;
            polaznik.DatumRodjenja = ucPolaznici.DateTimePicker1.Value;
            polaznik.Telefon = ucPolaznici.TxtKontaktTelefon.Text;
            Response response = Communication.Instance.PromeniPolaznik(polaznik);
            if (response.IsSuccess) { MessageBox.Show("Sistem je zapamtio polaznika!", "Izmena polaznika", MessageBoxButtons.OK, MessageBoxIcon.Information); VratiListuSviPolaznik();
            } else MessageBox.Show("Sistem ne može da zapamti polaznika!", "Izmena polaznika", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        internal void ObrisiPolaznik()
        {
            List<Polaznik> polaznici = VratiListuPolaznik();
            if (polaznici == null || polaznici.Count == 0) 
                return;

            Response response = Communication.Instance.ObrisiPolaznik(polaznici[0]);
            if (response.IsSuccess) { MessageBox.Show("Sistem je obrisao polaznika!", "Brisanje polaznika", MessageBoxButtons.OK, MessageBoxIcon.Information); VratiListuSviPolaznik(); }
            else MessageBox.Show("Sistem ne može da obriše polaznika!", "Brisanje polaznika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ucPolaznici.DgvPolaznici.Columns["ColumnName"].Visible = false;
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
            if (response.IsSuccess)
                return (List<Polaznik>)response.Data;
            MessageBox.Show("Sistem ne može da nađe polaznika.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}
