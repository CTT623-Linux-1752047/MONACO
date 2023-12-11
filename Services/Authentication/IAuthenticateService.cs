using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Authentication
{
    public interface IAuthenticateService
    {
        Task SignInAsync(Employee employee, bool isPersistent);

        Task SignOutAsync();
    }
}
