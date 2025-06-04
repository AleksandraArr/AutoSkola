namespace Client.UserControls.Polaznik
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
            btnUbaci = new Button();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtTelefon = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // btnUbaci
            // 
            btnUbaci.Location = new Point(220, 320);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(299, 40);
            btnUbaci.TabIndex = 9;
            btnUbaci.Text = "Ubaci";
            btnUbaci.UseVisualStyleBackColor = true;
            btnUbaci.Click += btnUbaci_Click;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(220, 130);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(300, 31);
            txtPrezime.TabIndex = 8;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(220, 70);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(300, 31);
            txtIme.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 130);
            label2.Name = "label2";
            label2.Size = new Size(158, 25);
            label2.TabIndex = 6;
            label2.Text = "Prezime polaznika:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 70);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 5;
            label1.Text = "Ime polaznika:";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(220, 250);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(300, 31);
            txtTelefon.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 250);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 11;
            label3.Text = "Broj telefona:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 190);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 10;
            label4.Text = "Ime polaznika:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(220, 190);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(299, 31);
            dateTimePicker1.TabIndex = 14;
            // 
            // UCKreirajPolaznik
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dateTimePicker1);
            Controls.Add(txtTelefon);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(btnUbaci);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCKreirajPolaznik";
            Size = new Size(556, 459);
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
        private DateTimePicker dateTimePicker1;
    }
}
