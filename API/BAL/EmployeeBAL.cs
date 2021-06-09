using System.Threading.Tasks;
using API.DAL;
using API.DTO;
using API.Entities;

namespace API.BAL
{
    public class EmployeeBAL : IEmployeeBAL
    {
        private readonly DataContext _context;

        public EmployeeBAL(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployee(EmployeeDTO employee)
        {
            var empl = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Designation = employee.Designation,
                Salary = employee.Salary
            };

            _context.Employees.Add(empl);
            await _context.SaveChangesAsync();

            return empl.Id;

        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            return employee;
        }

        public async Task<bool> UpdateEmployee(EmployeeDTO employee)
        {
            var validEmp = await _context.Employees.FindAsync(employee.Id);

            if (validEmp != null)
            {
                validEmp.FirstName = employee.FirstName;
                validEmp.LastName = employee.LastName;
                validEmp.Designation = employee.Designation;
                validEmp.Salary = employee.Salary;

                _context.Employees.Update(validEmp);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var validEmp = await _context.Employees.FindAsync(employeeId);

            if (validEmp != null)
            {
                _context.Employees.Remove(validEmp);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}