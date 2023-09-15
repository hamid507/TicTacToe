using TicTacToeSharedLib.Interfaces;

namespace TicTacToeSharedLib.Models.Dtos
{
    public class NewGameResponseDto : IDto
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string VerificationToken { get; set; } = string.Empty;
    }
}