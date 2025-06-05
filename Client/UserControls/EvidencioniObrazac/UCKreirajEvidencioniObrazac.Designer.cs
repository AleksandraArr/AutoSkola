namespace Client.UserControls.EvidencioniObrazac
{
    partial class UCKreirajEvidencioniObrazac
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
            cmbPolaznik = new ComboBox();
            cmbInstruktor = new ComboBox();
            dtpDatumPocetka = new DateTimePicker();
            txtBrCasova = new TextBox();
            lblBrCasova = new Label();
            lblDatumPocetka = new Label();
            lblPolaznik = new Label();
            lblInstruktor = new Label();
            label5 = new Label();
            btnKreiraj = new Button();
            btnUbaci = new Button();
            SuspendLayout();
            // 
            // cmbPolaznik
            // 
            cmbPolaznik.Enabled = false;
            cmbPolaznik.FormattingEnabled = true;
            cmbPolaznik.Location = new Point(210, 208);
            cmbPolaznik.Name = "cmbPolaznik";
            cmbPolaznik.Size = new Size(300, 33);
            cmbPolaznik.TabIndex = 10;
            // 
            // cmbInstruktor
            // 
            cmbInstruktor.Enabled = false;
            cmbInstruktor.FormattingEnabled = true;
            cmbInstruktor.Location = new Point(210, 159);
            cmbInstruktor.Name = "cmbInstruktor";
            cmbInstruktor.Size = new Size(300, 33);
            cmbInstruktor.TabIndex = 9;
            // 
            // dtpDatumPocetka
            // 
            dtpDatumPocetka.Enabled = false;
            dtpDatumPocetka.Location = new Point(210, 277);
            dtpDatumPocetka.Name = "dtpDatumPocetka";
            dtpDatumPocetka.Size = new Size(300, 31);
            dtpDatumPocetka.TabIndex = 8;
            // 
            // txtBrCasova
            // 
            txtBrCasova.Enabled = false;
            txtBrCasova.Location = new Point(210, 337);
            txtBrCasova.Name = "txtBrCasova";
            txtBrCasova.Size = new Size(300, 31);
            txtBrCasova.TabIndex = 7;
            // 
            // lblBrCasova
            // 
            lblBrCasova.AutoSize = true;
            lblBrCasova.Location = new Point(35, 337);
            lblBrCasova.Name = "lblBrCasova";
            lblBrCasova.Size = new Size(106, 25);
            lblBrCasova.TabIndex = 6;
            lblBrCasova.Text = "Broj casova:";
            // 
            // lblDatumPocetka
            // 
            lblDatumPocetka.AutoSize = true;
            lblDatumPocetka.Location = new Point(35, 277);
            lblDatumPocetka.Name = "lblDatumPocetka";
            lblDatumPocetka.Size = new Size(138, 25);
            lblDatumPocetka.TabIndex = 4;
            lblDatumPocetka.Text = "Datum pocetka:";
            // 
            // lblPolaznik
            // 
            lblPolaznik.AutoSize = true;
            lblPolaznik.Location = new Point(35, 217);
            lblPolaznik.Name = "lblPolaznik";
            lblPolaznik.Size = new Size(80, 25);
            lblPolaznik.TabIndex = 2;
            lblPolaznik.Text = "Polaznik:";
            // 
            // lblInstruktor
            // 
            lblInstruktor.AutoSize = true;
            lblInstruktor.Location = new Point(35, 157);
            lblInstruktor.Name = "lblInstruktor";
            lblInstruktor.Size = new Size(93, 25);
            lblInstruktor.TabIndex = 0;
            lblInstruktor.Text = "Instruktor:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(35, 27);
            label5.Name = "label5";
            label5.Size = new Size(320, 36);
            label5.TabIndex = 19;
            label5.Text = "Kreiraj evidencioni obrazac";
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(35, 85);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(475, 45);
            btnKreiraj.TabIndex = 18;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click;
            // 
            // btnUbaci
            // 
            btnUbaci.Enabled = false;
            btnUbaci.Location = new Point(211, 407);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(299, 45);
            btnUbaci.TabIndex = 17;
            btnUbaci.Text = "Zapamti";
            btnUbaci.UseVisualStyleBackColor = true;
            btnUbaci.Click += btnUbaci_Click;
            // 
            // UCKreirajEvidencioniObrazac
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(btnKreiraj);
            Controls.Add(btnUbaci);
            Controls.Add(cmbPolaznik);
            Controls.Add(cmbInstruktor);
            Controls.Add(dtpDatumPocetka);
            Controls.Add(lblInstruktor);
            Controls.Add(txtBrCasova);
            Controls.Add(lblPolaznik);
            Controls.Add(lblBrCasova);
            Controls.Add(lblDatumPocetka);
            Name = "UCKreirajEvidencioniObrazac";
            Size = new Size(560, 500);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbPolaznik;
        private ComboBox cmbInstruktor;
        private DateTimePicker dtpDatumPocetka;
        private TextBox txtBrCasova;
        private Label lblBrCasova;
        private Label lblDatumPocetka;
        private Label lblPolaznik;
        private Label lblInstruktor;
        private Label label5;
        private Button btnKreiraj;
        private Button btnUbaci;

        public DateTimePicker DtpDatumPocetka { get => dtpDatumPocetka; set => dtpDatumPocetka = value; }
        public TextBox TxtBrCasova { get => txtBrCasova; set => txtBrCasova = value; }
        public ComboBox CmbPolaznik { get => cmbPolaznik; set => cmbPolaznik = value; }
        public ComboBox CmbInstruktor { get => cmbInstruktor; set => cmbInstruktor = value; }
        public Button BtnUbaci { get => btnUbaci; set => btnUbaci = value; }
        public Button BtnKreiraj { get => btnKreiraj; set => btnKreiraj = value; }
    }
}
