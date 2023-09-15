namespace TicTacToeSharedLib.Models.Dtos.Game
{
    public class MoveDto
    {
        public string Id { get; set; } = string.Empty;
        public bool Pass { get; set; }
        public string RoomId { get; set; } = string.Empty;
        public GameButton GameButton { get; set; } = null!;
        public Player Player { get; set; } = null!;
        public DateTime MoveTime { get; set; }
    }
}
