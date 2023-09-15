using FluentValidation;
using TicTacToeSharedLib.Models.Dtos;

namespace TicTacToeApi.Validations
{
    public class UserForgotPasswordValidator : AbstractValidator<UserForgotPasswordRequestDto>
    {
        public UserForgotPasswordValidator()
        {
            RuleFor(reset => reset)
                .NotNull();

            RuleFor(reset => reset.Email)
                .NotEmpty();
        }
    }
}
