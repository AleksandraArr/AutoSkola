namespace Server
{
    partial class FrmServer
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
            btnStart = new Button();
            btnStop = new Button();
            txtServer = new TextBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(120, 93);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(131, 46);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(120, 179);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(131, 44);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtServer
            // 
            txtServer.Enabled = false;
            txtServer.Location = new Point(333, 143);
            txtServer.Margin = new Padding(3, 4, 3, 4);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(244, 31);
            txtServer.TabIndex = 3;
            txtServer.Text = "Server nije pokrenut!";
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtServer);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "FrmServer";
            Text = "Server";
            FormClosed += FrmServer_FormClosed;
            Load += FrmServer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private TextBox txtServer;
    }
}
