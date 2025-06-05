using Client.UserControls.EvidencioniObrazac;
using Client.UserControls.Polaznik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public enum FormType { 
        KreirajPolaznik,
        KreirajEvidencioniObrazac
    }
    public partial class FrmKreiraj : Form
    {
        UCKreirajEvidencioniObrazac ucKreirajEvidencioniObrazac;
        UCKreirajPolaznik ucKreirajPolaznik;
        FormType formType;
        public FrmKreiraj(FormType formType)
        {
            InitializeComponent();
            if (formType == FormType.KreirajPolaznik)
            {
                ucKreirajPolaznik = new UCKreirajPolaznik();
                this.formType = FormType.KreirajPolaznik;
                ChangePanel(ucKreirajPolaznik);
            }
            if (formType == FormType.KreirajEvidencioniObrazac)
            {
                ucKreirajEvidencioniObrazac = new UCKreirajEvidencioniObrazac();
                this.formType = FormType.KreirajEvidencioniObrazac;
                ChangePanel(ucKreirajEvidencioniObrazac);
            }
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

        private void FrmKreiraj_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (formType == FormType.KreirajPolaznik) ucKreirajPolaznik.UCKreirajPolaznik_Leave();
            if (formType == FormType.KreirajEvidencioniObrazac) ucKreirajEvidencioniObrazac.UCKreirajEvidencioniObrazac_Leave();
        }
    }
}
