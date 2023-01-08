using EmployeeCrud.Core.DTO;
using EmployeeCrud.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmplyeeCrud.API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : ControllerBase
        {
            public readonly IEmployeeService _employeeService;
            public EmployeeController(IEmployeeService employeeService)
            {
               _employeeService= employeeService;
            }

            /// <summary>
            /// Get the list of Employee
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public async Task<IActionResult> GetEmployeeList()
            {
                var EmployeeDetailsList = await _employeeService.GetAllEmployees();
                if (EmployeeDetailsList == null)
                {
                    return NotFound();
                }
                return Ok(EmployeeDetailsList);
            }

            /// <summary>
            /// Get Employee by id
            /// </summary>
            /// <param name="EmployeeId"></param>
            /// <returns></returns>
            [HttpGet("{EmployeeId}")]
            public async Task<IActionResult> GetEmployeeById(int EmployeeId)
            {
                var EmployeeDetails = await _employeeService.GetEmployeeById(EmployeeId);

                if (EmployeeDetails != null)
                {
                    return Ok(EmployeeDetails);
                }
                else
                {
                    return BadRequest();
                }
            }

            /// <summary>
            /// Add a new Employee
            /// </summary>
            /// <param name="EmployeeDetails"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task<IActionResult> CreateEmployee(EmployeeDto EmployeeDetails)
            {
                var isEmployeeCreated = await _employeeService.CreateEmployee(EmployeeDetails);

                if (isEmployeeCreated)
                {
                    return Ok(isEmployeeCreated);
                }
                else
                {
                    return BadRequest();
                }
            }

            /// <summary>
            /// Update the Employee
            /// </summary>
            /// <param name="EmployeeDetails"></param>
            /// <returns></returns>
            [HttpPut]
            public async Task<IActionResult> UpdateEmployee(EmployeeDto EmployeeDetails)
            {
                if (EmployeeDetails != null)
                {
                    var isEmployeeCreated = await _employeeService.UpdateEmployee(EmployeeDetails);
                    if (isEmployeeCreated)
                    {
                        return Ok(isEmployeeCreated);
                    }
                    return BadRequest();
                }
                else
                {
                    return BadRequest();
                }
            }

            /// <summary>
            /// Delete Employee by id
            /// </summary>
            /// <param name="EmployeeId"></param>
            /// <returns></returns>
            [HttpDelete("{EmployeeId}")]
            public async Task<IActionResult> DeleteEmployee(int EmployeeId)
            {
                var isEmployeeCreated = await _employeeService.DeleteEmployee(EmployeeId);

                if (isEmployeeCreated)
                {
                    return Ok(isEmployeeCreated);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }

