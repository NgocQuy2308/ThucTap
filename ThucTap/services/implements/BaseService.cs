using ThucTap.Entity;

namespace ThucTap.services.implements
{
    public class BaseService
    {
        public readonly AppDbContext _dbContext;
        public BaseService()
        {
            _dbContext = new AppDbContext();
        }
    }
}
