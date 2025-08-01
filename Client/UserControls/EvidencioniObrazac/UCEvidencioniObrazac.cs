﻿using Client.GuiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls.EvidencioniObrazac
{
    public partial class UCEvidencioniObrazac : UserControl
    {
        private EvidencioniObrazciController obrazacController;
        public UCEvidencioniObrazac()
        {
            InitializeComponent();
            obrazacController = new EvidencioniObrazciController(this);
        }

        private void UCEvidencioniObrazac_Load(object sender, EventArgs e)
        {
            obrazacController.VratiListuSviInstruktor();
            obrazacController.VratiListuSviPolaznik();
            obrazacController.VratiListuSviAutomobil();
            obrazacController.VratiListuSviEvidencioniObrazac();
            gpbKriterijumi.Visible = false;
        }

        private void btnKriterijumi_Click(object sender, EventArgs e)
        {
            gpbKriterijumi.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            gpbKriterijumi.Visible = false;
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            obrazacController.PretraziEvidencioniObrazac();
            gpbKriterijumi.Visible = false;
        }
        public bool Validacija()
        {
            if (CmbPolaznik.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati polaznika.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (CmbInstruktor.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati instruktora.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtBrCasova.Text))
            {
                MessageBox.Show("Morate uneti broj časova.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(TxtBrCasova.Text, out int brojCasova) || brojCasova <= 0)
            {
                MessageBox.Show("Broj časova mora biti pozitivan ceo broj.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbInstruktor.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati instruktora.");
                return false;
            }
            if (CmbPolaznik.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati polaznika.");
                return false;
            }
            return true;
        }
        public bool ValidacijaCas()
        {

            if (string.IsNullOrWhiteSpace(TxtTrajanje.Text))
            {
                MessageBox.Show("Morate uneti trajanje časa.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(TxtTrajanje.Text, out int trajanje) || trajanje <= 0)
            {
                MessageBox.Show("Trajanje mora biti pozitivan ceo broj.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (DtpDatumPocetka.Value.Date < DtpDatumPocetka.Value.Date)
            {
                MessageBox.Show("Datum časa ne može biti pre početka časova.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (CmbAutomobil.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati automobil.");
                return false;
            }
            return true;
        }

        private void dgvEvidencioniObrasci_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEvidencioniObrasci.SelectedRows.Count == 0)
                return;

            obrazacController.PrikaziEvidencioniObrazac();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if(Validacija())
                obrazacController.PromeniEvidencioniObrazac();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            obrazacController.ObrisiEvidencioniObrazac();
        }

        public void PrivremenoOnemoguciSelectionChanged()
        {
            DgvEvidencioniObrasci.SelectionChanged -= dgvEvidencioniObrasci_SelectionChanged;
        }

        public void VratiSelectionChanged()
        {
            DgvEvidencioniObrasci.SelectionChanged += dgvEvidencioniObrasci_SelectionChanged;
        }

        private void btnUkloniKriterijume_Click(object sender, EventArgs e)
        {
            obrazacController.VratiListuSviEvidencioniObrazac();
            gpbKriterijumi.Visible = false;
            cmbAutomobilKriterijum.SelectedIndex = -1;
            cmbInstruktorKriterijum.SelectedIndex = -1;
            cmbPolaznikKriterijum.SelectedIndex = -1;
        }

        private void btnKreirajPolaznik_Click(object sender, EventArgs e)
        {
            FrmKreiraj frm = new FrmKreiraj(FormType.KreirajEvidencioniObrazac);
            frm.ShowDialog();
        }

        private void dgvCasovi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCasovi.SelectedRows.Count == 0)
                return;

            obrazacController.PrikaziCas();
            btnDodajCas.Visible = false;
            btnIzmeniCas.Visible = true;
            btnIzmeniCas.Enabled = true;
            btnUkloniPodatke.Enabled = true;
        }

        private void btnUkloniPodatke_Click(object sender, EventArgs e)
        {
            txtTrajanje.Clear();
            cmbAutomobil.SelectedIndex = -1;
            btnIzmeniCas.Visible = false;
            btnUkloniPodatke.Enabled = false;
            btnDodajCas.Visible = true ;
        }

        private void btnDodajCas_Click(object sender, EventArgs e)
        {
            if(ValidacijaCas())
                obrazacController.DodajCas();
        }

        private void btnIzmeniCas_Click(object sender, EventArgs e)
        {
            if (ValidacijaCas())
                obrazacController.IzmeniCas();
        }
    }
}
