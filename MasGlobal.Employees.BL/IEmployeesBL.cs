using MasGlobal.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Employees.BL
{
    public interface IEmployeesBL
    {
        Task<IEnumerable<IEmployee>> GetEmployees(int? employeeId);
    }
}
