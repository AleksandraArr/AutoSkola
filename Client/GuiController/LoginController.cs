using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class LoginController
    {
        private static LoginController instance;
        public static LoginController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginController();
                }
                return instance;
            }
        }
        private LoginController()
        {
        }

        private FrmLogin frmLogin;

        internal void ShowFrmLogin()
        {
            try
            {
                Communication.Instance.Connect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin = new FrmLogin();
                frmLogin.AutoSize = true;
                Application.Run(frmLogin);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Login(object sender, EventArgs e)
        {
            if (!frmLogin.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja.");
                return;
            }

            Instruktor instruktor = new Instruktor
            {
                KorisnickoIme = frmLogin.TxtKorisnickoIme.Text,
                Sifra = frmLogin.TxtSifra.Text,
            };
            Response response = Communication.Instance.PrijaviInstruktor(instruktor);
            if (response.IsSuccess)
            {
                MessageBox.Show("Korisnicko ime i sifra su ispravni.");
                frmLogin.Visible = false;
                MainCoordinator.Instance.ShowFrmMain();

            }
            else
            {
                MessageBox.Show(">>>" + response.ExceptionMessage);
            }
        }
    }
}
