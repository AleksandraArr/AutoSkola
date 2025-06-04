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

namespace Client.UserControls.Kategorija_vozacke
{
    public partial class UCUbaciKategorijaVozacke : UserControl
    {
        private KategorijaVozackeController kategorijaVozackeController;
        public UCUbaciKategorijaVozacke()
        {
            InitializeComponent();
            kategorijaVozackeController = new KategorijaVozackeController(this);
            btnUbaci.Click += kategorijaVozackeController.UbaciKategorijaVozacke;
        }

        public bool Validacija()
        {
            txtJacinaMotora.BackColor = Color.White;
            txtKategorija.BackColor = Color.White;
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtJacinaMotora.Text))
            {
                txtJacinaMotora.BackColor = Color.Salmon;
                isValid = false;
            }
            else if (!IspravnaJedinica(txtJacinaMotora.Text))
            {
                if (double.TryParse(txtJacinaMotora.Text.Trim(), out double broj))
                    txtJacinaMotora.Text = $"{broj}kW";
                else
                {
                    txtJacinaMotora.BackColor = Color.Salmon;
                    isValid = false;
                }
            }
            if (string.IsNullOrEmpty(txtKategorija.Text))
            {
                txtKategorija.BackColor = Color.Salmon;
                isValid = false;
            }
            return isValid;
        }

        private bool IspravnaJedinica(string tekst)
        {
            string lower = tekst.ToLower().Trim();
            return lower.EndsWith("kw") || lower.EndsWith("ks") || lower.EndsWith("hp");
        }
    }
}
