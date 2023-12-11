using Microsoft.AspNetCore.Authentication;
using MONACO_ASP.Entities;
using MONACO_ASP.Services.Authentication;
using System.Security.Claims;

namespace MONACO_ASP.Services.Authenticate.Imp
{
    public class AuthenticateService : IAuthenticateService
    {
        #region Fields
        private readonly IHttpContextAccessor _contextAccessor;
        //private readonly WebSettings _webSettings;
        #endregion

        #region CTor
        public AuthenticateService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            //_webSettings = webSettings;
        }
        #endregion

        public async Task SignInAsync(Employee employee, bool isPersistent)
        {
            //create principal for the current authentication scheme
            var userIdentity = new ClaimsIdentity("Authentication");
            userIdentity.AddClaim(new Claim(ClaimTypes.Name, employee.Email, ClaimValueTypes.String, "Cookies"));
            userIdentity.AddClaim(new Claim(ClaimTypes.Email, employee.Email, ClaimValueTypes.Email, "Cookies"));
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            //set value indicating whether session is persisted and the time at which the authentication was issued
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.UtcNow
            };

            //sign in
            await _contextAccessor.HttpContext?.SignInAsync("Cookies", userPrincipal, authenticationProperties);
        }

        public async Task SignOutAsync()
        {

        }
    }
}
