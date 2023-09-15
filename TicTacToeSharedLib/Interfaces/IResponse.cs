namespace TicTacToeSharedLib.Interfaces
{
    public interface IResponse
    {
        bool Success { get; set; }
        string? ErrorMessage { get; set; }
    }
}
