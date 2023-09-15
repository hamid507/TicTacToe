namespace TicTacToeSharedLib.Interfaces
{
    public interface IApiResponse<T> : IApiResponse where T : class, IDto, new()
    {
        T? Dto { get; set; }
    }

    public interface IApiResponse : IResponse
    {
        TimeSpan? RetryAfter { get; set; }
        Stream FileStream { get; set; }
    }
}