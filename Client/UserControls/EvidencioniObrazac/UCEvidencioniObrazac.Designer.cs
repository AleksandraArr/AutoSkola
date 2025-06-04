using System.Windows.Forms;

namespace Client.UserControls.EvidencioniObrazac
{
    partial class UCEvidencioniObrazac
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
            label2 = new Label();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            gbPodaciObrazca = new GroupBox();
            cmbPolaznik = new ComboBox();
            cmbInstruktor = new ComboBox();
            dtpDatumPocetka = new DateTimePicker();
            txtBrCasova = new TextBox();
            lblBrCasova = new Label();
            lblDatumPocetka = new Label();
            lblPolaznik = new Label();
            lblInstruktor = new Label();
            btnPrikaziObrasce = new Button();
            dgvEvidencioniObrasci = new DataGridView();
            label1 = new Label();
            gpbKriterijumi = new GroupBox();
            btnExit = new Button();
            btnPretrazi = new Button();
            cmbAutomobilKriterijum = new ComboBox();
            cmbPolaznikKriterijum = new ComboBox();
            cmbInstruktorKriterijum = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnKriterijumi = new Button();
            btnUkloniKriterijume = new Button();
            gbPodaciObrazca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvidencioniObrasci).BeginInit();
            gpbKriterijumi.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 86);
            label2.Name = "label2";
            label2.Size = new Size(209, 25);
            label2.TabIndex = 23;
            label2.Text = "Pretraži po kriterijumima:";
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(679, 306);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(166, 45);
            btnIzmeni.TabIndex = 22;
            btnIzmeni.Text = "Izmeni obrazac";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(889, 306);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(166, 45);
            btnObrisi.TabIndex = 21;
            btnObrisi.Text = "Obriši obrazac";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // gbPodaciObrazca
            // 
            gbPodaciObrazca.Controls.Add(cmbPolaznik);
            gbPodaciObrazca.Controls.Add(cmbInstruktor);
            gbPodaciObrazca.Controls.Add(dtpDatumPocetka);
            gbPodaciObrazca.Controls.Add(txtBrCasova);
            gbPodaciObrazca.Controls.Add(lblBrCasova);
            gbPodaciObrazca.Controls.Add(lblDatumPocetka);
            gbPodaciObrazca.Controls.Add(lblPolaznik);
            gbPodaciObrazca.Controls.Add(lblInstruktor);
            gbPodaciObrazca.Location = new Point(587, 37);
            gbPodaciObrazca.Name = "gbPodaciObrazca";
            gbPodaciObrazca.Size = new Size(519, 252);
            gbPodaciObrazca.TabIndex = 19;
            gbPodaciObrazca.TabStop = false;
            gbPodaciObrazca.Text = "Podaci evidencionog obrasca";
            // 
            // cmbPolaznik
            // 
            cmbPolaznik.FormattingEnabled = true;
            cmbPolaznik.Location = new Point(185, 90);
            cmbPolaznik.Name = "cmbPolaznik";
            cmbPolaznik.Size = new Size(309, 33);
            cmbPolaznik.TabIndex = 10;
            // 
            // cmbInstruktor
            // 
            cmbInstruktor.FormattingEnabled = true;
            cmbInstruktor.Location = new Point(185, 41);
            cmbInstruktor.Name = "cmbInstruktor";
            cmbInstruktor.Size = new Size(309, 33);
            cmbInstruktor.TabIndex = 9;
            // 
            // dtpDatumPocetka
            // 
            dtpDatumPocetka.Location = new Point(185, 146);
            dtpDatumPocetka.Name = "dtpDatumPocetka";
            dtpDatumPocetka.Size = new Size(309, 31);
            dtpDatumPocetka.TabIndex = 8;
            // 
            // txtBrCasova
            // 
            txtBrCasova.Location = new Point(185, 191);
            txtBrCasova.Name = "txtBrCasova";
            txtBrCasova.Size = new Size(309, 31);
            txtBrCasova.TabIndex = 7;
            // 
            // lblBrCasova
            // 
            lblBrCasova.AutoSize = true;
            lblBrCasova.Location = new Point(29, 194);
            lblBrCasova.Name = "lblBrCasova";
            lblBrCasova.Size = new Size(106, 25);
            lblBrCasova.TabIndex = 6;
            lblBrCasova.Text = "Broj casova:";
            // 
            // lblDatumPocetka
            // 
            lblDatumPocetka.AutoSize = true;
            lblDatumPocetka.Location = new Point(29, 146);
            lblDatumPocetka.Name = "lblDatumPocetka";
            lblDatumPocetka.Size = new Size(138, 25);
            lblDatumPocetka.TabIndex = 4;
            lblDatumPocetka.Text = "Datum pocetka:";
            // 
            // lblPolaznik
            // 
            lblPolaznik.AutoSize = true;
            lblPolaznik.Location = new Point(29, 99);
            lblPolaznik.Name = "lblPolaznik";
            lblPolaznik.Size = new Size(80, 25);
            lblPolaznik.TabIndex = 2;
            lblPolaznik.Text = "Polaznik:";
            // 
            // lblInstruktor
            // 
            lblInstruktor.AutoSize = true;
            lblInstruktor.Location = new Point(29, 52);
            lblInstruktor.Name = "lblInstruktor";
            lblInstruktor.Size = new Size(93, 25);
            lblInstruktor.TabIndex = 0;
            lblInstruktor.Text = "Instruktor:";
            // 
            // btnPrikaziObrasce
            // 
            btnPrikaziObrasce.ForeColor = SystemColors.ControlText;
            btnPrikaziObrasce.Location = new Point(32, 173);
            btnPrikaziObrasce.Name = "btnPrikaziObrasce";
            btnPrikaziObrasce.Size = new Size(528, 45);
            btnPrikaziObrasce.TabIndex = 18;
            btnPrikaziObrasce.Text = "Prikaži sve obrasce";
            btnPrikaziObrasce.UseVisualStyleBackColor = true;
            btnPrikaziObrasce.Click += btnPrikaziObrasce_Click;
            // 
            // dgvEvidencioniObrasci
            // 
            dgvEvidencioniObrasci.AllowUserToAddRows = false;
            dgvEvidencioniObrasci.AllowUserToDeleteRows = false;
            dgvEvidencioniObrasci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvidencioniObrasci.Location = new Point(32, 231);
            dgvEvidencioniObrasci.Name = "dgvEvidencioniObrasci";
            dgvEvidencioniObrasci.ReadOnly = true;
            dgvEvidencioniObrasci.RowHeadersWidth = 62;
            dgvEvidencioniObrasci.Size = new Size(528, 411);
            dgvEvidencioniObrasci.TabIndex = 17;
            dgvEvidencioniObrasci.SelectionChanged += dgvEvidencioniObrasci_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(32, 37);
            label1.Name = "label1";
            label1.Size = new Size(272, 41);
            label1.TabIndex = 16;
            label1.Text = "Evidencioni obrazci";
            // 
            // gpbKriterijumi
            // 
            gpbKriterijumi.Controls.Add(btnUkloniKriterijume);
            gpbKriterijumi.Controls.Add(btnExit);
            gpbKriterijumi.Controls.Add(btnPretrazi);
            gpbKriterijumi.Controls.Add(cmbAutomobilKriterijum);
            gpbKriterijumi.Controls.Add(cmbPolaznikKriterijum);
            gpbKriterijumi.Controls.Add(cmbInstruktorKriterijum);
            gpbKriterijumi.Controls.Add(label3);
            gpbKriterijumi.Controls.Add(label5);
            gpbKriterijumi.Controls.Add(label6);
            gpbKriterijumi.Location = new Point(247, 81);
            gpbKriterijumi.Name = "gpbKriterijumi";
            gpbKriterijumi.Size = new Size(530, 295);
            gpbKriterijumi.TabIndex = 24;
            gpbKriterijumi.TabStop = false;
            gpbKriterijumi.Text = "Kriterijumi evidencionog obrasca";
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.ControlLight;
            btnExit.Location = new Point(488, 20);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(31, 40);
            btnExit.TabIndex = 13;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(290, 225);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(216, 45);
            btnPretrazi.TabIndex = 12;
            btnPretrazi.Text = "Pretraži po kriterijumima";
            btnPretrazi.UseVisualStyleBackColor = true;
            btnPretrazi.Click += btnPretrazi_Click;
            // 
            // cmbAutomobilKriterijum
            // 
            cmbAutomobilKriterijum.FormattingEnabled = true;
            cmbAutomobilKriterijum.Location = new Point(197, 167);
            cmbAutomobilKriterijum.Name = "cmbAutomobilKriterijum";
            cmbAutomobilKriterijum.Size = new Size(309, 33);
            cmbAutomobilKriterijum.TabIndex = 11;
            // 
            // cmbPolaznikKriterijum
            // 
            cmbPolaznikKriterijum.FormattingEnabled = true;
            cmbPolaznikKriterijum.Location = new Point(197, 115);
            cmbPolaznikKriterijum.Name = "cmbPolaznikKriterijum";
            cmbPolaznikKriterijum.Size = new Size(309, 33);
            cmbPolaznikKriterijum.TabIndex = 10;
            // 
            // cmbInstruktorKriterijum
            // 
            cmbInstruktorKriterijum.FormattingEnabled = true;
            cmbInstruktorKriterijum.Location = new Point(197, 66);
            cmbInstruktorKriterijum.Name = "cmbInstruktorKriterijum";
            cmbInstruktorKriterijum.Size = new Size(309, 33);
            cmbInstruktorKriterijum.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 175);
            label3.Name = "label3";
            label3.Size = new Size(101, 25);
            label3.TabIndex = 6;
            label3.Text = "Automobil:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 124);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 2;
            label5.Text = "Polaznik:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 77);
            label6.Name = "label6";
            label6.Size = new Size(93, 25);
            label6.TabIndex = 0;
            label6.Text = "Instruktor:";
            // 
            // btnKriterijumi
            // 
            btnKriterijumi.Location = new Point(247, 81);
            btnKriterijumi.Name = "btnKriterijumi";
            btnKriterijumi.Size = new Size(202, 45);
            btnKriterijumi.TabIndex = 25;
            btnKriterijumi.Text = "Izaberi kriterijume";
            btnKriterijumi.UseVisualStyleBackColor = true;
            btnKriterijumi.Click += btnKriterijumi_Click;
            // 
            // btnUkloniKriterijume
            // 
            btnUkloniKriterijume.Location = new Point(41, 225);
            btnUkloniKriterijume.Name = "btnUkloniKriterijume";
            btnUkloniKriterijume.Size = new Size(216, 45);
            btnUkloniKriterijume.TabIndex = 14;
            btnUkloniKriterijume.Text = "Ukloni kriterijume";
            btnUkloniKriterijume.UseVisualStyleBackColor = true;
            btnUkloniKriterijume.Click += btnUkloniKriterijume_Click;
            // 
            // UCEvidencioniObrazac
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gpbKriterijumi);
            Controls.Add(btnKriterijumi);
            Controls.Add(btnIzmeni);
            Controls.Add(btnObrisi);
            Controls.Add(gbPodaciObrazca);
            Controls.Add(btnPrikaziObrasce);
            Controls.Add(dgvEvidencioniObrasci);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "UCEvidencioniObrazac";
            Size = new Size(1551, 945);
            Load += UCEvidencioniObrazac_Load;
            gbPodaciObrazca.ResumeLayout(false);
            gbPodaciObrazca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvidencioniObrasci).EndInit();
            gpbKriterijumi.ResumeLayout(false);
            gpbKriterijumi.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnIzmeni;
        private Button btnObrisi;
        private GroupBox gbPodaciObrazca;
        private DateTimePicker dtpDatumPocetka;
        private TextBox txtBrCasova;
        private Label lblDatumRodjenja;
        private TextBox txtIme;
        private Label lblInstruktor;
        private Button btnPrikaziObrasce;
        private DataGridView dgvEvidencioniObrasci;
        private Label label1;
        private Label label2;
        private ComboBox cmbPolaznik;
        private ComboBox cmbInstruktor;
        private Label lblPolaznik;
        private Label lblDatumPocetka;
        private Label lblBrCasova;
        private GroupBox gpbKriterijumi;
        private ComboBox cmbAutomobilKriterijum;
        private ComboBox cmbPolaznikKriterijum;
        private ComboBox cmbInstruktorKriterijum;
        private Label label3;
        private Label label5;
        private Label label6;
        private Button btnKriterijumi;
        private Button btnPretrazi;
        private Button btnExit;
        private Button btnUkloniKriterijume;

        public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
        public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
        public GroupBox GbPodaciObrazca { get => gbPodaciObrazca; set => gbPodaciObrazca = value; }
        public DateTimePicker DateTimePickerDatumRodjenja { get => dtpDatumPocetka; set => dtpDatumPocetka = value; }
        public TextBox TxtBrCasova { get => txtBrCasova; set => txtBrCasova = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public Button BtnPrikaziPolaznike { get => btnPrikaziObrasce; set => btnPrikaziObrasce = value; }
        public DataGridView DgvEvidencioniObrasci { get => dgvEvidencioniObrasci; set => dgvEvidencioniObrasci = value; }
        public ComboBox CmbPolaznik { get => cmbPolaznik; set => cmbPolaznik = value; }
        public ComboBox CmbInstruktor { get => cmbInstruktor; set => cmbInstruktor = value; }
        public ComboBox CmbPolaznikKriterijum { get => cmbPolaznikKriterijum; set => cmbPolaznikKriterijum = value; }
        public ComboBox CmbInstruktorKriterijum { get => cmbInstruktorKriterijum; set => cmbInstruktorKriterijum = value; }
        public ComboBox CmbAutomobilKriterijum { get => cmbAutomobilKriterijum; set => cmbAutomobilKriterijum = value; }

    }
}
