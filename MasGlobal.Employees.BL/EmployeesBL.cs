using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasGlobal.Employees.Model;
using MasGlobal.Employees.DAL;
using System.Configuration;

namespace MasGlobal.Employees.BL
{
    public class EmployeesBL : IEmployeesBL
    {
        IHttpClient httpClient;
        string url;

        public EmployeesBL(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
            url = ConfigurationManager.AppSettings["UrlEmployeesApi"];
        }

        public async Task<IEnumerable<IEmployee>> GetEmployees(int? employeeId)
        {
            var result = await httpClient.GetAsync<EmployeeDTO>(url);
            var employees = new List<IEmployee>();

            if (result == null || !result.Any())
                return new List<IEmployee>();

            foreach (var employee in employeeId == null ? result : result.Where(x=>x.id == employeeId))
                employees.Add(GetEmployeeByContractType(employee));

            return employees;
        }

        public Task<IEnumerable<IEmployee>> GetEmployees(int employeeId)
        {
            throw new NotImplementedException();
        }

        private IEmployee GetEmployeeByContractType(EmployeeDTO employee)
        {
            int hoursByMonth = int.Parse(ConfigurationManager.AppSettings["hoursByMonth"]);
            int monthsByYear = int.Parse(ConfigurationManager.AppSettings["monthsByYear"]);
            IEmployee contractEmployee;
            switch (employee.contractTypeName)
            {
                case "HourlySalaryEmployee":

                    contractEmployee = new HourlyContractEmployeeDTO
                    {
                        annualSalary = hoursByMonth * employee.hourlySalary * monthsByYear,
                        id = employee.id,
                        name = employee.name,
                        contractTypeName = employee.contractTypeName,
                        roleId = employee.roleId,
                        roleName = employee.roleName,
                        roleDescription = employee.roleDescription,
                        hourlySalary = employee.hourlySalary,
                        monthlySalary = employee.monthlySalary
                    };

                    return contractEmployee;

                case "MonthlySalaryEmployee":

                    contractEmployee = new MonthlyContractEmployeeDTO
                    {
                        annualSalary = employee.hourlySalary * monthsByYear,
                        id = employee.id,
                        name = employee.name,
                        contractTypeName = employee.contractTypeName,
                        roleId = employee.roleId,
                        roleName = employee.roleName,
                        roleDescription = employee.roleDescription,
                        hourlySalary = employee.hourlySalary,
                        monthlySalary = employee.monthlySalary
                    };

                    return contractEmployee;

                default:

                    return null;
            }
        }
    }
}
