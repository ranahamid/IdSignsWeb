using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ISqlQueryRepository<T> where T : class
    {
        List<T> GetData(string query, params object[] parameters);

        int RunSqlCommand(string query, params object[] parameters);

        Task<int> RunSqlCommandAsync(string query, params object[] parameters);
    }
}
