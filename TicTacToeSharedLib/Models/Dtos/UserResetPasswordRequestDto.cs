namespace TicTacToeSharedLib.Models.Dtos
{
    public class UserResetPasswordRequestDto
    {
        public string? Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public string? PasswordResetToken { get; set; }
    }
}
