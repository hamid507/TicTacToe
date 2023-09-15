using TicTacToeGame.Config;
using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Utility;

namespace TicTacToeGame.Mail
{
    public static class MailSender
    {
        public static void SendVerificationEmail(Settings settings, string? email, string? token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            {
                MessageBox.Show("Verification email failed. Missing fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dto = new MailkitRequestDto
            {
                To = email,
                Subject = "Token verification",
                Body = token,
                From = settings.MailKit.From,
                Host = settings.MailKit.Host,
                Port = settings.MailKit.Port,
                Password = settings.MailKit.Password
            };

            bool mailSent = MailKitHelper.SendText(dto, out _);

            if (!mailSent)
            {
                MessageBox.Show("Verification email failed. Try again later.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Verification email sent. Check your email.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
