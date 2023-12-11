using EmailLocal.Services.Employees.Result;
using Microsoft.AspNetCore.Mvc;
using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Employees
{
    public interface IEmployeeRegistrationService
    {
        Task<(EmployeeLoginResults, Employee?)> ValidateUserAsync(string Email, string password);

        Task<IActionResult> SignInCustomerAsync(Employee employee, string returnUrl, bool isPersist = false);
    }
}
