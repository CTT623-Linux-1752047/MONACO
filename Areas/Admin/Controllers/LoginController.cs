using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MONACO_ASP.Models.Auth;
using MONACO_ASP.Services.Employees;
using EmailLocal.Services.Employees.Result;
using MONACO_ASP.Services.Employees.Imp;

namespace MONACO_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // region Service
        private readonly IEmployeeRegistrationService _employeeRegistrationService;
        // end region

        public LoginController(
            IEmployeeRegistrationService employeeRegistrationService)
        {
            _employeeRegistrationService = employeeRegistrationService;
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            
            if (claimUser.Identity.IsAuthenticated)
            {
				return Redirect("/Admin/Home");
			}
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl, LoginModel model)
        {

            var (loginResult, employee) = await _employeeRegistrationService.ValidateUserAsync(model.Email, model.Password);

            switch (loginResult)
            {
                case EmployeeLoginResults.Successful:
                    return await _employeeRegistrationService.SignInCustomerAsync(employee, returnUrl, model.RememberMe);

                //case UserLoginResults.UserNotExist:
                //    ModelState.AddModelError("", await _localizationService.GetResourceAsync("account.login.wrongcredentials.customernotexist"));
                //    break;

                //case UserLoginResults.WrongPassword:
                //    ModelState.AddModelError("", await _localizationService.GetResourceAsync("account.login.wrongcredentials.wrongpassword"));
                //    break;

                //case UserLoginResults.NotActive:
                //    ModelState.AddModelError("", await _localizationService.GetResourceAsync("account.login.wrongcredentials.notactive"));
                //    break;

                //case UserLoginResults.Deleted:
                //    ModelState.AddModelError("", await _localizationService.GetResourceAsync("account.login.wrongcredentials.deleted"));
                //    break;

                //case UserLoginResults.LockedOut:
                //    ModelState.AddModelError("", await _localizationService.GetResourceAsync("account.login.wrongcredentials.lockedout"));
                //    break;
            }

            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return LocalRedirect("/");
        }
    }
}
