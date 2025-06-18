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
            catch (SocketException ex) when (ex.SocketErrorCode == SocketError.ConnectionRefused)
            {
                MessageBox.Show(
                    "Neuspešno povezivanje sa serverom.\nProverite da li je server pokrenut.",
                    "Server nije dostupan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Login(object sender, EventArgs e)
        {
            if (!frmLogin.Validacija())
                return;

            Instruktor instruktor = new Instruktor
            {
                KorisnickoIme = frmLogin.TxtKorisnickoIme.Text,
                Sifra = frmLogin.TxtSifra.Text,
            };
            Response response = Communication.Instance.PrijaviInstruktor(instruktor);
            if (response.IsSuccess)
            {
                MessageBox.Show("Korisničko ime i šifra su ispravni.", "Prijava", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLogin.Visible = false;
                MainCoordinator.Instance.ShowFrmMain();
            }
            else
                MessageBox.Show("Korisničko ime i šifra nisu ispravni.", "Prijava", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
