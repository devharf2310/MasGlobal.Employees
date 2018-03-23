using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Model
{
    public interface IEmployee
    {
        int id { get; set; }
        string name { get; set; }
        string contractTypeName { get; set; }
        int roleId { get; set; }
        string roleName { get; set; }
        string roleDescription { get; set; }
        decimal hourlySalary { get; set; }
        decimal monthlySalary { get; set; }
        decimal? annualSalary { get; set; }
    }
}
