using TicTacToeSharedLib.Interfaces;
using TicTacToeSharedLib.Models.Entities;

namespace TicTacToeSharedLib.Models.Dtos
{
    public class UserLoginResponseDto : IDto
    {
        public long Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string VerificationToken { get; set; } = string.Empty;
        public DateTime? VerifiedDate { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpirationDate { get; set; }
        public BonusInfoEntity? BonusInfo { get; set; }
    }
}