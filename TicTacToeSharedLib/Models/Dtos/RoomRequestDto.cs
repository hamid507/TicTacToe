namespace TicTacToeSharedLib.Models.Dtos
{
    public class RoomRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public bool CancelRequest { get; set; }
    }
}
