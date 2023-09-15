namespace TicTacToeGame
{
    partial class FrmVerify
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
            lblEmail = new Label();
            txtEmail = new TextBox();
            txtToken = new TextBox();
            lblToken = new Label();
            btnVerify = new Button();
            lblError = new Label();
            lnkLblResend = new LinkLabel();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(204, 106);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 30);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(279, 111);
            txtEmail.MaxLength = 40;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(313, 29);
            txtEmail.TabIndex = 1;
            // 
            // txtToken
            // 
            txtToken.BorderStyle = BorderStyle.FixedSingle;
            txtToken.Location = new Point(279, 146);
            txtToken.MaxLength = 128;
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(313, 29);
            txtToken.TabIndex = 3;
            txtToken.TextChanged += txtPassword_TextChanged;
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point);
            lblToken.Location = new Point(197, 141);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(76, 30);
            lblToken.TabIndex = 2;
            lblToken.Text = "Token:";
            // 
            // btnVerify
            // 
            btnVerify.Enabled = false;
            btnVerify.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Bold, GraphicsUnit.Point);
            btnVerify.Location = new Point(378, 206);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(102, 52);
            btnVerify.TabIndex = 4;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // lblError
            // 
            lblError.Location = new Point(130, 276);
            lblError.Name = "lblError";
            lblError.Size = new Size(559, 123);
            lblError.TabIndex = 5;
            // 
            // lnkLblResend
            // 
            lnkLblResend.AutoSize = true;
            lnkLblResend.Location = new Point(511, 237);
            lnkLblResend.Name = "lnkLblResend";
            lnkLblResend.Size = new Size(57, 21);
            lnkLblResend.TabIndex = 6;
            lnkLblResend.TabStop = true;
            lnkLblResend.Text = "resend";
            lnkLblResend.LinkClicked += lnkLblResend_LinkClicked;
            // 
            // FrmVerify
            // 
            AcceptButton = btnVerify;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lnkLblResend);
            Controls.Add(lblError);
            Controls.Add(btnVerify);
            Controls.Add(txtToken);
            Controls.Add(lblToken);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            MaximizeBox = false;
            Name = "FrmVerify";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Verify";
            FormClosed += FrmVerify_FormClosed;
            Load += FrmVerify_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private TextBox txtToken;
        private Label lblToken;
        private Button btnVerify;
        private Label lblError;
        private LinkLabel lnkLblResend;
    }
}