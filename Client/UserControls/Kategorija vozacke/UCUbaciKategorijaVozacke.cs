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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Client.UserControls.Kategorija_vozacke
{
    public partial class UCUbaciKategorijaVozacke : UserControl
    {
        private KategorijaVozackeController kategorijaVozackeController;
        public UCUbaciKategorijaVozacke()
        {
            InitializeComponent();
            kategorijaVozackeController = new KategorijaVozackeController(this);
            
        }

        public bool Validacija()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtJacinaMotora.Text))
            {
                MessageBox.Show("Morate uneti jacinu motora.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }
            else if (!IspravnaJedinica(txtJacinaMotora.Text))
            {
                if (double.TryParse(txtJacinaMotora.Text.Trim(), out double broj))
                    txtJacinaMotora.Text = $"{broj}kW";
                else
                {
                    MessageBox.Show("Morate uneti jedinicu KW motora.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isValid = false;
                }
            }
            if (string.IsNullOrEmpty(txtKategorija.Text))
            {
                MessageBox.Show("Morate uneti kategoriju vozacke dozvole.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                isValid = false;
            }
            return isValid;
        }

        private bool IspravnaJedinica(string tekst)
        {
            string lower = tekst.ToLower().Trim();
            return lower.EndsWith("kw") || lower.EndsWith("ks") || lower.EndsWith("hp");
        }

        private void btnUbaci_Click(object sender, EventArgs e)
        {
            if(Validacija())
                kategorijaVozackeController.UbaciKategorijaVozacke();
        }
    }
}
