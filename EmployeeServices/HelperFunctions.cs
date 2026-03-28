using EmployeeData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EmployeeServices
{
    public class HelperFunctions: IHelperFunctions
    { 
        public ResponseModel ValidateEmployee(EmployeeModel Model )
        {
            ResponseModel  Response = new ResponseModel();
            if (Model.EmployeeName == null)
                Response.Message = "Employee name is required.";
            if (Model.EmailAddress == null)
                Response.Message = " Employee name is required.";
            else {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!emailRegex.IsMatch(Model.EmailAddress)) 
                    Response.Message = " Invalid EmailAddress"; 
            }
            if (Model.Designation == null)
                Response.Message = " Designation  is required.";
            if (Model.DateOfBirth == null)
            {
                Response.Message = " Date Of Birth is required.";
            }
            else {
                int empAge = DateTime.Now.Year -  Model.DateOfBirth.Value.Year;
                if(empAge<18)
                    Response.Message += " Employee age must greater than 18 years."; 
            }

             
            if (Model.MobilePhone != null)
            {
                var mobileRegex = new Regex(@"^[0-9]+$");
                if (!mobileRegex.IsMatch(Model.MobilePhone)) 
                    Response.Message = " Mobile number not valid."; 
            }

            if (Response.Message == "")
                Response.Status = true; 


            return Response;
        }
    }
}
