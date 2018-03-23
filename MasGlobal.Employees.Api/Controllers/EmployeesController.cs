using MasGlobal.Employees.BL;
using MasGlobal.Employees.DAL;
using MasGlobal.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MasGlobal.Employees.Api.Controllers
{
    public class EmployeesController : ApiController
    {
        IEmployeesBL employeeBL;
        IHttpClient httpClient;

        EmployeesController()
        {
            httpClient = new DefaultHttpClient();
            employeeBL = new EmployeesBL(httpClient);
        }

        public async Task<HttpResponseMessage> Get(int? employeeId = null)
        {
            var employees = await employeeBL.GetEmployees(employeeId);

            if(employees == null || !employees.Any())
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees not found");

            return Request.CreateResponse(HttpStatusCode.OK, employees);
        }        
    }
}
