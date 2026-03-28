using EmployeeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTest
{
    public static class EmployeeTestData
    {
        public static EmployeeModel ValidEmployee() {
            EmployeeModel Model= new EmployeeModel();
            Model.EmployeeName = "Finny J";
            Model.EmailAddress = "john@test.com";
            Model.Designation = "Developer";
            Model.MobilePhone = "9595959564";
            Model.DateOfBirth = DateOnly.Parse("1996-06-15");
            Model.Nationality = "indian";
            Model.IsActive = true;
            return Model;
        }
        public static EmployeeModel InValidEmployeeData(EmployeeModel Model)
        { 
            Model.EmployeeName = "";
            Model.EmailAddress = "test"; 
            Model.MobilePhone = "test";
            Model.DateOfBirth = null; 
            return Model;
        }
        public static List<EmployeeModel> EmployeeListData(List<EmployeeModel> Model)
        {  
            return Model;
        }
    }
}
