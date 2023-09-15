using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public partial class FrmVerify : Form
    {
        private readonly Settings _settings;

        public FrmVerify(Settings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void FrmVerify_Load(object sender, EventArgs e)
        {
            txtEmail.Text = FrmLogin.LoggedUser?.Email;
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            btnVerify.Enabled = false;
            lblError.Text = string.Empty;

            try
            {
                var verifyResult = await ApiVerify();

                if (!verifyResult!.Success)
                {
                    lblError.Text = verifyResult.ErrorContent ?? verifyResult.ShortErrorMessage;
                    return;
                }
                // Successfully verified

                if (FrmLogin.LoggedUser != null && verifyResult.Dto != null)
                {
                    FrmLogin.LoggedUser.VerifiedDate = verifyResult.Dto.VerifiedDate;
                    FrmLogin.LoggedUser.VerificationToken = verifyResult.Dto.VerificationToken;
                }

                lblError.Text = "Successfully verified.";
                txtToken.Clear();
            }
            finally
            {
                ValidateVerifyButton();
            }
        }

        private async Task<UserVerifyResponse> ApiVerify()
        {
            string email = txtEmail.Text;
            string token = txtToken.Text;

            var request = new UserVerifyRequestDto { Email = email, VerificationToken = token };

            var verifyResult = await ApiHelper.VerifyAsync(_settings.Endpoints.Api, request, CancellationToken.None, null);

            return verifyResult;
        }

        private void FrmVerify_FormClosed(object sender, FormClosedEventArgs e)
        {
            (Application.OpenForms["FrmMain"] as FrmMain)?.VerifyFormClosed();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateVerifyButton();
        }

        private void ValidateVerifyButton()
        {
            btnVerify.Enabled = txtEmail.Text.Length > 0 && txtToken.Text.Length > 0;
        }

        private void lnkLblResend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkLblResend.Enabled = false;
            try
            {
                MailSender.SendVerificationEmail(_settings, FrmLogin.LoggedUser?.Email, FrmLogin.LoggedUser?.VerificationToken);
            }
            finally
            {
                lnkLblResend.Enabled = true;
            }
        }
    }
}
