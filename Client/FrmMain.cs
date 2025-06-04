using Client.UserControls.EvidencioniObrazac;
using Client.UserControls.Kategorija_vozacke;
using Client.UserControls.Polaznik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("sr-Latn-RS"); 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr-Latn-RS");
            ChangePanel(new UCEvidencioniObrazac());
        }
        private void ChangePanel(UserControl userControl)
        {
            try
            {
                pnlMain.Controls.Clear();
                userControl.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(userControl);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ubaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new UCUbaciKategorijaVozacke());
            this.Text = "Kategorije vozacke";
        }

        private void polazniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new UCPolaznici());
            this.Text = "Polaznici";
        }

        private void evidencioniObrazacMenuItem_Click(object sender, EventArgs e)
        {
            ChangePanel(new UCEvidencioniObrazac());
            this.Text = "Evidencioni obrasci";
        }
    }
}
