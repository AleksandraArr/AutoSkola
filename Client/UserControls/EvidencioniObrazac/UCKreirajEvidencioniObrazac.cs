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

namespace Client.UserControls.EvidencioniObrazac
{
    public partial class UCKreirajEvidencioniObrazac : UserControl
    {

        KreirajEvidencioniObrazacController obrazacController;
        public UCKreirajEvidencioniObrazac()
        {
            InitializeComponent();
            obrazacController = new KreirajEvidencioniObrazacController(this);
            obrazacController.VratiListuSviInstruktor();
            obrazacController.VratiListuSviPolaznik();
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

            if (DtpDatumPocetka.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Datum početka ne može biti u prošlosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            obrazacController.KreirajEvidencioniObrazac();
        }

        private void btnUbaci_Click(object sender, EventArgs e)
        {
            obrazacController.PromeniEvidencioniObrazac();
        }
    }
}
