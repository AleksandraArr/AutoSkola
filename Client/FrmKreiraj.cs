using Client.UserControls;
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
        IKreirajUC aktivniUC;
        //UCKreirajEvidencioniObrazac ucKreirajEvidencioniObrazac;
        //UCKreirajPolaznik ucKreirajPolaznik;
        FormType formType;
        public FrmKreiraj(FormType formType)
        {
            InitializeComponent();
            this.formType = formType;
            if (formType == FormType.KreirajPolaznik)
                aktivniUC = new UCKreirajPolaznik();
            if (formType == FormType.KreirajEvidencioniObrazac)
                aktivniUC = new UCKreirajEvidencioniObrazac();
            ChangePanel((UserControl)aktivniUC);

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
            aktivniUC.OnLeave();
        }
    }
}
