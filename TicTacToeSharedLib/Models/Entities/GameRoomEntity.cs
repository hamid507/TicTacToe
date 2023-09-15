using Org.BouncyCastle.Bcpg;
using TicTacToeSharedLib.Models.Dtos.Game;
using TicTacToeSharedLib.Utility;

namespace TicTacToeSharedLib.Models.Entities
{
    public class GameRoomEntity
    {
        public string Id { get; set; } = string.Empty;
        public Player Player1 { get; set; } = new() { PlayerPosition = PlayerPosition.PlayerOne};
        public Player Player2 { get; set; } = new() { PlayerPosition = PlayerPosition.PlayerTwo};
        public List<MoveRequestDto> Moves { get; set; } = new();
        public GameResult? GameResult { get; set; }
    }
}
