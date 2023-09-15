using TicTacToeSharedLib.Utility;

namespace TicTacToeSharedLib.Models.Dtos.Game
{
    public class Player
    {
        public string NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public PlayerSign? PlayerSign { get; set; }
        public PlayerPosition? PlayerPosition { get; set; }
    }
}
