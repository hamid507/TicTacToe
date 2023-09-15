namespace TicTacToeGame
{
    partial class FrmRegister
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
            lblPassword = new Label();
            btnRegister = new Button();
            lblError = new Label();
            txtNickName = new TextBox();
            lblNickName = new Label();
            lblRepeatPassword = new Label();
            txtPasswordRepeat = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(205, 93);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 30);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(280, 98);
            txtEmail.MaxLength = 40;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(313, 29);
            txtEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(166, 137);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(108, 30);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegister.Location = new Point(352, 256);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(139, 52);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblError
            // 
            lblError.Location = new Point(136, 325);
            lblError.Name = "lblError";
            lblError.Size = new Size(559, 123);
            lblError.TabIndex = 5;
            // 
            // txtNickName
            // 
            txtNickName.BorderStyle = BorderStyle.FixedSingle;
            txtNickName.Location = new Point(280, 53);
            txtNickName.MaxLength = 40;
            txtNickName.Name = "txtNickName";
            txtNickName.Size = new Size(313, 29);
            txtNickName.TabIndex = 1;
            // 
            // lblNickName
            // 
            lblNickName.AutoSize = true;
            lblNickName.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point);
            lblNickName.Location = new Point(160, 48);
            lblNickName.Name = "lblNickName";
            lblNickName.Size = new Size(114, 30);
            lblNickName.TabIndex = 6;
            lblNickName.Text = "Nickname:";
            // 
            // lblRepeatPassword
            // 
            lblRepeatPassword.AutoSize = true;
            lblRepeatPassword.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point);
            lblRepeatPassword.Location = new Point(91, 182);
            lblRepeatPassword.Name = "lblRepeatPassword";
            lblRepeatPassword.Size = new Size(183, 30);
            lblRepeatPassword.TabIndex = 8;
            lblRepeatPassword.Text = "Repeat password:";
            // 
            // txtPasswordRepeat
            // 
            txtPasswordRepeat.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordRepeat.Location = new Point(280, 187);
            txtPasswordRepeat.MaxLength = 40;
            txtPasswordRepeat.Name = "txtPasswordRepeat";
            txtPasswordRepeat.PasswordChar = '*';
            txtPasswordRepeat.Size = new Size(313, 29);
            txtPasswordRepeat.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(280, 142);
            txtPassword.MaxLength = 40;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(313, 29);
            txtPassword.TabIndex = 3;
            // 
            // FrmRegister
            // 
            AcceptButton = btnRegister;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 463);
            Controls.Add(txtPassword);
            Controls.Add(txtPasswordRepeat);
            Controls.Add(lblRepeatPassword);
            Controls.Add(txtNickName);
            Controls.Add(lblNickName);
            Controls.Add(lblError);
            Controls.Add(btnRegister);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmRegister";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register";
            Load += FrmRegister_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private Button btnRegister;
        private Label lblError;
        private TextBox txtNickName;
        private Label lblNickName;
        private Label lblRepeatPassword;
        private TextBox txtPasswordRepeat;
        private TextBox txtPassword;
    }
}