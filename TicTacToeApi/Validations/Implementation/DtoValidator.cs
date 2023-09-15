using FluentValidation;

namespace TicTacToeApi.Validations.Implementation
{
    public static class DtoValidator
    {

        public static bool TryValidate<T, U>(T dto, out string? error) where U : AbstractValidator<T>, new()
        {
            var validator = new U();
            var validationResult = validator.Validate(dto);

            var isValid = validationResult.IsValid;
            error = isValid ? string.Empty : validationResult.ToString();

            return isValid;
        }
    }
}
