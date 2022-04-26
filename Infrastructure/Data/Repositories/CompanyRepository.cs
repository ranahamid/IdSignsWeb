using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class CompanyRepository : EfRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
