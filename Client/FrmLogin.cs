using Client.GuiController;

namespace Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            btnLogin.Click += LoginController.Instance.Login;
            txtKorisnickoIme.Text = "jovan.jovanovic";
            txtSifra.Text = "Test123!";

        }
        public bool Validacija()
        {
            txtKorisnickoIme.BackColor = Color.White;
            txtKorisnickoIme.BackColor = Color.White;
            bool isValid = true;
            if (string.IsNullOrEmpty(txtKorisnickoIme.Text))
            {
                txtKorisnickoIme.BackColor = Color.Salmon;
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtSifra.Text))
            {
                txtSifra.BackColor = Color.Salmon;
                isValid = false;
            }
            return isValid;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
