namespace Client
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            menuStrip1 = new MenuStrip();
            evidencioniObrazacMenuItem = new ToolStripMenuItem();
            kategorijaVozackeToolStripMenuItem = new ToolStripMenuItem();
            polazniciToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Location = new Point(1, 33);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1387, 824);
            pnlMain.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { evidencioniObrazacMenuItem, kategorijaVozackeToolStripMenuItem, polazniciToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1390, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // evidencioniObrazacMenuItem
            // 
            evidencioniObrazacMenuItem.Name = "evidencioniObrazacMenuItem";
            evidencioniObrazacMenuItem.Size = new Size(179, 29);
            evidencioniObrazacMenuItem.Text = "Evidencioni obrasci";
            evidencioniObrazacMenuItem.Click += evidencioniObrazacMenuItem_Click;
            // 
            // kategorijaVozackeToolStripMenuItem
            // 
            kategorijaVozackeToolStripMenuItem.Name = "kategorijaVozackeToolStripMenuItem";
            kategorijaVozackeToolStripMenuItem.Size = new Size(176, 29);
            kategorijaVozackeToolStripMenuItem.Text = "Kategorija Vozacke";
            kategorijaVozackeToolStripMenuItem.Click += kategorijaVozackeToolStripMenuItem_Click;
            // 
            // polazniciToolStripMenuItem
            // 
            polazniciToolStripMenuItem.Name = "polazniciToolStripMenuItem";
            polazniciToolStripMenuItem.Size = new Size(95, 29);
            polazniciToolStripMenuItem.Text = "Polaznici";
            polazniciToolStripMenuItem.Click += polazniciToolStripMenuItem_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 768);
            Controls.Add(pnlMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "Evidencioni obrasci";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMain;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem kategorijaVozackeToolStripMenuItem;
        private ToolStripMenuItem polazniciToolStripMenuItem;
        private ToolStripMenuItem evidencioniObrazacMenuItem;
    }
}