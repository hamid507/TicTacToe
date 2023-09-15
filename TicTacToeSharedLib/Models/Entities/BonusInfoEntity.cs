namespace TicTacToeSharedLib.Models.Entities
{
    public class BonusInfoEntity
    {
        public int LoginStreak { get; set; } = 1;
        public DateTime? LastLoginDate { get; set; }
        public int CalculatedBonus { get; set; }
        public long TotalBonus { get; set; }
    }
}
