using TicTacToeSharedLib.Utility;

namespace TicTacToeSharedLib.Models.Dtos.Game
{
    public class GameResult
    {
        public Winner? Winner { get; set; }
        public GameResultType GameResultType { get; set; }
    }
}
