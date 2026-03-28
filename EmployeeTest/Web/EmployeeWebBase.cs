
using EmployeeManagement.Controllers;
using EmployeeServices.Employee;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTest.Web
{
    public class EmployeeWebBase
    {
        protected Mock<IEmployeeService> _mockService;
        protected EmployeeController _controller;

        [OneTimeSetUp]
        public void MvcSetup()
        {
            _mockService = new Mock<IEmployeeService>();
            _controller = new EmployeeController(_mockService.Object);
        }
        [OneTimeTearDown]
        public void WebCleanup()
        {
            _controller?.Dispose();    
            _mockService = null;     
        }
    }
}
