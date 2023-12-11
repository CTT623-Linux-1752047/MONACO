using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Employees
{
    public interface IEmployeeService
    {
        Task<Employee> GetUserValidateAsync(string username, string password);
    }
}
