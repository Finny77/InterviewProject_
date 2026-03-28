using EmployeeData;
using EmployeeServices.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeService _employeeservice;
        public EmployeeController(IEmployeeService employeeservice)
        {
            _employeeservice = employeeservice;
        }
        public IActionResult Index()
        {
            try
            {
                var EmployeeList = _employeeservice.GetAllEmployees().ToList();
                return View(EmployeeList); 
            }
            catch (Exception ex)
            {

                return View();
            }
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        { 
            return View();
        }

        [HttpPost]
        public JsonResult CreateEmployee(EmployeeModel Model)
        {
            try
            {
                 bool CreateEmployee = _employeeservice.CreateEmployee(Model);
                return Json(new { status = CreateEmployee});

            }
            catch (Exception ex)
            {
                return Json(new { status = false }); 
            } 
        }
        [HttpGet]
        public JsonResult GetEmployeeList()
        {
            try
            {
                var EmployeeList = _employeeservice.GetAllEmployees().ToList();
                return Json(new { data = EmployeeList }); 
            }
            catch (Exception ex)
            { 
                return Json(new { status = false });
            } 
        }
        [HttpGet]
        public JsonResult GetEmployeeById(int Id)
        {
            try
            {
                var Employee = _employeeservice.GetAllEmployeeById(Id);
                return Json(new { data = Employee });

            }
            catch (Exception ex)
            { 
                return Json(new { status = false });
            }
        }
        [HttpGet]
        public JsonResult DeleteEmployee(int Id)
        {
            try
            {
                bool status = _employeeservice.DeleteEmployee(Id);
                return Json(new { status });

            }
            catch (Exception ex)
            { 
                return Json(new { status = false });
            }
        }  
    }
}
