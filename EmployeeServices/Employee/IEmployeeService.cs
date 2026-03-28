using EmployeeData;
using System;
using System.Collections.Generic;
using System.Text; 
namespace EmployeeServices.Employee
{
    public interface IEmployeeService
    {
        public  List<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetAllEmployeeById(int Id);
        public bool CreateEmployee(EmployeeModel Model);
        public bool DeleteEmployee(int Id);
    }
}
