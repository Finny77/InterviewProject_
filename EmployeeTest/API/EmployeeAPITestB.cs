using EmployeeManagementAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTest.API
{
    public class EmployeeAPITestB
    {
        protected HttpClient _client;
        protected WebApplicationFactory<ApiProgram> _factory;

        [OneTimeSetUp]
        public void ApiSetup()
        {
            _factory = new WebApplicationFactory<ApiProgram>();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void ApiCleanup()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}
