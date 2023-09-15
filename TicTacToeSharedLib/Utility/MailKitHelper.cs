using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using TicTacToeSharedLib.Models.Dtos;

namespace TicTacToeSharedLib.Utility
{
    public static class MailKitHelper
    {
        #region private Methods

        private static bool SendInternal(MailkitRequestDto requestDto, TextFormat textFormat, out Exception? ex)
        {
            try
            {
                var msg = new MimeMessage();
                msg.From.Add(MailboxAddress.Parse(requestDto.From));
                msg.To.Add(MailboxAddress.Parse(requestDto.To));
                msg.Subject = requestDto.Subject;
                msg.Body = new TextPart(textFormat) { Text = requestDto.Body };

                using var smtp = new SmtpClient();
                smtp.Connect(requestDto.Host, requestDto.Port, SecureSocketOptions.Auto);
                smtp.Authenticate(requestDto.From, requestDto.Password);

                smtp.Send(msg);
                smtp.Disconnect(true);

                ex = null;
                return true;
            }
            catch(Exception e)
            {
                ex = e;
                return false;
            }
        }

        #endregion

        public static bool SendText(MailkitRequestDto requestDto, out Exception? ex)
        {
            return SendInternal(requestDto, TextFormat.Text, out ex);
        }

        public static bool SendHtml(MailkitRequestDto requestDto, out Exception? ex)
        {
            return SendInternal(requestDto, TextFormat.Html, out ex);
        }
    }
}
