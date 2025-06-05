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
        public FrmKreiraj(FormType formType)
        {
            InitializeComponent();
            if (formType == FormType.KreirajPolaznik)
                ChangePanel(new UCKreirajPolaznik());
            if (formType == FormType.KreirajEvidencioniObrazac)
                ChangePanel(new UCKreirajEvidencioniObrazac());
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
    }
}
