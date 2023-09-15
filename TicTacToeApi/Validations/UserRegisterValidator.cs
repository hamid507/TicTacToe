using FluentValidation;
using TicTacToeApi.Extensions;
using TicTacToeSharedLib.Models.Dtos;

namespace TicTacToeApi.Validations
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterRequestDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user)
                .NotNull();

            RuleFor(user => user.NickName)
                .NotEmpty()
                .Length(3, 15)
                .Must(nickName => char.IsLetter(nickName[0]))
                .WithMessage("Must start with a letter")
                .Matches(nickName => @"^[a-zA-Z0-9_]+$")
                .WithMessage("Must contain only letters, numbers and underscore");

            RuleFor(user => user.Email)
                .NotEmpty()
                .Must(email => email.IsValidEmail());

            RuleFor(user => user.Password)
                .NotEmpty()
                .NotEqual(user => user.NickName)
                .Length(3, 20);
        }
    }
}
