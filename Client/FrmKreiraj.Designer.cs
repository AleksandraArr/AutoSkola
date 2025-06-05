namespace Client
{
    partial class FrmKreiraj
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
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Location = new Point(2, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(560, 500);
            pnlMain.TabIndex = 0;
            // 
            // FrmKreiraj
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 502);
            Controls.Add(pnlMain);
            Name = "FrmKreiraj";
            Text = "FrmKreiraj";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
    }
}