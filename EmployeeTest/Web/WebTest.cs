using EmployeeData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTest.Web
{
    public class WebTest:EmployeeWebBase
    {
        [Test]
        public void Index_ShouldReturnViewWithEmployeeList()
        {
            _mockService.Setup(s => s.GetAllEmployees())
            .Returns(EmployeeTestData.EmployeeListData(new List<EmployeeModel>
            {
                new EmployeeModel { EmployeeId = 1, EmployeeName = "John", EmailAddress = "john@test.com" },
                new EmployeeModel { EmployeeId = 2, EmployeeName = "Jane", EmailAddress = "jane@test.com" }
            }));

            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.Not.Null);

            var model = result.Model as List<EmployeeModel>;
            Assert.That(model.Count, Is.EqualTo(2));
        }
        [Test]
        public void Create_ValidEmployee_ShouldRedirectToIndex()
        { 
            var employee = EmployeeTestData.ValidEmployee();
            _mockService.Setup(s => s.CreateEmployee(employee)).Returns(true);
            var result = _controller.CreateEmployee(employee) as JsonResult;

            var property = result.Value.GetType().GetProperty("status");
            var statusValue = (bool)property.GetValue(result.Value);

            Assert.That(statusValue, Is.True);
        }
        [Test]
        public void Delete_InvalidId_ShouldReturnNotFound()
        {
            var result = _controller.DeleteEmployee(2233) as JsonResult;

            var property = result.Value.GetType().GetProperty("status");
            var statusValue = (bool)property.GetValue(result.Value);

            Assert.That(statusValue, Is.False);
        }
    }
}
