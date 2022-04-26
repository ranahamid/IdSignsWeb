using Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SqlQueryRepository<T> : ISqlQueryRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public SqlQueryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetData(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<T>(query, parameters).ToList();
        }

        public int RunSqlCommand(string query, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(query, parameters);
        }

        public async Task<int> RunSqlCommandAsync(string query, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(query, parameters);
        }
    }
}
