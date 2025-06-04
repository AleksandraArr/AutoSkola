using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class MainCoordinator
    {
        private static MainCoordinator instance;
        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainCoordinator();
                }
                return instance;
            }
        }

        private MainCoordinator()
        {
        }

        private FrmMain frmMain;

        internal void ShowFrmMain()
        {
            try
            {
                frmMain = new FrmMain();
                frmMain.AutoSize = true;
                frmMain.ShowDialog();
            }
            catch {
                MessageBox.Show("Ne moze da se otvori glavna forma i meni");
            }
        }

        internal void ShowAddPersonPanel()
        {
        }


    }
}
