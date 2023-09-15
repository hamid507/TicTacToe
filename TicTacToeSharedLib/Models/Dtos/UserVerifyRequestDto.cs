namespace TicTacToeSharedLib.Models.Dtos
{
    public class UserVerifyRequestDto
    {
        public string? Email { get; set; }
        public string? VerificationToken { get; set; }
    }
}
