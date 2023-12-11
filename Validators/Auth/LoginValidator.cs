using FluentValidation;
using MONACO_ASP.Models.Auth;

namespace MONACO_ASP.Validators.Auth
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {

        //public LoginValidator(ILocalizationService localizationService)
        //{
        //    RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResourceAsync("common.field.username.required").Result);

        //    RuleFor(x => x.Password).NotEmpty().WithMessage(localizationService.GetResourceAsync("common.field.password.required").Result);
        //}
    }
}
