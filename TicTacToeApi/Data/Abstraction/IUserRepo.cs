using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Models.Entities;
using TicTacToeSharedLib.Models.Repo.Response;

namespace TicTacToeApi.Data.Abstraction
{
    public interface IUserRepo
    {
        UserRegisterRepoResponse Register(UserRegisterRequestDto dto);
        UserLoginRepoResponse Login(UserLoginRequestDto dto);
        UserVerifyRepoResponse Verify(UserVerifyRequestDto dto);
    }
}
