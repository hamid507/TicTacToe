using MailKit.Security;

namespace TicTacToeSharedLib.Models.Dtos
{
    public class MailkitRequestDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string From { get; set; } = string.Empty;
        public string Password  { get; set; } = string.Empty;
}
}
