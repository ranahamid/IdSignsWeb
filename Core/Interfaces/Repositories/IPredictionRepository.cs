using Core.Entities;

namespace Core.Interfaces.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPredictionRepository : IRepository<Prediction>, IAsyncRepository<Prediction>
    {
    }
}
