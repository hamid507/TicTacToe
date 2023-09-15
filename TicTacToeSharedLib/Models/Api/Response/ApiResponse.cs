using TicTacToeSharedLib.Interfaces;

namespace TicTacToeSharedLib.Models.Api.Response
{
    public class ApiResponse<T> : IApiResponse<T> where T : class, IDto, new()
    {
        public bool Success { get; set; }
        public virtual T? Dto { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ShortErrorMessage { get; set; }
        public string? ErrorContent { get; set; }
        public TimeSpan? RetryAfter { get; set; }
        public Stream FileStream { get; set; } = null!;
    }
}