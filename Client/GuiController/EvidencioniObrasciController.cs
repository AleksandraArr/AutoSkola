using Client.UserControls.EvidencioniObrazac;
using Client.UserControls.Polaznik;
using Common.Communication;
using Common.Domain;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class EvidencioniObrazciController
    {
        private UCEvidencioniObrazac ucObrazac;
        private List<Polaznik> sviPolaznici = new List<Polaznik>();
        private List<Instruktor> sviInstruktori = new List<Instruktor>();
        private List<Automobil> sviAutomobili = new List<Automobil>();
        private EvidencioniObrazac obrazac;
        private List<Cas> casovi;
        public EvidencioniObrazciController(UCEvidencioniObrazac ucObrazac) {
            this.ucObrazac = ucObrazac;
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
                sviPolaznici = polaznici;
                PopuniComboBox(ucObrazac.CmbPolaznik, polaznici, "IdPolaznik", "ImeIPrezime");
                PopuniComboBox(ucObrazac.CmbPolaznikKriterijum, polaznici, "IdPolaznik", "ImeIPrezime");
            }
            else MessageBox.Show("Sistem ne može da učita polaznike.");

            
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
                sviInstruktori = instruktori;
                PopuniComboBox(ucObrazac.CmbInstruktor, sviInstruktori, "IdInstruktor", "ImeIPrezime");
                PopuniComboBox(ucObrazac.CmbInstruktorKriterijum, sviInstruktori, "IdInstruktor", "ImeIPrezime");

            }
            else MessageBox.Show("Sistem ne može da učita instruktore.");
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
                    ucObrazac.CmbAutomobilKriterijum.DataSource = null;
                    return;
                }
                sviAutomobili = automobili;
                PopuniComboBox(ucObrazac.CmbAutomobilKriterijum, automobili, "IdAutomobil", "Model");
                PopuniComboBox(ucObrazac.CmbAutomobil, automobili, "IdAutomobil", "Model");
            }
            else MessageBox.Show("Sistem ne može da učita automobile.");

        }
        internal void VratiListuSviEvidencioniObrazac()
        {
            
            Response response = Communication.Instance.VratiListuSviEvidencioniObrazac();
            if (response.IsSuccess)
            {
                List<EvidencioniObrazac> obrasci = (List<EvidencioniObrazac>)response.Data;

                if (obrasci == null || obrasci.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih obrazaca.");
                    ucObrazac.DgvEvidencioniObrasci.DataSource = null;
                    return;
                }
                PostaviEvidencioniObrazac(obrasci);
            }
            else MessageBox.Show("Sistem ne može da učita evidencione obrasce.");
            
        }
        public void PretraziEvidencioniObrazac()
        {
            Automobil automobil = (Automobil)ucObrazac.CmbAutomobilKriterijum.SelectedItem;
            Instruktor instruktor = (Instruktor)ucObrazac.CmbInstruktorKriterijum.SelectedItem;
            Polaznik polaznik = (Polaznik)ucObrazac.CmbPolaznikKriterijum.SelectedItem;
            EvidencioniObrazacKriterijumiDTO kriterijumi = new EvidencioniObrazacKriterijumiDTO
            {
                Polaznik = polaznik,    
                Instruktor = instruktor,
                Automobil = automobil
            };
            if (kriterijumi.Polaznik == null && kriterijumi.Instruktor == null & kriterijumi.Automobil == null)
            {
                MessageBox.Show("Niste izabrali kriterijume za pretragu!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Response response = Communication.Instance.PretraziEvidencioniObrazac(kriterijumi);
            if (response.IsSuccess)
            {
                List<EvidencioniObrazac> obrasci = (List<EvidencioniObrazac>)response.Data;
                if (obrasci.Count > 0)
                {
                    MessageBox.Show("Sistem je našao evidencione obrasce po zadatim kriterijumima.", "Pretraga obrazaca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PostaviEvidencioniObrazac(obrasci);
                }
                else MessageBox.Show("Nema obrazaca koji odgovaraju pretrazi.", "Pretraga obrazaca", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Sistem ne može da nađe evidencione obrasce po zadatim kriterijumima.", "Pretraga obrazaca", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal void PrikaziEvidencioniObrazac()
        {
            List<EvidencioniObrazac> obrasci = VratiListuEvidencioniObrazac();
            if (obrasci == null) return;
            if (obrasci.Count > 0)
            {
                MessageBox.Show("Sistem je našao evidencioni obrazac.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.obrazac = obrasci[0];
                this.casovi = obrazac.Casovi;
                ucObrazac.CmbPolaznik.Enabled = true;
                ucObrazac.CmbInstruktor.Enabled = true;
                ucObrazac.TxtBrCasova.Enabled = true;
                ucObrazac.DtpDatumPocetka.Enabled = true;
                ucObrazac.TxtTrajanje.Enabled = true;
                ucObrazac.CmbAutomobil.Enabled = true;
                ucObrazac.DtpDatumCasa.Enabled = true;
                ucObrazac.BtnDodajCas.Enabled = true;
                ucObrazac.CmbPolaznik.SelectedValue = obrazac.Polaznik?.IdPolaznik ?? -1;
                ucObrazac.CmbInstruktor.SelectedValue = obrazac.Instruktor?.IdInstruktor ?? -1;
                ucObrazac.TxtBrCasova.Text = obrazac.BrojCasova.ToString();
                ucObrazac.DtpDatumPocetka.Value = obrazac.DatumPocetka;
                PostaviCas(obrazac.Casovi);

            }
            else
                MessageBox.Show("Sistem ne može da nađe evidencioni obrazac.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal void ObrisiEvidencioniObrazac()
        {

            List<EvidencioniObrazac> obrasci = VratiListuEvidencioniObrazac();
            if (obrasci == null || obrasci.Count == 0)
            {
                MessageBox.Show("Sistem ne može da nađe evidencioni obrazac!", "Brisanje evidencionog obrazca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Response response = Communication.Instance.ObrisiEvidencioniObrazac(obrasci[0]);

            if (response.IsSuccess){
                MessageBox.Show("Sistem je obrisao evidencioni obrazac!", "Brisanje  evidencionog obrazca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VratiListuSviEvidencioniObrazac();
            }
            else MessageBox.Show("Sistem ne može da obriše  evidencioni obrazac!", "Brisanje  evidencionog obrazca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        }
        internal void PromeniEvidencioniObrazac()
        {
            List<EvidencioniObrazac> obrasci = VratiListuEvidencioniObrazac();
            if (obrasci == null || obrasci.Count == 0)
            {
                MessageBox.Show("Sistem ne može da nađe evidencioni obrazac!", "Izmena evidencionog obrazca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EvidencioniObrazac obrazac = obrasci[0];
            obrazac.Polaznik = (Polaznik)ucObrazac.CmbPolaznik.SelectedItem;
            obrazac.Instruktor = (Instruktor)ucObrazac.CmbInstruktor.SelectedItem;
            obrazac.BrojCasova = int.Parse(ucObrazac.TxtBrCasova.Text);
            obrazac.DatumPocetka = ucObrazac.DtpDatumPocetka.Value;
            obrazac.Casovi = casovi;
            Response response = Communication.Instance.PromeniEvidencioniObrazac(obrazac);
            if (response.IsSuccess)
            {
                MessageBox.Show("Sistem je zapamtio evidencioni obrazac!", "Izmena evidencionog obrazca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VratiListuSviEvidencioniObrazac();
            }
            else MessageBox.Show("Sistem ne može da zapamti evidencioni obrazac!", "Izmena evidencionog obrazca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void PostaviEvidencioniObrazac(List<EvidencioniObrazac> obrasci)
        {
            DovrsiObjekte(obrasci);
            ucObrazac.DgvEvidencioniObrasci.DataSource = obrasci;

            ucObrazac.DgvEvidencioniObrasci.Columns["IdObrazac"].Visible = false;
            ucObrazac.DgvEvidencioniObrasci.Columns["TableName"].Visible = false;
            ucObrazac.DgvEvidencioniObrasci.Columns["Values"].Visible = false;
            ucObrazac.DgvEvidencioniObrasci.Columns["UpdateText"].Visible = false;
            ucObrazac.DgvEvidencioniObrasci.Columns["WhereCondition"].Visible = false;
            ucObrazac.DgvEvidencioniObrasci.Columns["IdColumn"].Visible = false;
            ucObrazac.DgvEvidencioniObrasci.Columns["ColumnName"].Visible = false;

        }
        private void PostaviCas(List<Cas> casovi)
        {
            ucObrazac.DgvCasovi.DataSource = null;
            ucObrazac.DgvCasovi.DataSource = casovi;
             foreach (var c in casovi)
                    c.Automobil = sviAutomobili.FirstOrDefault(a => a.IdAutomobil == c.Automobil.IdAutomobil);
            ucObrazac.DgvCasovi.Columns["Obrazac"].Visible = false;
            ucObrazac.DgvCasovi.Columns["IdCas"].Visible = false;
            ucObrazac.DgvCasovi.Columns["TableName"].Visible = false;
            ucObrazac.DgvCasovi.Columns["Values"].Visible = false;
            ucObrazac.DgvCasovi.Columns["UpdateText"].Visible = false;
            ucObrazac.DgvCasovi.Columns["WhereCondition"].Visible = false;
            ucObrazac.DgvCasovi.Columns["IdColumn"].Visible = false;
            ucObrazac.DgvCasovi.Columns["Datum"].DefaultCellStyle.Format = "dd.MM.yyyy";
            ucObrazac.DgvCasovi.Columns["ColumnName"].Visible = false;
        }
        private void DovrsiObjekte(List<EvidencioniObrazac> obrasci)
        {
            foreach (var o in obrasci)
            {
                if (o.Polaznik != null)
                    o.Polaznik = sviPolaznici.FirstOrDefault(p => p.IdPolaznik == o.Polaznik.IdPolaznik);

                if (o.Instruktor != null)
                    o.Instruktor = sviInstruktori.FirstOrDefault(i => i.IdInstruktor == o.Instruktor.IdInstruktor);
            }
        }
        private List<EvidencioniObrazac> VratiListuEvidencioniObrazac() {
            if (ucObrazac.DgvEvidencioniObrasci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite evidencioni obrazac za prikaz!");
                return null;
            }
            EvidencioniObrazac obrazac = (EvidencioniObrazac)ucObrazac.DgvEvidencioniObrasci.SelectedRows[0].DataBoundItem;
            Response response = Communication.Instance.VratiListuEvidencioniObrazac(obrazac);
            if (response.IsSuccess)
                return (List<EvidencioniObrazac>)response.Data;
            MessageBox.Show("Sistem ne može da nađe evidencioni obrazac.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        internal void PrikaziCas()
        {
            try
            {
                if (this.obrazac == null)
                {
                    MessageBox.Show("Nije selektovan  evidencioni obrazac.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ucObrazac.DgvCasovi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Odaberite cas za prikaz!");
                    return;
                }
                Cas cas = (Cas)ucObrazac.DgvCasovi.SelectedRows[0].DataBoundItem;
               
                ucObrazac.TxtTrajanje.Text = cas.Trajanje.ToString();
                ucObrazac.DtpDatumCasa.Value = cas.Datum;
                ucObrazac.CmbAutomobil.SelectedValue = cas.Automobil.IdAutomobil;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da prikaže čas.\n" + ex.Message);
                return;
            }
        }

        internal void DodajCas() {
            try
            {
                if (casovi.Count + 1 > int.Parse(ucObrazac.TxtBrCasova.Text))
                {
                    MessageBox.Show("Ne možete dodati više časova od broja časova obrasca.", "Dodavanje časa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Cas cas = new Cas();
                cas.Obrazac.IdObrazac = obrazac.IdObrazac;
                cas.Automobil = (Automobil)ucObrazac.CmbAutomobil.SelectedItem;
                cas.Datum = ucObrazac.DtpDatumCasa.Value;
                cas.Trajanje = int.Parse(ucObrazac.TxtTrajanje.Text);
                casovi.Add(cas);
                PostaviCas(casovi);
                ucObrazac.CmbAutomobil.SelectedIndex = -1;
                ucObrazac.TxtTrajanje.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da doda čas.\n" + ex.Message);
            }
        }

        internal void IzmeniCas() {
            try
            {
                Cas cas = (Cas)ucObrazac.DgvCasovi.SelectedRows[0].DataBoundItem;
                int indeks = casovi.IndexOf(cas);
                cas.Obrazac.IdObrazac = obrazac.IdObrazac;
                cas.Automobil = (Automobil)ucObrazac.CmbAutomobil.SelectedItem;
                cas.Datum = ucObrazac.DtpDatumCasa.Value;
                cas.Trajanje = int.Parse(ucObrazac.TxtTrajanje.Text);
                casovi[indeks] = cas;
                PostaviCas(casovi);
                ucObrazac.CmbAutomobil.SelectedIndex = -1;
                ucObrazac.TxtTrajanje.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni čas.\n" + ex.Message);
            }
        }
        private void PopuniComboBox<T>(ComboBox comboBox, List<T> dataSource, string valueMember, string displayMember)
        {

            comboBox.DataSource = new List<T>(dataSource);
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.SelectedIndex = -1;
        }

    }
}
