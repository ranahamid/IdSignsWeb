using Core.Entities;

namespace Core.Interfaces.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompanyRepository : IRepository<Company>, IAsyncRepository<Company>
    {
    }
}
