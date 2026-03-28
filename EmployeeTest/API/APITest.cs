using Newtonsoft.Json;
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
        [Test]
        public async Task CreateEmployee_ValidData_ShouldReturnSuccess()
        { 
            var employee = EmployeeTestData.ValidEmployee();
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
             
            var response = await _client.PostAsync("/api/Employee/CreateEmployee", content);
            var result = JsonConvert.DeserializeObject<dynamic>(
                               await response.Content.ReadAsStringAsync());
             
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That((bool)result.status, Is.True);
        }

    }
}
