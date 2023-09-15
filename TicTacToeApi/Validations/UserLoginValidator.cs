using FluentValidation;
using TicTacToeSharedLib.Models.Dtos;

namespace TicTacToeApi.Validations
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequestDto>
    {
        public UserLoginValidator()
        {
            RuleFor(login => login)
                .NotNull();

            RuleFor(login => login.Email)
                .NotEmpty();

            RuleFor(login => login.Password)
                .NotEmpty();
        }
    }
}
