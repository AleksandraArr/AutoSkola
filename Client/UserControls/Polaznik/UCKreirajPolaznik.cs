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
    public partial class UCKreirajPolaznik : UserControl, IKreirajUC
    {
        KreirajPolaznikController polaznikController;
        public UCKreirajPolaznik()
        {
            InitializeComponent();
            polaznikController = new KreirajPolaznikController(this);
        }

        private void btnUbaci_Click(object sender, EventArgs e)
        {
            polaznikController.PromeniPolaznik();
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            polaznikController.KreirajPolaznika();
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

            if (dtpDatumRodjenja.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Datum rođenja ne može biti danas ili u budućnosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        public void OnLeave()
        {
            if (!polaznikController.ZavrsenoKreiranje)
                polaznikController.ObrisiPolaznik();
        }
    }
}
