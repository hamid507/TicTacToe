using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGame.Config;
using TicTacToeGame.Mail;
using TicTacToeSharedLib.Models.Api.Response;
using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Utility;

namespace TicTacToeGame
{
    public partial class FrmRegister : Form
    {
        private readonly Settings _settings;

        public FrmRegister(Settings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;
            lblError.Text = string.Empty;

            try
            {
                if (!ValidateInputs())
                {
                    return;
                }

                var registerResponse = await ApiRegister();

                if (!registerResponse!.Success)
                {
                    lblError.Text = registerResponse.ErrorContent ?? registerResponse.ShortErrorMessage;
                    return;
                }
                //Successfully registered

                lblError.Text = "Successfully registered.";
                txtNickName.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
                txtPasswordRepeat.Clear();

                MailSender.SendVerificationEmail(_settings, registerResponse.Dto!.Email, registerResponse.Dto.VerificationToken);
            }
            finally
            {
                btnRegister.Enabled = true;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNickName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordRepeat.Text))
            {
                lblError.Text = "Missing fields";
                return false;
            }

            if (txtPassword.Text != txtPasswordRepeat.Text)
            {
                lblError.Text = "Passwords do not match";
                return false;
            }

            lblError.Text = string.Empty;
            return true;
        }

        private async Task<UserRegisterResponse?> ApiRegister()
        {
            string nickName = txtNickName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            var request = new UserRegisterRequestDto { NickName = nickName, Email = email, Password = password };

            var registerResult = await ApiHelper.RegisterAsync(_settings.Endpoints.Api, request, CancellationToken.None, null);

            return registerResult;
        }
    }
}
