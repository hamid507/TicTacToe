using TicTacToeGame.Config;
using TicTacToeSharedLib.Models.Api.Response;
using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Utility;

namespace TicTacToeGame
{
    public partial class FrmLogin : Form
    {
        public static UserLoginResponseDto? LoggedUser { get; private set; }
        private Settings _settings;

        public static void Logout()
        {
            LoggedUser = null;
        }

        public FrmLogin(Settings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblError.Text = string.Empty;

            try
            {
                if (!ValidateInputs())
                {
                    return;
                }

                var loginResult = await ApiLogin();

                if (!loginResult!.Success)
                {
                    lblError.Text = loginResult.ErrorContent ?? loginResult.ShortErrorMessage;
                    return;
                }
                // Successfully logged in

                LoggedUser = loginResult.Dto;
            }
            finally
            {
                btnLogin.Enabled = true;
            }

            Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Missing fields";
                return false;
            }

            lblError.Text = string.Empty;
            return true;
        }

        private async Task<UserLoginResponse?> ApiLogin()
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            var request = new UserLoginRequestDto { Email = email, Password = password };

            var loginResult = await ApiHelper.LoginAsync(_settings.Endpoints.Api, request, CancellationToken.None, null);

            return loginResult;
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            (Application.OpenForms["FrmMain"] as FrmMain)?.LoginFormClosed();
        }
    }
}
