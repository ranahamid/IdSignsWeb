using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class ChannelRepository : EfRepository<Channel>, IChannelRepository
    {
        public ChannelRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
