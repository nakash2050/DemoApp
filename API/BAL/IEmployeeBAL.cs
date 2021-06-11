using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.BAL
{
    public interface IEmployeeBAL
    {
        Task<int> AddEmployee(EmployeeDTO employee);
        Task<Employee> GetEmployee(int employeeId);
        Task<bool> UpdateEmployee(EmployeeDTO employee);
        Task<bool> DeleteEmployee(int employeeId);
        Task<IReadOnlyList<Employee>> GetAllEmployees();
    }
}