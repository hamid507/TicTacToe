using FluentValidation;
using TicTacToeSharedLib.Models.Dtos;

namespace TicTacToeApi.Validations
{
    public class UserResetPasswordValidator : AbstractValidator<UserResetPasswordRequestDto>
    {
        public UserResetPasswordValidator()
        {
            RuleFor(verify => verify)
                .NotNull();

            RuleFor(verify => verify.Email)
                .NotEmpty();

            RuleFor(verify => verify.PasswordResetToken)
                .NotEmpty();
        }
    }
}
