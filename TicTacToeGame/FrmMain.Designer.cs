namespace TicTacToeGame
{
    partial class FrmMain
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
            btnPlay = new Button();
            btnExit = new Button();
            pnlGuest = new Panel();
            btnRegister = new Button();
            btnLogin = new Button();
            pnlUserInfo = new Panel();
            lblVerified = new Label();
            btnVerify = new Button();
            btnLogout = new Button();
            txtTotalPoints = new TextBox();
            lblPoints = new Label();
            lblWelcome = new Label();
            lblnfo = new Label();
            btnCancel = new Button();
            flpActiveRooms = new FlowLayoutPanel();
            lblActiveGames = new Label();
            pnlActiveRooms = new Panel();
            pnlGuest.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            pnlActiveRooms.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 18.2769222F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnPlay.Location = new Point(326, 118);
            btnPlay.Margin = new Padding(2, 2, 2, 2);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(186, 49);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "PLAY";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 18.2769222F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnExit.ForeColor = Color.Red;
            btnExit.Location = new Point(326, 194);
            btnExit.Margin = new Padding(2, 2, 2, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(186, 49);
            btnExit.TabIndex = 1;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // pnlGuest
            // 
            pnlGuest.Controls.Add(btnRegister);
            pnlGuest.Controls.Add(btnLogin);
            pnlGuest.Location = new Point(593, 9);
            pnlGuest.Margin = new Padding(2, 2, 2, 2);
            pnlGuest.Name = "pnlGuest";
            pnlGuest.Size = new Size(211, 51);
            pnlGuest.TabIndex = 2;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.LightSalmon;
            btnRegister.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnRegister.Location = new Point(109, 15);
            btnRegister.Margin = new Padding(2, 2, 2, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(79, 22);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightGreen;
            btnLogin.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.Location = new Point(11, 15);
            btnLogin.Margin = new Padding(2, 2, 2, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(79, 22);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.Controls.Add(lblVerified);
            pnlUserInfo.Controls.Add(btnVerify);
            pnlUserInfo.Controls.Add(btnLogout);
            pnlUserInfo.Controls.Add(txtTotalPoints);
            pnlUserInfo.Controls.Add(lblPoints);
            pnlUserInfo.Controls.Add(lblWelcome);
            pnlUserInfo.Location = new Point(556, 9);
            pnlUserInfo.Margin = new Padding(2, 2, 2, 2);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(247, 96);
            pnlUserInfo.TabIndex = 3;
            pnlUserInfo.Visible = false;
            // 
            // lblVerified
            // 
            lblVerified.AutoSize = true;
            lblVerified.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblVerified.ForeColor = Color.Green;
            lblVerified.Location = new Point(8, 41);
            lblVerified.Margin = new Padding(2, 0, 2, 0);
            lblVerified.Name = "lblVerified";
            lblVerified.Size = new Size(56, 15);
            lblVerified.TabIndex = 4;
            lblVerified.Text = "Verified!";
            lblVerified.Visible = false;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.LightSalmon;
            btnVerify.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point);
            btnVerify.Location = new Point(7, 38);
            btnVerify.Margin = new Padding(2, 2, 2, 2);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(58, 22);
            btnVerify.TabIndex = 3;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LightSalmon;
            btnLogout.Font = new Font("Segoe UI Semibold", 8.861538F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.Location = new Point(104, 38);
            btnLogout.Margin = new Padding(2, 2, 2, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(58, 22);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // txtTotalPoints
            // 
            txtTotalPoints.Enabled = false;
            txtTotalPoints.Location = new Point(82, 74);
            txtTotalPoints.Margin = new Padding(2, 2, 2, 2);
            txtTotalPoints.Name = "txtTotalPoints";
            txtTotalPoints.Size = new Size(112, 23);
            txtTotalPoints.TabIndex = 2;
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.Location = new Point(2, 76);
            lblPoints.Margin = new Padding(2, 0, 2, 0);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(74, 15);
            lblPoints.TabIndex = 1;
            lblPoints.Text = "Total points: ";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(2, 11);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(63, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, ";
            // 
            // lblnfo
            // 
            lblnfo.Location = new Point(198, 252);
            lblnfo.Margin = new Padding(2, 0, 2, 0);
            lblnfo.Name = "lblnfo";
            lblnfo.Size = new Size(435, 88);
            lblnfo.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.Red;
            btnCancel.Location = new Point(380, 167);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 22);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // flpActiveRooms
            // 
            flpActiveRooms.AutoScroll = true;
            flpActiveRooms.BorderStyle = BorderStyle.FixedSingle;
            flpActiveRooms.Location = new Point(110, 2);
            flpActiveRooms.Margin = new Padding(2, 2, 2, 2);
            flpActiveRooms.Name = "flpActiveRooms";
            flpActiveRooms.Size = new Size(374, 52);
            flpActiveRooms.TabIndex = 8;
            flpActiveRooms.WrapContents = false;
            // 
            // lblActiveGames
            // 
            lblActiveGames.AutoSize = true;
            lblActiveGames.Location = new Point(19, 17);
            lblActiveGames.Margin = new Padding(2, 0, 2, 0);
            lblActiveGames.Name = "lblActiveGames";
            lblActiveGames.Size = new Size(83, 15);
            lblActiveGames.TabIndex = 9;
            lblActiveGames.Text = "Active rooms: ";
            // 
            // pnlActiveRooms
            // 
            pnlActiveRooms.Controls.Add(flpActiveRooms);
            pnlActiveRooms.Controls.Add(lblActiveGames);
            pnlActiveRooms.Location = new Point(58, 19);
            pnlActiveRooms.Margin = new Padding(2, 2, 2, 2);
            pnlActiveRooms.Name = "pnlActiveRooms";
            pnlActiveRooms.Size = new Size(485, 81);
            pnlActiveRooms.TabIndex = 10;
            pnlActiveRooms.Visible = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 384);
            Controls.Add(pnlActiveRooms);
            Controls.Add(btnCancel);
            Controls.Add(lblnfo);
            Controls.Add(pnlUserInfo);
            Controls.Add(pnlGuest);
            Controls.Add(btnExit);
            Controls.Add(btnPlay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "FrmMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TicTacToe Multiplayer Game";
            FormClosing += FrmMain_FormClosing;
            pnlGuest.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            pnlUserInfo.PerformLayout();
            pnlActiveRooms.ResumeLayout(false);
            pnlActiveRooms.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlay;
        private Button btnExit;
        private Panel pnlGuest;
        private Button btnRegister;
        private Button btnLogin;
        private Panel pnlUserInfo;
        private Button btnLogout;
        private TextBox txtTotalPoints;
        private Label lblPoints;
        private Label lblWelcome;
        private Button btnVerify;
        private Label lblVerified;
        private Label lblnfo;
        private Button btnCancel;
        private FlowLayoutPanel flpActiveRooms;
        private Label lblActiveGames;
        private Panel pnlActiveRooms;
    }
}