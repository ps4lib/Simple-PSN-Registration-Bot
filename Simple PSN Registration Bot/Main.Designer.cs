namespace Simple_PSN_Registration_Bot
{
    partial class Main
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
            this.psnUsernameTextBox = new System.Windows.Forms.TextBox();
            this.psnPasswordTextBox = new System.Windows.Forms.TextBox();
            this.psnEmailTextBox = new System.Windows.Forms.TextBox();
            this.psnUsernameLabel = new System.Windows.Forms.Label();
            this.psnPasswordLabel = new System.Windows.Forms.Label();
            this.psnEmailLabel = new System.Windows.Forms.Label();
            this.psnCreateAccountButton = new System.Windows.Forms.Button();
            this.consoleOutputGroupBox = new System.Windows.Forms.GroupBox();
            this.consoleOutputTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.psnDOBTextBox = new System.Windows.Forms.MaskedTextBox();
            this.psnDOBLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.registerOnlineIdButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.recaptchaScriptLink = new System.Windows.Forms.LinkLabel();
            this.psnCaptchaLink = new System.Windows.Forms.LinkLabel();
            this.consoleOutputGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // psnUsernameTextBox
            // 
            this.psnUsernameTextBox.Location = new System.Drawing.Point(9, 32);
            this.psnUsernameTextBox.Name = "psnUsernameTextBox";
            this.psnUsernameTextBox.Size = new System.Drawing.Size(217, 20);
            this.psnUsernameTextBox.TabIndex = 0;
            // 
            // psnPasswordTextBox
            // 
            this.psnPasswordTextBox.Location = new System.Drawing.Point(9, 77);
            this.psnPasswordTextBox.Name = "psnPasswordTextBox";
            this.psnPasswordTextBox.Size = new System.Drawing.Size(217, 20);
            this.psnPasswordTextBox.TabIndex = 1;
            // 
            // psnEmailTextBox
            // 
            this.psnEmailTextBox.Location = new System.Drawing.Point(9, 117);
            this.psnEmailTextBox.Name = "psnEmailTextBox";
            this.psnEmailTextBox.Size = new System.Drawing.Size(217, 20);
            this.psnEmailTextBox.TabIndex = 2;
            // 
            // psnUsernameLabel
            // 
            this.psnUsernameLabel.AutoSize = true;
            this.psnUsernameLabel.Location = new System.Drawing.Point(6, 16);
            this.psnUsernameLabel.Name = "psnUsernameLabel";
            this.psnUsernameLabel.Size = new System.Drawing.Size(51, 13);
            this.psnUsernameLabel.TabIndex = 4;
            this.psnUsernameLabel.Text = "Online ID";
            // 
            // psnPasswordLabel
            // 
            this.psnPasswordLabel.AutoSize = true;
            this.psnPasswordLabel.Location = new System.Drawing.Point(6, 61);
            this.psnPasswordLabel.Name = "psnPasswordLabel";
            this.psnPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.psnPasswordLabel.TabIndex = 5;
            this.psnPasswordLabel.Text = "Password";
            // 
            // psnEmailLabel
            // 
            this.psnEmailLabel.AutoSize = true;
            this.psnEmailLabel.Location = new System.Drawing.Point(6, 101);
            this.psnEmailLabel.Name = "psnEmailLabel";
            this.psnEmailLabel.Size = new System.Drawing.Size(73, 13);
            this.psnEmailLabel.TabIndex = 6;
            this.psnEmailLabel.Text = "Email Address";
            // 
            // psnCreateAccountButton
            // 
            this.psnCreateAccountButton.Location = new System.Drawing.Point(12, 205);
            this.psnCreateAccountButton.Name = "psnCreateAccountButton";
            this.psnCreateAccountButton.Size = new System.Drawing.Size(251, 23);
            this.psnCreateAccountButton.TabIndex = 4;
            this.psnCreateAccountButton.Text = "Create PSN Account";
            this.psnCreateAccountButton.UseVisualStyleBackColor = true;
            this.psnCreateAccountButton.Click += new System.EventHandler(this.psnCreateAccountButton_Click);
            // 
            // consoleOutputGroupBox
            // 
            this.consoleOutputGroupBox.Controls.Add(this.consoleOutputTextBox);
            this.consoleOutputGroupBox.Location = new System.Drawing.Point(269, 12);
            this.consoleOutputGroupBox.Name = "consoleOutputGroupBox";
            this.consoleOutputGroupBox.Size = new System.Drawing.Size(387, 253);
            this.consoleOutputGroupBox.TabIndex = 9;
            this.consoleOutputGroupBox.TabStop = false;
            this.consoleOutputGroupBox.Text = "Console Output";
            // 
            // consoleOutputTextBox
            // 
            this.consoleOutputTextBox.BackColor = System.Drawing.Color.Black;
            this.consoleOutputTextBox.ForeColor = System.Drawing.Color.Lime;
            this.consoleOutputTextBox.Location = new System.Drawing.Point(7, 19);
            this.consoleOutputTextBox.Multiline = true;
            this.consoleOutputTextBox.Name = "consoleOutputTextBox";
            this.consoleOutputTextBox.ReadOnly = true;
            this.consoleOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleOutputTextBox.Size = new System.Drawing.Size(374, 228);
            this.consoleOutputTextBox.TabIndex = 0;
            this.consoleOutputTextBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.psnDOBTextBox);
            this.groupBox1.Controls.Add(this.psnDOBLabel);
            this.groupBox1.Controls.Add(this.psnUsernameLabel);
            this.groupBox1.Controls.Add(this.psnUsernameTextBox);
            this.groupBox1.Controls.Add(this.psnPasswordTextBox);
            this.groupBox1.Controls.Add(this.psnEmailLabel);
            this.groupBox1.Controls.Add(this.psnEmailTextBox);
            this.groupBox1.Controls.Add(this.psnPasswordLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 187);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PSN Account Information";
            // 
            // psnDOBTextBox
            // 
            this.psnDOBTextBox.Location = new System.Drawing.Point(9, 159);
            this.psnDOBTextBox.Mask = "00/00/0000";
            this.psnDOBTextBox.Name = "psnDOBTextBox";
            this.psnDOBTextBox.Size = new System.Drawing.Size(66, 20);
            this.psnDOBTextBox.TabIndex = 3;
            // 
            // psnDOBLabel
            // 
            this.psnDOBLabel.AutoSize = true;
            this.psnDOBLabel.Location = new System.Drawing.Point(6, 143);
            this.psnDOBLabel.Name = "psnDOBLabel";
            this.psnDOBLabel.Size = new System.Drawing.Size(123, 13);
            this.psnDOBLabel.TabIndex = 8;
            this.psnDOBLabel.Text = "Date of Birth (mm/dd/yy)";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 307);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(670, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(64, 17);
            this.toolStripLabel.Text = "Status: Idle";
            // 
            // registerOnlineIdButton
            // 
            this.registerOnlineIdButton.Enabled = false;
            this.registerOnlineIdButton.Location = new System.Drawing.Point(12, 242);
            this.registerOnlineIdButton.Name = "registerOnlineIdButton";
            this.registerOnlineIdButton.Size = new System.Drawing.Size(251, 23);
            this.registerOnlineIdButton.TabIndex = 12;
            this.registerOnlineIdButton.Text = "Register Online ID";
            this.registerOnlineIdButton.UseVisualStyleBackColor = true;
            this.registerOnlineIdButton.Click += new System.EventHandler(this.registerOnlineIdButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Leave a field blank to randomize the input";
            // 
            // recaptchaScriptLink
            // 
            this.recaptchaScriptLink.AutoSize = true;
            this.recaptchaScriptLink.Location = new System.Drawing.Point(342, 274);
            this.recaptchaScriptLink.Name = "recaptchaScriptLink";
            this.recaptchaScriptLink.Size = new System.Drawing.Size(241, 13);
            this.recaptchaScriptLink.TabIndex = 13;
            this.recaptchaScriptLink.TabStop = true;
            this.recaptchaScriptLink.Text = "Click me to get a script for getting captcha tokens";
            this.recaptchaScriptLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.recaptchaScriptLink_LinkClicked);
            // 
            // psnCaptchaLink
            // 
            this.psnCaptchaLink.AutoSize = true;
            this.psnCaptchaLink.Location = new System.Drawing.Point(342, 287);
            this.psnCaptchaLink.Name = "psnCaptchaLink";
            this.psnCaptchaLink.Size = new System.Drawing.Size(254, 13);
            this.psnCaptchaLink.TabIndex = 14;
            this.psnCaptchaLink.TabStop = true;
            this.psnCaptchaLink.Text = "Click me to go to the ReCaptcha required for this bot";
            this.psnCaptchaLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.psnCaptchaLink_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 329);
            this.Controls.Add(this.psnCaptchaLink);
            this.Controls.Add(this.recaptchaScriptLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registerOnlineIdButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.consoleOutputGroupBox);
            this.Controls.Add(this.psnCreateAccountButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Simple PSN Registration Bot";
            this.consoleOutputGroupBox.ResumeLayout(false);
            this.consoleOutputGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox psnUsernameTextBox;
        private System.Windows.Forms.TextBox psnPasswordTextBox;
        private System.Windows.Forms.TextBox psnEmailTextBox;
        private System.Windows.Forms.Label psnUsernameLabel;
        private System.Windows.Forms.Label psnPasswordLabel;
        private System.Windows.Forms.Label psnEmailLabel;
        private System.Windows.Forms.Button psnCreateAccountButton;
        private System.Windows.Forms.GroupBox consoleOutputGroupBox;
        private System.Windows.Forms.TextBox consoleOutputTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox psnDOBTextBox;
        private System.Windows.Forms.Label psnDOBLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel;
        private System.Windows.Forms.Button registerOnlineIdButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel recaptchaScriptLink;
        private System.Windows.Forms.LinkLabel psnCaptchaLink;
    }
}

