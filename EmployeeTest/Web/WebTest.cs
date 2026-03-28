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
    }
}
