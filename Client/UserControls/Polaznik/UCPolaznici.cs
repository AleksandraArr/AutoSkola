using Client.GuiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls.Polaznik
{
    public partial class UCPolaznici : UserControl
    {
        private PolazniciController polazniciController;
        public UCPolaznici()
        {
            InitializeComponent();
            polazniciController = new PolazniciController(this);
        }

        private void btnPrikaziPolaznike_Click(object sender, EventArgs e)
        {
            if (dgvPolaznici.DataSource != null)
            {
                dgvPolaznici.DataSource = null;
                dgvPolaznici.Refresh();
            }
            else
            {
                polazniciController.VratiListuSviPolaznik();
                dgvPolaznici.Columns["IdPolaznik"].Visible = false;
                dgvPolaznici.Columns["TableName"].Visible = false;
                dgvPolaznici.Columns["Values"].Visible = false;
                dgvPolaznici.Columns["WhereCondition"].Visible = false;
                dgvPolaznici.Columns["UpdateText"].Visible = false;
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            polazniciController.PromeniPolaznik();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            polazniciController.ObrisiPolaznik();
        }

        private void txtImeIPrezime_TextChanged(object sender, EventArgs e)
        {
            polazniciController.PretraziPolaznikaChanged();
        }

        private void dgvPolaznici_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvPolaznici.SelectedRows.Count == 0)
                return;
            polazniciController.PrikaziPolaznika();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            polazniciController.PretraziPolaznika();
        }
        public bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TxtKontaktTelefon.Text))
            {
                MessageBox.Show("Morate uneti kontakt telefon.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtPrezime.Text))
            {
                MessageBox.Show("Morate uneti prezime.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtIme.Text))
            {
                MessageBox.Show("Morate uneti ime.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (DateTimePicker1.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Datum rođenja ne može biti danas ili u budućnosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

    }
}
