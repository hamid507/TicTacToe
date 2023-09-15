using TicTacToeSharedLib.Interfaces;

namespace TicTacToeSharedLib.Models.Dtos
{
    public class UserVerifyResponseDto : IDto
    {
        public long Id { get; set; }
        //public string NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public string Password { get; set; } = string.Empty;
        //public byte[] PasswordSalt { get; set; } = new byte[16];
        public string VerificationToken { get; set; } = string.Empty;
        public DateTime? VerifiedDate { get; set; }
        //public string? PasswordResetToken { get; set; }
        //public DateTime? ResetTokenExpirationDate { get; set; }
    }
}