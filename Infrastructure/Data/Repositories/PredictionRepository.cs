using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class PredictionRepository : EfRepository<Prediction>, IPredictionRepository
    {
        public PredictionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
