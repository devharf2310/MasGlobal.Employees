using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using MasGlobal.Employees.DAL;
using System.Linq;

namespace MasGlobal.Employees.BL.Test
{
    [TestClass]
    public class EmployeesBLTest
    {
        [TestMethod]
        public async Task GetEmployeesTest1()
        {
            IHttpClient httpClient = new DefaultHttpClient();
            IEmployeesBL employeeBL = new EmployeesBL(httpClient);

            int? employeeId = 1;
            var employees = await employeeBL.GetEmployees(employeeId);
        }

        [TestMethod]
        public async Task GetEmployeesTest2()
        {
            IHttpClient httpClient = new DefaultHttpClient();
            IEmployeesBL employeeBL = new EmployeesBL(httpClient);

            int? employeeId = 2;
            var employees = await employeeBL.GetEmployees(employeeId);
        }

        [TestMethod]
        public async Task GetEmployeesTest3()
        {
            IHttpClient httpClient = new DefaultHttpClient();
            IEmployeesBL employeeBL = new EmployeesBL(httpClient);

            int? employeeId = 3;
            var employees = await employeeBL.GetEmployees(employeeId);
        }

        [TestMethod]
        public async Task GetEmployeesTestNull()
        {
            IHttpClient httpClient = new DefaultHttpClient();
            IEmployeesBL employeeBL = new EmployeesBL(httpClient);

            int? employeeId = null;
            var employees = await employeeBL.GetEmployees(employeeId);
        }
    }
}
