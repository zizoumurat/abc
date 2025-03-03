using FluentValidation;
using porTIEVserver.Application.Globals;

namespace porTIEVserver.Application.Features.Admin.Auth.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            if (Parameters.RequiredLengthUserName > 0)
                RuleFor(p => p.EmailOrUserName).MinimumLength(Parameters.RequiredLengthUserName) // "Kullanıcı adı ya da mail bilgisi en az 3 karakter olmalıdır"
                .WithMessage(Messages.MSG_RequiredLengthUserName.Replace("{RequiredLengthUserName}", Parameters.RequiredLengthUserName.ToString()));
            if (Parameters.RequiredLengthPassword > 0)
                RuleFor(p => p.Password).MinimumLength(Parameters.RequiredLengthPassword) // "Şifre en az 1 karakter olmalıdır"
                .WithMessage(Messages.MSG_RequiredLengthPassword.Replace("{RequiredLengthPassword}", Parameters.RequiredLengthPassword.ToString()));
        }
    }
}
