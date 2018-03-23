using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Employees.DAL
{
    public interface IHttpClient
    {
        Task<IEnumerable<T>> GetAsync<T>(Uri uri) where T : class;
        Task<IEnumerable<T>> GetAsync<T>(string uri) where T : class;
    }
}
