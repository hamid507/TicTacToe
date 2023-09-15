using FluentValidation;
using TicTacToeSharedLib.Models.Dtos;

namespace TicTacToeApi.Validations
{
    public class UserVerifyValidator : AbstractValidator<UserVerifyRequestDto>
    {
        public UserVerifyValidator()
        {
            RuleFor(verify => verify)
                .NotNull();

            RuleFor(verify => verify.Email)
                .NotEmpty();

            RuleFor(verify => verify.VerificationToken)
                .NotEmpty();
        }
    }
}
