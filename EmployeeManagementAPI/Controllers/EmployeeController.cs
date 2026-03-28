using EmployeeData;
using EmployeeServices;
using EmployeeServices.Employee;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        public readonly IHelperFunctions _helperService;
        public  EmployeeController(IEmployeeService employeeService, IHelperFunctions helperService)
        {
            _employeeService=employeeService;
            _helperService = helperService;
        }
        [HttpGet("GetEmployeeList")]
        public IActionResult GetEmployeeList()
        {
            try
            {
                var employeeList = _employeeService.GetAllEmployees();
                return Ok(employeeList);

            }
            catch (Exception)
            {
                return Ok(new { status = false, message = "Error while getting data." });
            }
        }
        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee(EmployeeModel Model)
        {
            try
            {
                var Validate= _helperService.ValidateEmployee(Model);
                if(Validate.Status==false)
                    return Ok(new { status = Validate.Status, message = Validate.Message });
                 
                bool CreateEmployee = _employeeService.CreateEmployee(Model);
                return Ok(new { status = CreateEmployee,message= CreateEmployee==true? "Employee created successfully!":"Error while adding." });

            }
            catch (Exception ex)
            {
                return Ok(new { status =false, message =   "Error while adding." });

            } 
        }
        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(int Id)
        {
            try
            {

                var Employee = _employeeService.GetAllEmployeeById(Id);
                return Ok(new { data = Employee });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, message = "Error while getting data." });
            }
        }
        [HttpGet("DeleteEmployee")]
        public IActionResult DeleteEmployee(int Id)
        {
            try
            {

                bool status = _employeeService.DeleteEmployee(Id);
                return Ok(new { status });
            }
            catch (Exception ex)
            { 
                return Ok(new { status = false, message = "Error while deleting data." });
            }
        }
    }
}
