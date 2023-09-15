using TicTacToeSharedLib.Utility;

namespace TicTacToeSharedLib.Models.Dtos.Game
{
    public class Winner
    {
        public PlayerPosition PlayerPosition { get; set; }
        public GameWinLine GameWinLine { get; set; }
    }
}
