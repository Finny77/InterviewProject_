using EmployeeData;
using EmployeeData.EmployeeDBContext;
using System;
using System.Collections.Generic;
using System.Text; 

namespace EmployeeServices.Employee
{
    public class EmployeeService : IEmployeeService
    {
        public readonly EmployeeDBContext _employeeContext;
        public EmployeeService(EmployeeDBContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            var data = _employeeContext.Employee.ToList();
            return data;
        }
        public EmployeeModel GetAllEmployeeById(int Id)
        {
            var data = _employeeContext.Employee.Where(x => x.EmployeeId == Id).FirstOrDefault();
            return data;
        }
        public bool CreateEmployee(EmployeeModel Model)
        {
            try
            {
                Model.CreatedDate = DateTime.Now;
                _employeeContext.Employee.Add(Model);
                if (Model.EmployeeId > 0)
                    _employeeContext.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _employeeContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool DeleteEmployee(int Id)
        {
            try
            {
                var emp = _employeeContext.Employee.Where(x => x.EmployeeId == Id).FirstOrDefault();
                if (emp != null)
                {
                    _employeeContext.Employee.Remove(emp);
                    _employeeContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
