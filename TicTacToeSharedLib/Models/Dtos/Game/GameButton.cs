using TicTacToeSharedLib.Utility;

namespace TicTacToeSharedLib.Models.Dtos.Game
{
    public class GameButton
    {
        public string ButtonName { get; set; } = string.Empty;
        public bool Left { get; set; }
        public bool HorizontalMiddle { get; set; }
        public bool Right { get; set; }
        public bool Top { get; set; }
        public bool VerticalMiddle { get; set; }
        public bool Bottom { get; set; }
    }
}
