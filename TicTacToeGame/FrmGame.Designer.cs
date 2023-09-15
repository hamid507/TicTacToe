namespace TicTacToeGame
{
    partial class FrmGame
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
            pnlGame = new Panel();
            btn_bottom_right = new Button();
            btn_bottom_middle = new Button();
            btn_bottom_left = new Button();
            btn_middle_right = new Button();
            btn_middle_middle = new Button();
            btn_middle_left = new Button();
            btn_top_right = new Button();
            btn_top_middle = new Button();
            btn_top_left = new Button();
            lblArrow1 = new Label();
            txtPlayer1 = new TextBox();
            txtPlayer2 = new TextBox();
            lblArrow2 = new Label();
            lblInfo = new Label();
            lblUserTurn = new Label();
            lblPlayer2Sign = new Label();
            lblPlayer1Sign = new Label();
            lblTimer = new Label();
            pnlUserInfo = new Panel();
            txtUserPoints = new TextBox();
            lblUserTotalPoints = new Label();
            txtUserEmail = new TextBox();
            lblUserEmail = new Label();
            txtUserNickName = new TextBox();
            lblUserNickName = new Label();
            btnFakeClose = new Button();
            txtRoom = new TextBox();
            lblRoom = new Label();
            pnlRoomInfo = new Panel();
            pnlGame.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            pnlRoomInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGame
            // 
            pnlGame.Controls.Add(btn_bottom_right);
            pnlGame.Controls.Add(btn_bottom_middle);
            pnlGame.Controls.Add(btn_bottom_left);
            pnlGame.Controls.Add(btn_middle_right);
            pnlGame.Controls.Add(btn_middle_middle);
            pnlGame.Controls.Add(btn_middle_left);
            pnlGame.Controls.Add(btn_top_right);
            pnlGame.Controls.Add(btn_top_middle);
            pnlGame.Controls.Add(btn_top_left);
            pnlGame.Location = new Point(159, 141);
            pnlGame.Margin = new Padding(2);
            pnlGame.Name = "pnlGame";
            pnlGame.Size = new Size(311, 250);
            pnlGame.TabIndex = 0;
            // 
            // btn_bottom_right
            // 
            btn_bottom_right.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_bottom_right.Location = new Point(205, 170);
            btn_bottom_right.Margin = new Padding(2);
            btn_bottom_right.Name = "btn_bottom_right";
            btn_bottom_right.Size = new Size(67, 61);
            btn_bottom_right.TabIndex = 8;
            btn_bottom_right.UseVisualStyleBackColor = true;
            btn_bottom_right.Click += GameMoveButton_Click;
            // 
            // btn_bottom_middle
            // 
            btn_bottom_middle.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_bottom_middle.Location = new Point(121, 170);
            btn_bottom_middle.Margin = new Padding(2);
            btn_bottom_middle.Name = "btn_bottom_middle";
            btn_bottom_middle.Size = new Size(67, 61);
            btn_bottom_middle.TabIndex = 7;
            btn_bottom_middle.UseVisualStyleBackColor = true;
            btn_bottom_middle.Click += GameMoveButton_Click;
            // 
            // btn_bottom_left
            // 
            btn_bottom_left.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_bottom_left.Location = new Point(37, 170);
            btn_bottom_left.Margin = new Padding(2);
            btn_bottom_left.Name = "btn_bottom_left";
            btn_bottom_left.Size = new Size(67, 61);
            btn_bottom_left.TabIndex = 6;
            btn_bottom_left.UseVisualStyleBackColor = true;
            btn_bottom_left.Click += GameMoveButton_Click;
            // 
            // btn_middle_right
            // 
            btn_middle_right.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_middle_right.Location = new Point(205, 96);
            btn_middle_right.Margin = new Padding(2);
            btn_middle_right.Name = "btn_middle_right";
            btn_middle_right.Size = new Size(67, 61);
            btn_middle_right.TabIndex = 5;
            btn_middle_right.UseVisualStyleBackColor = true;
            btn_middle_right.Click += GameMoveButton_Click;
            // 
            // btn_middle_middle
            // 
            btn_middle_middle.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_middle_middle.Location = new Point(121, 96);
            btn_middle_middle.Margin = new Padding(2);
            btn_middle_middle.Name = "btn_middle_middle";
            btn_middle_middle.Size = new Size(67, 61);
            btn_middle_middle.TabIndex = 4;
            btn_middle_middle.UseVisualStyleBackColor = true;
            btn_middle_middle.Click += GameMoveButton_Click;
            // 
            // btn_middle_left
            // 
            btn_middle_left.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_middle_left.Location = new Point(37, 96);
            btn_middle_left.Margin = new Padding(2);
            btn_middle_left.Name = "btn_middle_left";
            btn_middle_left.Size = new Size(67, 61);
            btn_middle_left.TabIndex = 3;
            btn_middle_left.UseVisualStyleBackColor = true;
            btn_middle_left.Click += GameMoveButton_Click;
            // 
            // btn_top_right
            // 
            btn_top_right.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_top_right.Location = new Point(205, 21);
            btn_top_right.Margin = new Padding(2);
            btn_top_right.Name = "btn_top_right";
            btn_top_right.Size = new Size(67, 61);
            btn_top_right.TabIndex = 2;
            btn_top_right.UseVisualStyleBackColor = true;
            btn_top_right.Click += GameMoveButton_Click;
            // 
            // btn_top_middle
            // 
            btn_top_middle.AccessibleDescription = "";
            btn_top_middle.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_top_middle.Location = new Point(121, 21);
            btn_top_middle.Margin = new Padding(2);
            btn_top_middle.Name = "btn_top_middle";
            btn_top_middle.Size = new Size(67, 61);
            btn_top_middle.TabIndex = 1;
            btn_top_middle.UseVisualStyleBackColor = true;
            btn_top_middle.Click += GameMoveButton_Click;
            // 
            // btn_top_left
            // 
            btn_top_left.Font = new Font("Segoe UI", 22.1538467F, FontStyle.Bold, GraphicsUnit.Point);
            btn_top_left.Location = new Point(37, 21);
            btn_top_left.Margin = new Padding(2);
            btn_top_left.Name = "btn_top_left";
            btn_top_left.Size = new Size(67, 61);
            btn_top_left.TabIndex = 0;
            btn_top_left.UseVisualStyleBackColor = true;
            btn_top_left.Click += GameMoveButton_Click;
            // 
            // lblArrow1
            // 
            lblArrow1.AutoSize = true;
            lblArrow1.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            lblArrow1.Location = new Point(502, 162);
            lblArrow1.Margin = new Padding(2, 0, 2, 0);
            lblArrow1.Name = "lblArrow1";
            lblArrow1.Size = new Size(59, 47);
            lblArrow1.TabIndex = 1;
            lblArrow1.Text = "->";
            // 
            // txtPlayer1
            // 
            txtPlayer1.Enabled = false;
            txtPlayer1.Location = new Point(568, 177);
            txtPlayer1.Margin = new Padding(2);
            txtPlayer1.Name = "txtPlayer1";
            txtPlayer1.Size = new Size(209, 23);
            txtPlayer1.TabIndex = 2;
            // 
            // txtPlayer2
            // 
            txtPlayer2.Enabled = false;
            txtPlayer2.Location = new Point(568, 238);
            txtPlayer2.Margin = new Padding(2);
            txtPlayer2.Name = "txtPlayer2";
            txtPlayer2.Size = new Size(209, 23);
            txtPlayer2.TabIndex = 4;
            // 
            // lblArrow2
            // 
            lblArrow2.AutoSize = true;
            lblArrow2.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            lblArrow2.Location = new Point(502, 223);
            lblArrow2.Margin = new Padding(2, 0, 2, 0);
            lblArrow2.Name = "lblArrow2";
            lblArrow2.Size = new Size(59, 47);
            lblArrow2.TabIndex = 3;
            lblArrow2.Text = "->";
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(502, 286);
            lblInfo.Margin = new Padding(2, 0, 2, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(274, 19);
            lblInfo.TabIndex = 5;
            // 
            // lblUserTurn
            // 
            lblUserTurn.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblUserTurn.Location = new Point(409, 86);
            lblUserTurn.Margin = new Padding(2, 0, 2, 0);
            lblUserTurn.Name = "lblUserTurn";
            lblUserTurn.RightToLeft = RightToLeft.Yes;
            lblUserTurn.Size = new Size(366, 33);
            lblUserTurn.TabIndex = 6;
            // 
            // lblPlayer2Sign
            // 
            lblPlayer2Sign.Font = new Font("Segoe UI", 13.8461533F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlayer2Sign.Location = new Point(658, 206);
            lblPlayer2Sign.Margin = new Padding(2, 0, 2, 0);
            lblPlayer2Sign.Name = "lblPlayer2Sign";
            lblPlayer2Sign.Size = new Size(25, 30);
            lblPlayer2Sign.TabIndex = 8;
            // 
            // lblPlayer1Sign
            // 
            lblPlayer1Sign.Font = new Font("Segoe UI", 13.8461533F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlayer1Sign.Location = new Point(658, 145);
            lblPlayer1Sign.Margin = new Padding(2, 0, 2, 0);
            lblPlayer1Sign.Name = "lblPlayer1Sign";
            lblPlayer1Sign.Size = new Size(25, 30);
            lblPlayer1Sign.TabIndex = 9;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Segoe UI Semibold", 23.8153839F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimer.ForeColor = Color.SeaGreen;
            lblTimer.Location = new Point(600, 331);
            lblTimer.Margin = new Padding(2, 0, 2, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(82, 45);
            lblTimer.TabIndex = 10;
            lblTimer.Text = "0:00";
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.Controls.Add(txtUserPoints);
            pnlUserInfo.Controls.Add(lblUserTotalPoints);
            pnlUserInfo.Controls.Add(txtUserEmail);
            pnlUserInfo.Controls.Add(lblUserEmail);
            pnlUserInfo.Controls.Add(txtUserNickName);
            pnlUserInfo.Controls.Add(lblUserNickName);
            pnlUserInfo.Location = new Point(12, 9);
            pnlUserInfo.Margin = new Padding(2);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(285, 92);
            pnlUserInfo.TabIndex = 11;
            // 
            // txtUserPoints
            // 
            txtUserPoints.Enabled = false;
            txtUserPoints.Location = new Point(75, 59);
            txtUserPoints.Margin = new Padding(2);
            txtUserPoints.Name = "txtUserPoints";
            txtUserPoints.Size = new Size(199, 23);
            txtUserPoints.TabIndex = 16;
            // 
            // lblUserTotalPoints
            // 
            lblUserTotalPoints.AutoSize = true;
            lblUserTotalPoints.Location = new Point(24, 61);
            lblUserTotalPoints.Margin = new Padding(2, 0, 2, 0);
            lblUserTotalPoints.Name = "lblUserTotalPoints";
            lblUserTotalPoints.Size = new Size(46, 15);
            lblUserTotalPoints.TabIndex = 15;
            lblUserTotalPoints.Text = "Points: ";
            // 
            // txtUserEmail
            // 
            txtUserEmail.Enabled = false;
            txtUserEmail.Location = new Point(75, 34);
            txtUserEmail.Margin = new Padding(2);
            txtUserEmail.Name = "txtUserEmail";
            txtUserEmail.Size = new Size(199, 23);
            txtUserEmail.TabIndex = 14;
            // 
            // lblUserEmail
            // 
            lblUserEmail.AutoSize = true;
            lblUserEmail.Location = new Point(27, 36);
            lblUserEmail.Margin = new Padding(2, 0, 2, 0);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(42, 15);
            lblUserEmail.TabIndex = 13;
            lblUserEmail.Text = "Email: ";
            // 
            // txtUserNickName
            // 
            txtUserNickName.Enabled = false;
            txtUserNickName.Location = new Point(75, 9);
            txtUserNickName.Margin = new Padding(2);
            txtUserNickName.Name = "txtUserNickName";
            txtUserNickName.Size = new Size(199, 23);
            txtUserNickName.TabIndex = 12;
            // 
            // lblUserNickName
            // 
            lblUserNickName.AutoSize = true;
            lblUserNickName.Location = new Point(2, 11);
            lblUserNickName.Margin = new Padding(2, 0, 2, 0);
            lblUserNickName.Name = "lblUserNickName";
            lblUserNickName.Size = new Size(67, 15);
            lblUserNickName.TabIndex = 0;
            lblUserNickName.Text = "Nickname: ";
            // 
            // btnFakeClose
            // 
            btnFakeClose.BackColor = Color.IndianRed;
            btnFakeClose.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point);
            btnFakeClose.ForeColor = Color.White;
            btnFakeClose.Location = new Point(806, 6);
            btnFakeClose.Margin = new Padding(2);
            btnFakeClose.Name = "btnFakeClose";
            btnFakeClose.Size = new Size(39, 32);
            btnFakeClose.TabIndex = 12;
            btnFakeClose.Text = "X";
            btnFakeClose.UseVisualStyleBackColor = false;
            btnFakeClose.Visible = false;
            btnFakeClose.Click += btnFakeClose_Click;
            // 
            // txtRoom
            // 
            txtRoom.Enabled = false;
            txtRoom.Location = new Point(91, 11);
            txtRoom.Margin = new Padding(2);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(128, 23);
            txtRoom.TabIndex = 20;
            txtRoom.WordWrap = false;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(18, 13);
            lblRoom.Margin = new Padding(2, 0, 2, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(45, 15);
            lblRoom.TabIndex = 19;
            lblRoom.Text = "Room: ";
            // 
            // pnlRoomInfo
            // 
            pnlRoomInfo.Controls.Add(txtRoom);
            pnlRoomInfo.Controls.Add(lblRoom);
            pnlRoomInfo.Location = new Point(342, 9);
            pnlRoomInfo.Name = "pnlRoomInfo";
            pnlRoomInfo.Size = new Size(228, 51);
            pnlRoomInfo.TabIndex = 21;
            // 
            // FrmGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 445);
            Controls.Add(pnlRoomInfo);
            Controls.Add(btnFakeClose);
            Controls.Add(pnlUserInfo);
            Controls.Add(lblTimer);
            Controls.Add(lblPlayer1Sign);
            Controls.Add(lblPlayer2Sign);
            Controls.Add(lblUserTurn);
            Controls.Add(lblInfo);
            Controls.Add(txtPlayer2);
            Controls.Add(lblArrow2);
            Controls.Add(txtPlayer1);
            Controls.Add(lblArrow1);
            Controls.Add(pnlGame);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FrmGame";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "TicTacToe Game";
            FormClosing += FrmGame_FormClosing;
            FormClosed += FrmGame_FormClosed;
            Shown += FrmGame_Shown;
            pnlGame.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            pnlUserInfo.PerformLayout();
            pnlRoomInfo.ResumeLayout(false);
            pnlRoomInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGame;
        private Button btn_middle_right;
        private Button btn_middle_middle;
        private Button btn_middle_left;
        private Button btn_top_right;
        private Button btn_top_middle;
        private Button btn_top_left;
        private Button btn_bottom_right;
        private Button btn_bottom_middle;
        private Button btn_bottom_left;
        private Label lblArrow1;
        private TextBox txtPlayer1;
        private TextBox txtPlayer2;
        private Label lblArrow2;
        private Label lblInfo;
        private Label lblUserTurn;
        private Label lblPlayer2Sign;
        private Label lblPlayer1Sign;
        private Label lblTimer;
        private Panel pnlUserInfo;
        private TextBox txtUserEmail;
        private Label lblUserEmail;
        private TextBox txtUserNickName;
        private Label lblUserNickName;
        private TextBox txtUserPoints;
        private Label lblUserTotalPoints;
        private Button btnFakeClose;
        private TextBox txtRoom;
        private Label lblRoom;
        private Panel pnlRoomInfo;
    }
}