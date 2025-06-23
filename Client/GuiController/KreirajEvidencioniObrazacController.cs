using Client.UserControls.EvidencioniObrazac;
using Client.UserControls.Polaznik;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class KreirajEvidencioniObrazacController
    {
        private UCKreirajEvidencioniObrazac ucObrazac;
        private int idObrasca;
        private List<Cas> casovi = new List<Cas>();
        public Boolean ZavrsenoKreiranje { get; private set; } = true;

        public KreirajEvidencioniObrazacController(UCKreirajEvidencioniObrazac ucObrazac)
        {
            this.ucObrazac = ucObrazac;

        }

        internal void KreirajEvidencioniObrazac()
        {
            if (ucObrazac.CmbInstruktor.Items?.Count == 0 || ucObrazac.CmbPolaznik.Items?.Count == 0 || ucObrazac.CmbAutomobil.Items?.Count == 0) {
                MessageBox.Show("Neophodno je da postoje instruktore, automobili i polaznici da biste kreirali evidencioni obrazac!", "Upozorenje",MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            EvidencioniObrazac obrazac = new EvidencioniObrazac()
            {
                DatumPocetka = DateTime.Now,
                BrojCasova = 0,
                Instruktor = null,
                Polaznik = null
            };
            Response response = Communication.Instance.KreirajEvidencioniObrazac(obrazac);
            
            if (response.IsSuccess)
            {
                idObrasca = ((EvidencioniObrazac)response.Data).IdObrazac;
                MessageBox.Show("Sistem je kreirao evidencioni obrazac!", "Kreiranje evidencionog obrasca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucObrazac.TxtBrCasova.Enabled = true;
                ucObrazac.CmbInstruktor.Enabled = true;
                ucObrazac.CmbPolaznik.Enabled = true;
                ucObrazac.DtpDatumPocetka.Enabled = true;
                ucObrazac.BtnUbaci.Enabled = true;
                ucObrazac.DtpDatum.Enabled = true;
                ucObrazac.TxtTrajanje.Enabled = true;
                ucObrazac.CmbAutomobil.Enabled = true;
                ucObrazac.BtnDodajCas.Enabled = true;
                ucObrazac.BtnKreiraj.Enabled = false;
                ZavrsenoKreiranje = false;
            }
            else MessageBox.Show("Sistem ne moze da kreira evidencioni obrazac!", "Kreiranje evidencionog obrasca", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        internal void PromeniEvidencioniObrazac()
        {

            if (!ucObrazac.Validacija())
                return;
            EvidencioniObrazac obrazac = new EvidencioniObrazac();
            obrazac.IdObrazac = idObrasca;
            obrazac.Polaznik = (Polaznik)ucObrazac.CmbPolaznik.SelectedItem;
            obrazac.Instruktor = (Instruktor)ucObrazac.CmbInstruktor.SelectedItem;
            obrazac.BrojCasova = int.Parse(ucObrazac.TxtBrCasova.Text);
            obrazac.DatumPocetka = ucObrazac.DtpDatumPocetka.Value;
            obrazac.Casovi = casovi;
            Response response = Communication.Instance.PromeniEvidencioniObrazac(obrazac);
            if (response.IsSuccess)
            {
                MessageBox.Show("Sistem je zapamtio evidencioni obrazac!", "Kreiranje evidencionog obrasca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ZavrsenoKreiranje = true;
            }
            else MessageBox.Show("Sistem ne može da zapamti evidencioni obrazac!", "Kreiranje evidencionog obrasca", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        internal void VratiListuSviPolaznik()
        {
            Response response = Communication.Instance.VratiListuSviPolaznik();
            if (response.IsSuccess)
            {
                List<Polaznik> polaznici = (List<Polaznik>)response.Data;

                if (polaznici == null | polaznici.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih korisnika.");
                    ucObrazac.CmbPolaznik.DataSource = null;
                    return;
                }
                ucObrazac.CmbPolaznik.DataSource = polaznici;
                ucObrazac.CmbPolaznik.ValueMember = "IdPolaznik";
                ucObrazac.CmbPolaznik.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbPolaznik.SelectedIndex = -1;
            }
            else MessageBox.Show("Sistem ne može da učita korisnike.");
            
        }
        internal void VratiListuSviInstruktor()
        {
            
            Response response = Communication.Instance.VratiListuSviInstruktor();
            if (response.IsSuccess)
            {
                List<Instruktor> instruktori = (List<Instruktor>)response.Data;

                if (instruktori == null || instruktori.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih instruktora.");
                    ucObrazac.CmbInstruktor.DataSource = null;
                    return;
                }
                ucObrazac.CmbInstruktor.DataSource = instruktori;
                ucObrazac.CmbInstruktor.ValueMember = "IdInstruktor";
                ucObrazac.CmbInstruktor.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbInstruktor.SelectedIndex = -1;
            }
            else MessageBox.Show("Sistem ne može da učita korisnike.");
             
           
        }
 
        internal void VratiListuSviAutomobil()
        {
            Response response = Communication.Instance.VratiListuSviAutomobil();
            if (response.IsSuccess)
            {
                List<Automobil> automobili = (List<Automobil>)response.Data;

                if (automobili == null || automobili.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih automobila.");
                    ucObrazac.CmbAutomobil.DataSource = null;
                    return;
                }
                ucObrazac.CmbAutomobil.DataSource = automobili;
                ucObrazac.CmbAutomobil.ValueMember = "IdAutomobil";
                ucObrazac.CmbAutomobil.DisplayMember = "Model";
                ucObrazac.CmbAutomobil.SelectedIndex = -1;
            }
            else MessageBox.Show("Sistem ne može da nađe automobile!", "Automobili", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        internal void DodajCas() {
            try
            {
                if (!ucObrazac.ValidacijaCas())
                    return;
                if (casovi.Count + 1 > int.Parse(ucObrazac.TxtBrCasova.Text))
                {
                    MessageBox.Show("Ne možete dodati više časova od broja časova obrasca.", "Dodavanje časa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Cas cas = new Cas();
                cas.Obrazac.IdObrazac = idObrasca;
                cas.Automobil = (Automobil)ucObrazac.CmbAutomobil.SelectedItem;
                cas.Datum = ucObrazac.DtpDatum.Value;
                cas.Trajanje = int.Parse(ucObrazac.TxtTrajanje.Text);
                casovi.Add(cas);
                PostaviCas(casovi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da doda cas.\n" + ex.Message);
            }
        }
        private void PostaviCas(List<Cas> casovi)
        {
            ucObrazac.DgvCasovi.DataSource = null;
            ucObrazac.DgvCasovi.DataSource = casovi;
            ucObrazac.DgvCasovi.Columns["Obrazac"].Visible = false;
            ucObrazac.DgvCasovi.Columns["IdCas"].Visible = false;
            ucObrazac.DgvCasovi.Columns["TableName"].Visible = false;
            ucObrazac.DgvCasovi.Columns["Values"].Visible = false;
            ucObrazac.DgvCasovi.Columns["UpdateText"].Visible = false;
            ucObrazac.DgvCasovi.Columns["WhereCondition"].Visible = false;
            ucObrazac.DgvCasovi.Columns["IdColumn"].Visible = false;
            ucObrazac.DgvCasovi.Columns["Datum"].DefaultCellStyle.Format = "dd.MM.yyyy";

        }
        internal void ObrisiEvidencioniObrazac()
        {
            Response response = Communication.Instance.ObrisiEvidencioniObrazac(new EvidencioniObrazac() { IdObrazac = idObrasca, Instruktor = new Instruktor(), Polaznik = new Polaznik() });
            if (response.IsSuccess) return;
            else MessageBox.Show("Sistem ne može da obriše evidencioni obrazac.");
        }
    }
}
