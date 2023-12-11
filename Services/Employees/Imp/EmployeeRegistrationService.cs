using EmailLocal.Services.Employees.Result;
using Microsoft.AspNetCore.Mvc;
using MONACO_ASP.Entities;
using MONACO_ASP.Infracstructures;
using MONACO_ASP.Services.Authentication;
namespace MONACO_ASP.Services.Employees.Imp
{
    public class EmployeeRegistrationService : IEmployeeRegistrationService
    {
        private readonly ICryptographyHelper _cryptoHelper;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthenticateService _authenticateService;

        public EmployeeRegistrationService(
            ICryptographyHelper cryptoHelper,
            IEmployeeService employeeService,
            IAuthenticateService authenticateService
            )
        {
            _cryptoHelper = cryptoHelper;
            _employeeService = employeeService;
            _authenticateService = authenticateService;
        }

        public async Task<(EmployeeLoginResults, Employee?)> ValidateUserAsync(string Email, string password)
        {
            var passwordHash = _cryptoHelper.CreateHash(password);
            var user = await _employeeService.GetUserValidateAsync(Email, passwordHash);

            if (user == null)
            {
                return (EmployeeLoginResults.UserNotExist, null);
            }
            if (!user.IsActived)
            {
                return (EmployeeLoginResults.NotActive, null);
            }
            else if (user.IsDeleted)
            {
                return (EmployeeLoginResults.Deleted, null);
            }
            else if (user.IsBlocked)
            {
                return (EmployeeLoginResults.LockedOut, null);
            }

            return (EmployeeLoginResults.Successful, user);
        }

        public async Task<IActionResult> SignInCustomerAsync(Employee employee, string returnUrl, bool isPersist)
        {
            await _authenticateService.SignInAsync(employee, isPersist);

            return string.IsNullOrEmpty(returnUrl) ? new RedirectResult("Home") : new RedirectResult(returnUrl);
        }
    }
}
