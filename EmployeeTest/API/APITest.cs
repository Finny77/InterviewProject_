using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTest.API
{
    public class APITest:EmployeeAPITestB
    {
        [Test]
        public async Task GetAllEmployees_ShouldReturn200()
        {
            var response = await _client.GetAsync("/api/Employee/GetEmployeeList");

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }
    }
}
