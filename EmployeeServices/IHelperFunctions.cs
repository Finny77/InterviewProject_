using EmployeeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeServices
{
    public interface IHelperFunctions
    {
        public ResponseModel ValidateEmployee(EmployeeModel Model);
    }
}
