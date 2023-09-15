namespace TicTacToeGame.Config
{
    public sealed class MailKit
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public string From { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
