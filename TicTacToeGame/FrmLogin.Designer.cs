namespace TicTacToeGame
{
    partial class FrmLogin
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
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            lblError = new Label();
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
            txtEmail.Location = new Point(279, 111);
            txtEmail.MaxLength = 40;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(313, 29);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(279, 146);
            txtPassword.MaxLength = 40;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(313, 29);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(165, 141);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(108, 30);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.Location = new Point(378, 206);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(102, 52);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblError
            // 
            lblError.Location = new Point(130, 276);
            lblError.Name = "lblError";
            lblError.Size = new Size(559, 123);
            lblError.TabIndex = 5;
            // 
            // FrmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            FormClosed += FrmLogin_FormClosed;
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Label lblError;
    }
}