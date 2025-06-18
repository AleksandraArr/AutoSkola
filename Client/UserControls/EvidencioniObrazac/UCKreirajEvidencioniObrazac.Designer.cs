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
            groupBox1 = new GroupBox();
            btnDodajCas = new Button();
            dgvCasovi = new DataGridView();
            cmbAutomobil = new ComboBox();
            label3 = new Label();
            dtpDatum = new DateTimePicker();
            label2 = new Label();
            txtTrajanje = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCasovi).BeginInit();
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
            dtpDatumPocetka.Location = new Point(211, 261);
            dtpDatumPocetka.Name = "dtpDatumPocetka";
            dtpDatumPocetka.Size = new Size(300, 31);
            dtpDatumPocetka.TabIndex = 8;
            // 
            // txtBrCasova
            // 
            txtBrCasova.Enabled = false;
            txtBrCasova.Location = new Point(210, 311);
            txtBrCasova.Name = "txtBrCasova";
            txtBrCasova.Size = new Size(300, 31);
            txtBrCasova.TabIndex = 7;
            // 
            // lblBrCasova
            // 
            lblBrCasova.AutoSize = true;
            lblBrCasova.Location = new Point(35, 317);
            lblBrCasova.Name = "lblBrCasova";
            lblBrCasova.Size = new Size(106, 25);
            lblBrCasova.TabIndex = 6;
            lblBrCasova.Text = "Broj casova:";
            // 
            // lblDatumPocetka
            // 
            lblDatumPocetka.AutoSize = true;
            lblDatumPocetka.Location = new Point(35, 267);
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
            btnUbaci.Location = new Point(227, 871);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(299, 45);
            btnUbaci.TabIndex = 17;
            btnUbaci.Text = "Zapamti";
            btnUbaci.UseVisualStyleBackColor = true;
            btnUbaci.Click += btnUbaci_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDodajCas);
            groupBox1.Controls.Add(dgvCasovi);
            groupBox1.Controls.Add(cmbAutomobil);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTrajanje);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(35, 359);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(491, 494);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Casovi";
            // 
            // btnDodajCas
            // 
            btnDodajCas.Enabled = false;
            btnDodajCas.Location = new Point(175, 194);
            btnDodajCas.Name = "btnDodajCas";
            btnDodajCas.Size = new Size(299, 45);
            btnDodajCas.TabIndex = 18;
            btnDodajCas.Text = "Dodaj cas";
            btnDodajCas.UseVisualStyleBackColor = true;
            btnDodajCas.Click += btnDodajCas_Click;
            // 
            // dgvCasovi
            // 
            dgvCasovi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCasovi.Location = new Point(22, 259);
            dgvCasovi.Name = "dgvCasovi";
            dgvCasovi.RowHeadersWidth = 62;
            dgvCasovi.Size = new Size(454, 209);
            dgvCasovi.TabIndex = 13;
            // 
            // cmbAutomobil
            // 
            cmbAutomobil.Enabled = false;
            cmbAutomobil.FormattingEnabled = true;
            cmbAutomobil.Location = new Point(176, 146);
            cmbAutomobil.Name = "cmbAutomobil";
            cmbAutomobil.Size = new Size(300, 33);
            cmbAutomobil.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 154);
            label3.Name = "label3";
            label3.Size = new Size(101, 25);
            label3.TabIndex = 11;
            label3.Text = "Automobil:";
            // 
            // dtpDatum
            // 
            dtpDatum.Enabled = false;
            dtpDatum.Location = new Point(175, 93);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(300, 31);
            dtpDatum.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 99);
            label2.Name = "label2";
            label2.Size = new Size(109, 25);
            label2.TabIndex = 9;
            label2.Text = "Datum časa:";
            // 
            // txtTrajanje
            // 
            txtTrajanje.Enabled = false;
            txtTrajanje.Location = new Point(175, 43);
            txtTrajanje.Name = "txtTrajanje";
            txtTrajanje.Size = new Size(300, 31);
            txtTrajanje.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 49);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 7;
            label1.Text = "Trajanje:";
            // 
            // UCKreirajEvidencioniObrazac
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
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
            Size = new Size(578, 941);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCasovi).EndInit();
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
        private GroupBox groupBox1;
        private DataGridView dgvCasovi;
        private ComboBox cmbAutomobil;
        private Label label3;
        private DateTimePicker dtpDatum;
        private Label label2;
        private TextBox txtTrajanje;
        private Label label1;
        private Button btnDodajCas;


        public DataGridView DgvCasovi { get => dgvCasovi; set => dgvCasovi = value; }
        public DateTimePicker DtpDatumPocetka { get => dtpDatumPocetka; set => dtpDatumPocetka = value; }
        public DateTimePicker DtpDatum { get => dtpDatum; set => dtpDatum = value; }
        public TextBox TxtBrCasova { get => txtBrCasova; set => txtBrCasova = value; }
        public TextBox TxtTrajanje { get => txtTrajanje; set => txtTrajanje = value; }
        public ComboBox CmbPolaznik { get => cmbPolaznik; set => cmbPolaznik = value; }
        public ComboBox CmbInstruktor { get => cmbInstruktor; set => cmbInstruktor = value; }
        public ComboBox CmbAutomobil { get => cmbAutomobil; set => cmbAutomobil = value; }
        public Button BtnUbaci { get => btnUbaci; set => btnUbaci = value; }
        public Button BtnKreiraj { get => btnKreiraj; set => btnKreiraj = value; }
        public Button BtnDodajCas { get => btnDodajCas; set => btnDodajCas = value; }
    }
}
