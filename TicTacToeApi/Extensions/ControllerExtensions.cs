using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToeSharedLib.Interfaces;
using TicTacToeSharedLib.Utility;

namespace TicTacToeApi.Extensions
{
    public static class ControllerExtentions
    {
        public static IActionResult GenerateControllerResponse<T>(this ControllerBase controller, IRepoResponse<T> repoResponse) where T : class, IDto, new()
        {
            if (repoResponse.Success)
            {
                switch (repoResponse.RepoResponseType)
                {
                    case RepoResponseType.Created: return controller.Created("", repoResponse.Dto);
                    case RepoResponseType.Ok:
                    default: return controller.Ok(repoResponse.Dto);
                }
            }

            switch (repoResponse.RepoResponseType)
            {
                case RepoResponseType.NotFound: return controller.NotFound(repoResponse.ErrorMessage);
                case RepoResponseType.BadRequest: return controller.BadRequest(repoResponse.ErrorMessage);
                case RepoResponseType.NoContent: return controller.NoContent();
                case RepoResponseType.InternalServerError:
                default: return controller.StatusCode(StatusCodes.Status500InternalServerError, repoResponse.ErrorMessage);
            }
        }
    }
}
