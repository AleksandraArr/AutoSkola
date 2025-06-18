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
            try
            {
                List<Polaznik> polaznici = (List<Polaznik>)Communication.Instance.VratiListuSviPolaznik().Data;

                if (polaznici == null | polaznici.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih korisnika.");
                    ucObrazac.CmbPolaznik.DataSource = null;
                    return;
                }
                sviPolaznici = polaznici;
                ucObrazac.CmbPolaznik.DataSource = sviPolaznici;
                ucObrazac.CmbPolaznikKriterijum.DataSource = sviPolaznici;
                ucObrazac.CmbPolaznik.ValueMember = "IdPolaznik";
                ucObrazac.CmbPolaznik.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbPolaznik.SelectedIndex = -1;
                ucObrazac.CmbPolaznikKriterijum.ValueMember = "IdPolaznik";
                ucObrazac.CmbPolaznikKriterijum.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbPolaznikKriterijum.SelectedIndex = -1;
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
        internal void VratiListuSviInstruktor()
        {
            try
            {
                List<Instruktor> instruktori = (List<Instruktor>)Communication.Instance.VratiListuSviInstruktor().Data;

                if (instruktori == null || instruktori.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih instruktora.");
                    ucObrazac.CmbInstruktor.DataSource = null;
                    return;
                }
                sviInstruktori = instruktori;
                ucObrazac.CmbInstruktor.DataSource = sviInstruktori;
                ucObrazac.CmbInstruktorKriterijum.DataSource = sviInstruktori;
                ucObrazac.CmbInstruktor.ValueMember = "IdInstruktor";
                ucObrazac.CmbInstruktor.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbInstruktor.SelectedIndex = -1;
                ucObrazac.CmbInstruktorKriterijum.ValueMember = "IdInstruktor";
                ucObrazac.CmbInstruktorKriterijum.DisplayMember = "ImeIPrezime";
                ucObrazac.CmbInstruktorKriterijum.SelectedIndex = -1;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da učita instruktore.\n" + ex.Message);

            }
        }
        internal void VratiListuSviAutomobil()
        {
            try
            {
                List<Automobil> automobili = (List<Automobil>)Communication.Instance.VratiListuSviAutomobil().Data;

                if (automobili == null || automobili.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih automobila.");
                    ucObrazac.CmbAutomobilKriterijum.DataSource = null;
                    return;
                }
                sviAutomobili = automobili;
                ucObrazac.CmbAutomobilKriterijum.DataSource = sviAutomobili;
                ucObrazac.CmbAutomobilKriterijum.ValueMember = "IdAutomobil";
                ucObrazac.CmbAutomobilKriterijum.DisplayMember = "Model";
                ucObrazac.CmbAutomobilKriterijum.SelectedIndex = -1;
                ucObrazac.CmbAutomobil.DataSource = sviAutomobili;
                ucObrazac.CmbAutomobil.ValueMember = "IdAutomobil";
                ucObrazac.CmbAutomobil.DisplayMember = "Model";
                ucObrazac.CmbAutomobil.SelectedIndex = -1;

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da učita automobile.\n" + ex.Message);

            }
        }
        internal void VratiListuSviEvidencioniObrazac()
        {
            try
            {
                List<EvidencioniObrazac> obrasci = (List<EvidencioniObrazac>)Communication.Instance.VratiListuSviEvidencioniObrazac().Data;

                if (obrasci == null || obrasci.Count == 0)
                {
                    MessageBox.Show("Trenutno nema unetih obrazaca.");
                    ucObrazac.CmbInstruktor.DataSource = null;
                    return;
                }
                PostaviEvidencioniObrazac(obrasci);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da učita obrasce.\n" + ex.Message);

            }
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
            List<EvidencioniObrazac> obrasci = (List<EvidencioniObrazac>) response.Data;
            if (response.IsSuccess)
            {
                MessageBox.Show("Sistem je našao evidencione obrasce po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PostaviEvidencioniObrazac(obrasci);
            }
            else
                MessageBox.Show("Sistem je ne može da nađe evidencione obrasce po zadatim kriterijumima", "Pronađeni obrasci", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //MessageBox.Show(">>>" + response.ExceptionMessage);
        }
        internal void PrikaziEvidencioniObrazac()
        {
            try
            {
                List<EvidencioniObrazac> obrasci = VratiListuEvidencioniObrazac();
                if (obrasci == null) return;
                if (obrasci != null && obrasci.Count > 0)
                {
                    MessageBox.Show("Sistem je našao evidencioni obrazac", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    ucObrazac.CmbPolaznik.SelectedValue = obrazac.Polaznik.IdPolaznik;
                    ucObrazac.CmbInstruktor.SelectedValue = obrazac.Instruktor.IdInstruktor;
                    ucObrazac.TxtBrCasova.Text = obrazac.BrojCasova.ToString();
                    ucObrazac.DtpDatumPocetka.Value = obrazac.DatumPocetka;
                    PostaviCas(obrazac.Casovi);

                }
                else
                    MessageBox.Show("Sistem ne može da nađe evidencioni obrazac", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da prikaže evidencioni obrazac.\n" + ex.Message);
            }
        }
        internal void ObrisiEvidencioniObrazac()
        {

            List<EvidencioniObrazac> obrasci = VratiListuEvidencioniObrazac();
            try
            {   if (obrasci != null)
                {
                    Communication.Instance.ObrisiEvidencioniObrazac(obrasci[0]);
                    MessageBox.Show("Sistem je obrisao evidencioni obrazac!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obriše evidencioni obrazac.\n" + ex.Message);
            }
        }
        internal void PromeniEvidencioniObrazac()
        {
            try
            {
                List<EvidencioniObrazac> obrasci = VratiListuEvidencioniObrazac();
                if (obrasci == null) return;
                if (!ucObrazac.Validacija())
                {
                    MessageBox.Show("Molim vas unesite sva polja!");
                    return;
                }
                EvidencioniObrazac obrazac = obrasci[0];
                obrazac.Polaznik = (Polaznik)ucObrazac.CmbPolaznik.SelectedItem;
                obrazac.Instruktor = (Instruktor)ucObrazac.CmbInstruktor.SelectedItem;
                obrazac.BrojCasova = int.Parse(ucObrazac.TxtBrCasova.Text);
                obrazac.DatumPocetka = ucObrazac.DtpDatumPocetka.Value;
                obrazac.Casovi = casovi;
                Communication.Instance.PromeniEvidencioniObrazac(obrazac);
                MessageBox.Show("Sistem je zapamtio evidencioni obrazac!", "Operacija uspešno izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti evidencioni obrazac.\n" + ex.Message);
            }
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
        }
        private void DovrsiObjekte(List<EvidencioniObrazac> obrasci)
        {
            foreach (var o in obrasci)
            {
                o.Polaznik = sviPolaznici.FirstOrDefault(p => p.IdPolaznik == o.Polaznik.IdPolaznik);
                o.Instruktor = sviInstruktori.FirstOrDefault(i => i.IdInstruktor == o.Instruktor.IdInstruktor);
            }
        }
        private List<EvidencioniObrazac> VratiListuEvidencioniObrazac() {
            if (ucObrazac.DgvEvidencioniObrasci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite evidencioni obrazac za prikaz!");
                return null;
            }
             DataGridViewRow red = ucObrazac.DgvEvidencioniObrasci.SelectedRows[0];
             EvidencioniObrazac obrazac = (EvidencioniObrazac)red.DataBoundItem;
             Response response = Communication.Instance.VratiListuEvidencioniObrazac(obrazac);
            return (List<EvidencioniObrazac>)response.Data ;
        }

        internal void PrikaziCas()
        {
            try
            {
                if (this.obrazac == null)
                {
                    MessageBox.Show("Nije selektovan  evidencioni obrazac", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ucObrazac.DgvCasovi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Odaberite cas za prikaz!");
                    return;
                }
                DataGridViewRow red = ucObrazac.DgvCasovi.SelectedRows[0];
                Cas cas = (Cas)red.DataBoundItem;
               
                ucObrazac.TxtTrajanje.Text = cas.Trajanje.ToString();
                ucObrazac.DtpDatumCasa.Value = cas.Datum;
                ucObrazac.CmbAutomobil.SelectedValue = cas.Automobil.IdAutomobil;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da prikaže evidencioni obrazac.\n" + ex.Message);
                return;
            }
        }

        internal void DodajCas() {
            try
            {
                if (!ucObrazac.ValidacijaCas())
                {
                    MessageBox.Show("Molim vas unesite sva polja!");
                    return;
                }
                Cas cas = new Cas();
                cas.Obrazac.IdObrazac = obrazac.IdObrazac;
                cas.Automobil = (Automobil)ucObrazac.CmbAutomobil.SelectedItem;
                cas.Datum = ucObrazac.DtpDatumCasa.Value;
                cas.Trajanje = int.Parse(ucObrazac.TxtTrajanje.Text);
                casovi.Add(cas);
                PostaviCas(casovi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da doda cas.\n" + ex.Message);
            }
        }

        internal void IzmeniCas() {
            try
            {
                if (!ucObrazac.ValidacijaCas())
                {
                    MessageBox.Show("Molim vas unesite sva polja!");
                    return;
                }
                Cas cas = (Cas)ucObrazac.DgvCasovi.SelectedRows[0].DataBoundItem;
                int indeks = casovi.IndexOf(cas);
                cas.Obrazac.IdObrazac = obrazac.IdObrazac;
                cas.Automobil = (Automobil)ucObrazac.CmbAutomobil.SelectedItem;
                cas.Datum = ucObrazac.DtpDatumCasa.Value;
                cas.Trajanje = int.Parse(ucObrazac.TxtTrajanje.Text);
                casovi[indeks] = cas;
                PostaviCas(casovi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da izmeni cas.\n" + ex.Message);
            }
        }
    }
}
