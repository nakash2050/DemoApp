using System.Threading.Tasks;
using API.BAL;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBAL _employeeBAL;

        public EmployeeController(IEmployeeBAL employeeBAL)
        {
            _employeeBAL = employeeBAL;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]EmployeeDTO employee)
        {
            var employeeId = await _employeeBAL.AddEmployee(employee);
            return Ok(employeeId);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {
            var employee = await _employeeBAL.GetEmployee(employeeId);
            return Ok(employee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody]EmployeeDTO employee)
        {
            var isUpdated = await _employeeBAL.UpdateEmployee(employee);
            return Ok(isUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var isDeleted = await _employeeBAL.DeleteEmployee(employeeId);
            return Ok(isDeleted);
        }
    }
}