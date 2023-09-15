using TicTacToeSharedLib.Interfaces;

namespace TicTacToeSharedLib.Models.Dtos
{
    public class UserForgotPasswordResponseDto : IDto
    {
        public string Email { get; set; } = string.Empty;
    }
}