namespace Client.UserControls.Polaznik
{
    partial class UCKreirajPolaznik
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUbaci = new Button();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtTelefon = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dtpDatumRodjenja = new DateTimePicker();
            btnKreiraj = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnUbaci
            // 
            btnUbaci.Enabled = false;
            btnUbaci.Location = new Point(210, 407);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(299, 45);
            btnUbaci.TabIndex = 9;
            btnUbaci.Text = "Zapamti";
            btnUbaci.UseVisualStyleBackColor = true;
            btnUbaci.Click += btnUbaci_Click;
            // 
            // txtPrezime
            // 
            txtPrezime.Enabled = false;
            txtPrezime.Location = new Point(210, 217);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(300, 31);
            txtPrezime.TabIndex = 8;
            // 
            // txtIme
            // 
            txtIme.Enabled = false;
            txtIme.Location = new Point(210, 157);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(300, 31);
            txtIme.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 217);
            label2.Name = "label2";
            label2.Size = new Size(158, 25);
            label2.TabIndex = 6;
            label2.Text = "Prezime polaznika:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 157);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 5;
            label1.Text = "Ime polaznika:";
            // 
            // txtTelefon
            // 
            txtTelefon.Enabled = false;
            txtTelefon.Location = new Point(210, 337);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(300, 31);
            txtTelefon.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 337);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 11;
            label3.Text = "Broj telefona:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 277);
            label4.Name = "label4";
            label4.Size = new Size(135, 25);
            label4.TabIndex = 10;
            label4.Text = "Datum rođenja:";
            // 
            // dtpDatumRodjenja
            // 
            dtpDatumRodjenja.Enabled = false;
            dtpDatumRodjenja.Location = new Point(210, 277);
            dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            dtpDatumRodjenja.Size = new Size(299, 31);
            dtpDatumRodjenja.TabIndex = 14;
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(35, 85);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(475, 45);
            btnKreiraj.TabIndex = 15;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(35, 27);
            label5.Name = "label5";
            label5.Size = new Size(201, 36);
            label5.TabIndex = 16;
            label5.Text = "Kreiraj Polaznika";
            // 
            // UCKreirajPolaznik
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(btnKreiraj);
            Controls.Add(dtpDatumRodjenja);
            Controls.Add(txtTelefon);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(btnUbaci);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCKreirajPolaznik";
            Size = new Size(560, 500);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUbaci;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private Label label2;
        private Label label1;
        private TextBox txtTelefon;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpDatumRodjenja;
        private Button btnKreiraj;
        private Label label5;
        public TextBox TxtKontaktTelefon { get => txtTelefon; set => txtTelefon = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public DateTimePicker DtpDatumRodjenja { get => dtpDatumRodjenja; set => dtpDatumRodjenja = value; }
        public Button BtnUbaci { get => btnUbaci; set => btnUbaci = value; }
        public Button BtnKreiraj { get => btnKreiraj; set => btnKreiraj = value; }
    }
}
