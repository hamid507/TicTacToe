using TicTacToeSharedLib.Interfaces;
using TicTacToeSharedLib.Utility;

namespace TicTacToeSharedLib.Models.Repo.Response
{
    public class RepoResponse<T> : IRepoResponse<T> where T : class, IDto, new()
    {
        public bool Success { get; set; }
        public virtual T? Dto { get; set; }
        public string? ErrorMessage { get; set; }
        public RepoResponseType? RepoResponseType { get; set; }
    }
}