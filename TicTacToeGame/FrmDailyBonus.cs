using TicTacToeSharedLib.Models.Entities;

namespace TicTacToeGame
{
    public partial class FrmDailyBonus : Form
    {
        private BonusInfoEntity? _bonusInfo;

        public FrmDailyBonus(BonusInfoEntity? bonusInfo)
        {
            _bonusInfo = bonusInfo;

            InitializeComponent();

            LoadUI();
        }

        private void LoadUI()
        {
            UpdateDays();
            UpdateMessage();
        }

        private void UpdateDays()
        {
            switch (_bonusInfo?.LoginStreak)
            {
                case 2:
                    {
                        label2.BackColor = label1.BackColor;
                        label2.Font = new Font(label1.Font, label1.Font.Style);
                        break;
                    }
                case 3:
                    {
                        label2.BackColor = label1.BackColor;
                        label3.BackColor = label1.BackColor;
                        label2.Font = new Font(label1.Font, label1.Font.Style);
                        label3.Font = new Font(label1.Font, label1.Font.Style);
                        break;
                    }
                case 4:
                    {
                        label2.BackColor = label1.BackColor;
                        label3.BackColor = label1.BackColor;
                        label4.BackColor = label1.BackColor;
                        label2.Font = new Font(label1.Font, label1.Font.Style);
                        label3.Font = new Font(label1.Font, label1.Font.Style);
                        label4.Font = new Font(label1.Font, label1.Font.Style);
                        break;
                    }
                case 5:
                    {
                        label2.BackColor = label1.BackColor;
                        label3.BackColor = label1.BackColor;
                        label4.BackColor = label1.BackColor;
                        label5.BackColor = label1.BackColor;
                        label2.Font = new Font(label1.Font, label1.Font.Style);
                        label3.Font = new Font(label1.Font, label1.Font.Style);
                        label4.Font = new Font(label1.Font, label1.Font.Style);
                        label5.Font = new Font(label1.Font, label1.Font.Style);
                        break;
                    }
                case 6:
                    {
                        label2.BackColor = label1.BackColor;
                        label3.BackColor = label1.BackColor;
                        label4.BackColor = label1.BackColor;
                        label5.BackColor = label1.BackColor;
                        label6.BackColor = label1.BackColor;
                        label2.Font = new Font(label1.Font, label1.Font.Style);
                        label3.Font = new Font(label1.Font, label1.Font.Style);
                        label4.Font = new Font(label1.Font, label1.Font.Style);
                        label5.Font = new Font(label1.Font, label1.Font.Style);
                        label6.Font = new Font(label1.Font, label1.Font.Style);
                        break;
                    }
                case 7:
                    {
                        label2.BackColor = label1.BackColor;
                        label3.BackColor = label1.BackColor;
                        label4.BackColor = label1.BackColor;
                        label5.BackColor = label1.BackColor;
                        label6.BackColor = label1.BackColor;
                        label7.BackColor = label1.BackColor;
                        label2.Font = new Font(label1.Font, label1.Font.Style);
                        label3.Font = new Font(label1.Font, label1.Font.Style);
                        label4.Font = new Font(label1.Font, label1.Font.Style);
                        label5.Font = new Font(label1.Font, label1.Font.Style);
                        label6.Font = new Font(label1.Font, label1.Font.Style);
                        label7.Font = new Font(label1.Font, label1.Font.Style);
                        break;
                    }
                default: break;

            }
        }

        private void UpdateMessage()
        {
            lblMessage.Text = lblMessage.Text.Replace("{days}", _bonusInfo?.LoginStreak.ToString()).Replace("{points}", _bonusInfo?.CalculatedBonus.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
