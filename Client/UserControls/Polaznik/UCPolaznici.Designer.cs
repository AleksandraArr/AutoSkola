namespace Client.UserControls.Polaznik
{
    partial class UCPolaznici
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
            label1 = new Label();
            dgvPolaznici = new DataGridView();
            btnPrikaziPolaznike = new Button();
            gbPodaciPolaznika = new GroupBox();
            dtpDatumRodjenja = new DateTimePicker();
            txtKontaktTelefon = new TextBox();
            lblKontaktTelefon = new Label();
            lblDatumRodjenja = new Label();
            txtPrezime = new TextBox();
            lblPrezime = new Label();
            txtIme = new TextBox();
            lblIme = new Label();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            label2 = new Label();
            txtImeIPrezime = new TextBox();
            btnPretrazi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPolaznici).BeginInit();
            gbPodaciPolaznika.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(28, 26);
            label1.Name = "label1";
            label1.Size = new Size(133, 41);
            label1.TabIndex = 0;
            label1.Text = "Polaznici";
            // 
            // dgvPolaznici
            // 
            dgvPolaznici.AllowUserToAddRows = false;
            dgvPolaznici.AllowUserToDeleteRows = false;
            dgvPolaznici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPolaznici.Location = new Point(28, 220);
            dgvPolaznici.Name = "dgvPolaznici";
            dgvPolaznici.ReadOnly = true;
            dgvPolaznici.RowHeadersWidth = 62;
            dgvPolaznici.Size = new Size(528, 411);
            dgvPolaznici.TabIndex = 2;
            dgvPolaznici.SelectionChanged += dgvPolaznici_SelectionChanged;
            // 
            // btnPrikaziPolaznike
            // 
            btnPrikaziPolaznike.ForeColor = SystemColors.ControlText;
            btnPrikaziPolaznike.Location = new Point(28, 168);
            btnPrikaziPolaznike.Name = "btnPrikaziPolaznike";
            btnPrikaziPolaznike.Size = new Size(528, 45);
            btnPrikaziPolaznike.TabIndex = 6;
            btnPrikaziPolaznike.Text = "Prikaži sve polaznike";
            btnPrikaziPolaznike.UseVisualStyleBackColor = true;
            btnPrikaziPolaznike.Click += btnPrikaziPolaznike_Click;
            // 
            // gbPodaciPolaznika
            // 
            gbPodaciPolaznika.Controls.Add(dtpDatumRodjenja);
            gbPodaciPolaznika.Controls.Add(txtKontaktTelefon);
            gbPodaciPolaznika.Controls.Add(lblKontaktTelefon);
            gbPodaciPolaznika.Controls.Add(lblDatumRodjenja);
            gbPodaciPolaznika.Controls.Add(txtPrezime);
            gbPodaciPolaznika.Controls.Add(lblPrezime);
            gbPodaciPolaznika.Controls.Add(txtIme);
            gbPodaciPolaznika.Controls.Add(lblIme);
            gbPodaciPolaznika.Location = new Point(583, 26);
            gbPodaciPolaznika.Name = "gbPodaciPolaznika";
            gbPodaciPolaznika.Size = new Size(519, 252);
            gbPodaciPolaznika.TabIndex = 7;
            gbPodaciPolaznika.TabStop = false;
            gbPodaciPolaznika.Text = "Podaci polaznika";
            // 
            // dtpDatumRodjenja
            // 
            dtpDatumRodjenja.Location = new Point(185, 146);
            dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            dtpDatumRodjenja.Size = new Size(309, 31);
            dtpDatumRodjenja.TabIndex = 8;
            // 
            // txtKontaktTelefon
            // 
            txtKontaktTelefon.Location = new Point(185, 191);
            txtKontaktTelefon.Name = "txtKontaktTelefon";
            txtKontaktTelefon.Size = new Size(309, 31);
            txtKontaktTelefon.TabIndex = 7;
            // 
            // lblKontaktTelefon
            // 
            lblKontaktTelefon.AutoSize = true;
            lblKontaktTelefon.Location = new Point(29, 194);
            lblKontaktTelefon.Name = "lblKontaktTelefon";
            lblKontaktTelefon.Size = new Size(72, 25);
            lblKontaktTelefon.TabIndex = 6;
            lblKontaktTelefon.Text = "Telefon:";
            // 
            // lblDatumRodjenja
            // 
            lblDatumRodjenja.AutoSize = true;
            lblDatumRodjenja.Location = new Point(29, 146);
            lblDatumRodjenja.Name = "lblDatumRodjenja";
            lblDatumRodjenja.Size = new Size(139, 25);
            lblDatumRodjenja.TabIndex = 4;
            lblDatumRodjenja.Text = "Datum rodjenja:";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(185, 96);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(309, 31);
            txtPrezime.TabIndex = 3;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Location = new Point(29, 99);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(78, 25);
            lblPrezime.TabIndex = 2;
            lblPrezime.Text = "Prezime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(185, 49);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(309, 31);
            txtIme.TabIndex = 1;
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Location = new Point(29, 52);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(46, 25);
            lblIme.TabIndex = 0;
            lblIme.Text = "Ime:";
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(665, 310);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(166, 45);
            btnIzmeni.TabIndex = 12;
            btnIzmeni.Text = "Izmeni polaznika";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(887, 310);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(166, 45);
            btnObrisi.TabIndex = 11;
            btnObrisi.Text = "Obriši polaznika";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 75);
            label2.Name = "label2";
            label2.Size = new Size(252, 25);
            label2.TabIndex = 13;
            label2.Text = "Pretraži po imenu i prezimenu:";
            // 
            // txtImeIPrezime
            // 
            txtImeIPrezime.Location = new Point(278, 69);
            txtImeIPrezime.Name = "txtImeIPrezime";
            txtImeIPrezime.Size = new Size(278, 31);
            txtImeIPrezime.TabIndex = 14;
            txtImeIPrezime.TextChanged += txtImeIPrezime_TextChanged;
            // 
            // btnPretrazi
            // 
            btnPretrazi.ForeColor = SystemColors.ControlText;
            btnPretrazi.Location = new Point(278, 116);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(278, 45);
            btnPretrazi.TabIndex = 15;
            btnPretrazi.Text = "Pretraži";
            btnPretrazi.UseVisualStyleBackColor = true;
            btnPretrazi.Click += btnPretrazi_Click;
            // 
            // UCPolaznici
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPretrazi);
            Controls.Add(txtImeIPrezime);
            Controls.Add(label2);
            Controls.Add(btnIzmeni);
            Controls.Add(btnObrisi);
            Controls.Add(gbPodaciPolaznika);
            Controls.Add(btnPrikaziPolaznike);
            Controls.Add(dgvPolaznici);
            Controls.Add(label1);
            Name = "UCPolaznici";
            Size = new Size(1105, 674);
            ((System.ComponentModel.ISupportInitialize)dgvPolaznici).EndInit();
            gbPodaciPolaznika.ResumeLayout(false);
            gbPodaciPolaznika.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvPolaznici;
        private Button btnPrikaziPolaznike;
        private GroupBox gbPodaciPolaznika;
        private TextBox txtKontaktTelefon;
        private Label lblKontaktTelefon;
        private Label lblDatumRodjenja;
        private TextBox txtPrezime;
        private Label lblPrezime;
        private TextBox txtIme;
        private Label lblIme;
        private Button btnIzmeni;
        private Button btnObrisi;
        private DateTimePicker dtpDatumRodjenja;
        private Label label2;
        private TextBox txtImeIPrezime;
        private Button btnPretrazi;

        public DataGridView DgvPolaznici { get => dgvPolaznici; set => dgvPolaznici = value; }
        public TextBox TxtKontaktTelefon { get => txtKontaktTelefon; set => txtKontaktTelefon = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public TextBox TxtImeIPrezime { get => txtImeIPrezime; set => txtImeIPrezime = value; }
        public DateTimePicker DateTimePicker1 { get => dtpDatumRodjenja; set => dtpDatumRodjenja = value; }

    }
}
