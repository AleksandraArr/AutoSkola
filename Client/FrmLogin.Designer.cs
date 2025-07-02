namespace Client
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelKorisnickoIme = new Label();
            labelSifra = new Label();
            btnLogin = new Button();
            txtKorisnickoIme = new TextBox();
            txtSifra = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelKorisnickoIme
            // 
            labelKorisnickoIme.AutoSize = true;
            labelKorisnickoIme.Location = new Point(120, 156);
            labelKorisnickoIme.Name = "labelKorisnickoIme";
            labelKorisnickoIme.Size = new Size(131, 25);
            labelKorisnickoIme.TabIndex = 0;
            labelKorisnickoIme.Text = "Korisničko ime:";
            // 
            // labelSifra
            // 
            labelSifra.AutoSize = true;
            labelSifra.Location = new Point(120, 236);
            labelSifra.Name = "labelSifra";
            labelSifra.Size = new Size(51, 25);
            labelSifra.TabIndex = 1;
            labelSifra.Text = "Šifra:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(309, 304);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(215, 52);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Prijavi se";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += buttonLogin_Click;
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(309, 156);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(215, 31);
            txtKorisnickoIme.TabIndex = 3;
            // 
            // txtSifra
            // 
            txtSifra.Location = new Point(309, 230);
            txtSifra.Name = "txtSifra";
            txtSifra.PasswordChar = '*';
            txtSifra.Size = new Size(215, 31);
            txtSifra.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(120, 59);
            label1.Name = "label1";
            label1.Size = new Size(211, 51);
            label1.TabIndex = 5;
            label1.Text = "Auto škola";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 446);
            Controls.Add(label1);
            Controls.Add(txtSifra);
            Controls.Add(txtKorisnickoIme);
            Controls.Add(btnLogin);
            Controls.Add(labelSifra);
            Controls.Add(labelKorisnickoIme);
            Name = "FrmLogin";
            Text = "Prijava";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelKorisnickoIme;
        private Label labelSifra;
        private Button btnLogin;
        private TextBox txtKorisnickoIme;
        private TextBox txtSifra;
        private Label label1;

        public Button BtnLogin { get => btnLogin; set => btnLogin = value; }
        public Label LabelSifra { get => labelSifra; set => labelSifra = value; }
        public Label LabelKorisnickoIme { get => labelKorisnickoIme; set => labelKorisnickoIme = value; }
        public TextBox TxtKorisnickoIme { get => txtKorisnickoIme; set => txtKorisnickoIme = value; }
        public TextBox TxtSifra { get => txtSifra; set => txtSifra = value; }
    }
}
