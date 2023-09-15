using TicTacToeSharedLib.Utility;

namespace TicTacToeSharedLib.Interfaces
{
    public interface IRepoResponse<T> : IRepoResponse where T : class, IDto, new()
    {
        T? Dto { get; set; }
    }

    public interface IRepoResponse : IResponse
    {
        RepoResponseType? RepoResponseType { get; set; }
    }
}