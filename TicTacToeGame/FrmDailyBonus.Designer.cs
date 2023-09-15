namespace TicTacToeGame
{
    partial class FrmDailyBonus
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
            label1 = new Label();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblDay = new Label();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LimeGreen;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(110, 112);
            label1.Name = "label1";
            label1.Size = new Size(76, 89);
            label1.TabIndex = 0;
            label1.Text = "1";
            // 
            // button1
            // 
            button1.BackColor = Color.YellowGreen;
            button1.Font = new Font("Segoe UI", 8.861538F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(337, 348);
            button1.Name = "button1";
            button1.Size = new Size(130, 52);
            button1.TabIndex = 1;
            button1.Text = "GREAT!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Beige;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(301, 112);
            label3.Name = "label3";
            label3.Size = new Size(56, 64);
            label3.TabIndex = 2;
            label3.Text = "3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Beige;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(205, 112);
            label2.Name = "label2";
            label2.Size = new Size(56, 64);
            label2.TabIndex = 4;
            label2.Text = "2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Beige;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(396, 112);
            label4.Name = "label4";
            label4.Size = new Size(56, 64);
            label4.TabIndex = 5;
            label4.Text = "4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Beige;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(491, 112);
            label5.Name = "label5";
            label5.Size = new Size(56, 64);
            label5.TabIndex = 6;
            label5.Text = "5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Beige;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(586, 112);
            label6.Name = "label6";
            label6.Size = new Size(56, 64);
            label6.TabIndex = 7;
            label6.Text = "6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Beige;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI", 26.03077F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(681, 112);
            label7.Name = "label7";
            label7.Size = new Size(56, 64);
            label7.TabIndex = 8;
            label7.Text = "7";
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("Segoe UI", 18.2769222F, FontStyle.Regular, GraphicsUnit.Point);
            lblDay.Location = new Point(12, 112);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(83, 45);
            lblDay.TabIndex = 9;
            lblDay.Text = "Day:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 11.0769234F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.Location = new Point(32, 297);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(732, 28);
            lblMessage.TabIndex = 10;
            lblMessage.Text = "Congratulations! You logged in {days} day(s) in a row and collected {points} points!";
            // 
            // FrmDailyBonus
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(lblMessage);
            Controls.Add(lblDay);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmDailyBonus";
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Daily bonus";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblDay;
        private Label lblMessage;
    }
}