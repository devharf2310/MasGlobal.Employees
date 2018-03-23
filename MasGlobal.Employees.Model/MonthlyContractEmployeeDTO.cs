using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Model
{
    public class MonthlyContractEmployeeDTO : EmployeeDTO, IEmployee
    {
        public decimal? annualSalary { get; set; }
    }
}
