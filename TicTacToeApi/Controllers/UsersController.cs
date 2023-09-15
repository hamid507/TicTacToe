using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.Data.Abstraction;
using TicTacToeApi.Extensions;
using TicTacToeSharedLib.Models.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicTacToeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo repo;

        public UsersController(IUserRepo repo)
        {
            this.repo = repo;
        }

        // POST api/Users/Register
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRegisterRequestDto dto)
        {
            var response = repo.Register(dto);
            return this.GenerateControllerResponse(response);
        }

        // POST api/Users/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginRequestDto dto)
        {
            var response = repo.Login(dto);
            return this.GenerateControllerResponse(response);
        }

        // POST api/Users/Verify
        [HttpPost("Verify")]
        public IActionResult Verify(UserVerifyRequestDto dto)
        {
            var response = repo.Verify(dto);
            return this.GenerateControllerResponse(response);
        }
    }
}
