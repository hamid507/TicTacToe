using TicTacToeSharedLib.Interfaces;

namespace TicTacToeSharedLib.Models.Dtos
{
    public class UserLoginRequestDto : IDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}