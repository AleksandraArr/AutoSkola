using Client.GuiController;

namespace Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtKorisnickoIme.Text = "jovan.jovanovic";
            txtSifra.Text = "Test123!";

        }
        public bool Validacija()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(txtKorisnickoIme.Text))
            {
                MessageBox.Show("Morate uneti korisnicko ime.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }
            if (string.IsNullOrEmpty(txtSifra.Text))
            {
                MessageBox.Show("Morate uneti sifru.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }
            return isValid;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (Validacija())
                LoginController.Instance.Login();
        }
    }
}
