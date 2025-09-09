namespace ShareX
{
    partial class AboutForm
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

            if (easterEgg != null) easterEgg.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.rtbInfo = new ShareX.HelpersLib.ReadOnlyRichTextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cLogo = new ShareX.HelpersLib.Canvas();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbInfo
            // 
            resources.ApplyResources(this.rtbInfo, "rtbInfo");
            this.rtbInfo.BackColor = System.Drawing.SystemColors.Window;
            this.rtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtb_LinkClicked);
            // 
            // pbLogo
            // 
            resources.ApplyResources(this.pbLogo, "pbLogo");
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.TabStop = false;
            this.pbLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLogo_MouseDown);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cLogo
            // 
            resources.ApplyResources(this.cLogo, "cLogo");
            this.cLogo.Interval = 100;
            this.cLogo.Name = "cLogo";
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.cLogo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbInfo);
            this.Name = "AboutForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Shown += new System.EventHandler(this.AboutForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code
        private HelpersLib.Canvas cLogo;
        private HelpersLib.ReadOnlyRichTextBox rtbInfo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnClose;
    }
}