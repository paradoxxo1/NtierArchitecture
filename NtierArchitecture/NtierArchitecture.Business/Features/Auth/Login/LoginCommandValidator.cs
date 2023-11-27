using FluentValidation;

namespace NtierArchitecture.Business.Features.Auth.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p=> p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı ve e mail boş olmaz");
            RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre alanı boş bırakılamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük harf içermelidir");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük harf içermelidir");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1 adet özel karakter içermelidir");
        }
    }
}
