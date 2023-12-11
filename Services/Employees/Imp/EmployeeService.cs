using MONACO_ASP.Data;
using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Employees.Imp
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IQueryRepository<Employee> _userQuery;

        public EmployeeService(IQueryRepository<Employee> userQuery)
        {
            _userQuery = userQuery;
        }

        public async Task<Employee> GetUserValidateAsync(string Email, string password)
        {
            var user = await _userQuery.QueryFirstOrDefaultAsync((query) =>
            {

                return from employees in query
                       where
                          employees.Password == password
                          && (employees.Email == Email)
                       select employees;
            }, true);

            return user;
        }
    }
}
