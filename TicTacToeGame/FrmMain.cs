using System.Text.Json;
using TicTacToeGame.Config;
using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Models.Entities;
using TicTacToeSharedLib.Utility;
using WebSocketSharp;
using static TicTacToeGame.FormUtil;

namespace TicTacToeGame
{
    public partial class FrmMain : Form
    {
        private readonly Settings _settings;
        private readonly Client _roomClient;

        public FrmMain(Settings settings)
        {
            _settings = settings;

            InitializeComponent();

            //Initialize client
            _roomClient = new Client(_settings, "/Room");
            _roomClient.WebSocket.OnMessage += MessageResponse;
            _roomClient.WebSocket.OnError += Ws_OnError;

        }

        private void Ws_OnError(object? sender, WebSocketSharp.ErrorEventArgs e)
        {
            //For debug purposes
            //MessageBox.Show(FrmLogin.LoggedUser!.Email + " ROOM CLIENT ERROR : " + e.Exception);
        }

        private void MessageResponse(object? sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data)) return;

            var dto = JsonSerializer.Deserialize<GameRoomEntity>(e.Data);
            if (dto == null) return;

            if (dto.Player2.PlayerSign == null) return;

            // Match found
            UpdateControl(lblnfo, "Match found!", ControlUpdateType.Text);
            UpdateControl(btnCancel, false, ControlUpdateType.Visible);
            var gameForm = new FrmGame(_settings, dto);
            gameForm.ShowDialog();
        }

        private void PrepareUserPanel()
        {
            pnlGuest.Visible = false;
            pnlUserInfo.Visible = true;
            lblWelcome.Text = lblWelcome.Text + FrmLogin.LoggedUser?.NickName;

            ValidateVerification();

            txtTotalPoints.Text = FrmLogin.LoggedUser?.BonusInfo?.TotalBonus.ToString();
        }

        private void ValidateVerification()
        {
            bool verified = FrmLogin.LoggedUser?.VerifiedDate != null;
            btnVerify.Visible = !verified;
            lblVerified.Visible = verified;
        }

        private void ShowBonusForm(BonusInfoEntity? bonusInfo)
        {
            var bonusForm = new FrmDailyBonus(bonusInfo);
            bonusForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenLoginForm();
        }

        private void OpenLoginForm()
        {
            var loginForm = new FrmLogin(_settings);
            loginForm.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OpenRegisterForm();
        }

        private void OpenRegisterForm()
        {
            var registerForm = new FrmRegister(_settings);
            registerForm.ShowDialog();
        }

        internal void LoginFormClosed()
        {
            if (FrmLogin.LoggedUser == null) return;

            PrepareUserPanel();
            //PrepareActiveRooms();

            if (FrmLogin.LoggedUser?.BonusInfo?.CalculatedBonus != 0)
            {
                ShowBonusForm(FrmLogin.LoggedUser?.BonusInfo);
            }
        }

        private void PrepareActiveRooms()
        {
            for (int i = 0; i < 0; i++)
            {
                Button roomButton = new Button
                {
                    Text = "button " + (i + 1),
                    Size = new Size(150, 30)
                };
                roomButton.Click += RoomButton_Click;

                flpActiveRooms.Controls.Add(roomButton);
            }
            pnlActiveRooms.Visible = true;
        }

        private void RoomButton_Click(object? sender, EventArgs e)
        {

        }

        internal void GameFormHidden(FrmGame game)
        {
            UpdateControl(btnCancel, false, ControlUpdateType.Visible);
            UpdateControl(btnPlay, true, ControlUpdateType.Enabled);
            UpdateControl(pnlUserInfo, true, ControlUpdateType.Enabled);
            UpdateControl(lblnfo, string.Empty, ControlUpdateType.Text);
        }

        internal void GameFormClosed()
        {
            UpdateControl(btnCancel, false, ControlUpdateType.Visible);
            UpdateControl(btnPlay, true, ControlUpdateType.Enabled);
            UpdateControl(pnlUserInfo, true, ControlUpdateType.Enabled);
            UpdateControl(lblnfo, string.Empty, ControlUpdateType.Text);
        }

        internal void VerifyFormClosed()
        {
            ValidateVerification();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin.Logout();
            pnlUserInfo.Visible = false;
            pnlActiveRooms.Visible = false;
            pnlGuest.Visible = true;
            lblWelcome.Text = "Welcome, ";
            txtTotalPoints.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Close();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pnlUserInfo.Enabled = false;
            btnPlay.Enabled = false;
            btnCancel.Visible = true;
            lblnfo.Text = string.Empty;

            try
            {
                if (FrmLogin.LoggedUser == null)
                {
                    btnCancel.Visible = false;
                    btnPlay.Enabled = true;
                    pnlUserInfo.Enabled = true;
                    MessageBox.Show("Sign in to play.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (FrmLogin.LoggedUser.VerifiedDate == null)
                {
                    btnCancel.Visible = false;
                    btnPlay.Enabled = true;
                    pnlUserInfo.Enabled = true;
                    MessageBox.Show("User not verified. Please check your email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ClientNewGameRequest();
            }
            catch
            {
                btnCancel.Visible = false;
                btnPlay.Enabled = true;
                pnlUserInfo.Enabled = true;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            var verifyForm = new FrmVerify(_settings!);
            verifyForm.ShowDialog();
        }

        private void ClientNewGameRequest()
        {
            //Generate request message
            var request = new RoomRequestDto
            {
                NickName = FrmLogin.LoggedUser!.NickName,
                Email = FrmLogin.LoggedUser.Email
            };

            var message = JsonSerializer.Serialize(request);

            if (!_roomClient.Send(message))
            {
                btnCancel.Visible = false;
                btnPlay.Enabled = true;
                pnlUserInfo.Enabled = true;
                MessageBox.Show("Failed to connect to the matching server.");
            }
            else
            {
                //the message was successfully sent
                UpdateControl(lblnfo, "Waiting for a game match...", ControlUpdateType.Text);
                btnCancel.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;

            //Generate cancel message
            var request = new RoomRequestDto
            {
                CancelRequest = true
            };

            var message = JsonSerializer.Serialize(request);

            if (!_roomClient.Send(message))
            {
                MessageBox.Show("Failed to connect to the matching server.");
            }
            else
            {
                //the message was successfully sent
                btnCancel.Visible = false;
                btnPlay.Enabled = true;
                pnlUserInfo.Enabled = true;
                UpdateControl(lblnfo, string.Empty, ControlUpdateType.Text);
            }

            btnCancel.Enabled = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Application.OpenForms["FrmGame"] as FrmGame)?.MainFormClosing();
            _roomClient.WebSocket.Close();
        }
    }
}