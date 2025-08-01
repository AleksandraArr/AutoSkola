﻿using Client.UserControls;
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
        FormType formType;
        public FrmKreiraj(FormType formType)
        {
            InitializeComponent();
            this.formType = formType;
            if (formType == FormType.KreirajPolaznik)
            {
                aktivniUC = new UCKreirajPolaznik();
                this.Size = new Size(560, 500);
                pnlMain.Size = new Size(560, 500);
            }
            if (formType == FormType.KreirajEvidencioniObrazac)
            {
                aktivniUC = new UCKreirajEvidencioniObrazac();
                this.Size = new Size(578, 941);
                pnlMain.Size = new Size(578, 941);

            }
            ChangePanel((UserControl)aktivniUC);
            UserControl uc = (UserControl)aktivniUC;

            uc.Dock = DockStyle.None;
            uc.Location = new Point(0, 0);


            pnlMain.Size = uc.Size;

            this.Size = new Size(pnlMain.Width + 16, pnlMain.Height + 39);

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
