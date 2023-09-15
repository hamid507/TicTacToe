using TicTacToeSharedLib.Models.Entities;

namespace TicTacToeSharedLib.Models.Dtos.Game
{
    public class MoveResponseDto
    {
        public bool IsValidMove { get; set; }
        public bool IsAborted { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public GameRoomEntity? GameRoom { get; set; }
    }
}
