namespace Client.UserControls.Kategorija_vozacke
{
    partial class UCUbaciKategorijaVozacke
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
            label2 = new Label();
            txtKategorija = new TextBox();
            txtJacinaMotora = new TextBox();
            btnUbaci = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 104);
            label1.Name = "label1";
            label1.Size = new Size(142, 25);
            label1.TabIndex = 0;
            label1.Text = "Naziv kategorije:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 164);
            label2.Name = "label2";
            label2.Size = new Size(126, 25);
            label2.TabIndex = 1;
            label2.Text = "Jačina motora:";
            // 
            // txtKategorija
            // 
            txtKategorija.Location = new Point(221, 104);
            txtKategorija.Name = "txtKategorija";
            txtKategorija.Size = new Size(300, 31);
            txtKategorija.TabIndex = 2;
            // 
            // txtJacinaMotora
            // 
            txtJacinaMotora.Location = new Point(221, 164);
            txtJacinaMotora.Name = "txtJacinaMotora";
            txtJacinaMotora.Size = new Size(300, 31);
            txtJacinaMotora.TabIndex = 3;
            // 
            // btnUbaci
            // 
            btnUbaci.Location = new Point(221, 224);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(300, 40);
            btnUbaci.TabIndex = 4;
            btnUbaci.Text = "Ubaci";
            btnUbaci.UseVisualStyleBackColor = true;
            btnUbaci.Click += btnUbaci_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(46, 28);
            label5.Name = "label5";
            label5.Size = new Size(299, 36);
            label5.TabIndex = 20;
            label5.Text = "Ubaci kategoriju vozačke";
            // 
            // UCUbaciKategorijaVozacke
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(btnUbaci);
            Controls.Add(txtJacinaMotora);
            Controls.Add(txtKategorija);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCUbaciKategorijaVozacke";
            Size = new Size(607, 395);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtKategorija;
        private TextBox txtJacinaMotora;
        private Button btnUbaci;
        private Label label5;

        public TextBox TxtKategorija { get => txtKategorija; set => txtKategorija = value; }
        public TextBox TxtJacinaMotora { get => txtJacinaMotora; set => txtJacinaMotora = value; }
        public Button BtnUbaci { get => btnUbaci; set => btnUbaci = value; }

    }
}
