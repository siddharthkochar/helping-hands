using BloodPlus.Database;

namespace BloodPlus.API.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IBloodPlusDatabaseContext DbContext;

        protected BaseRepository(IBloodPlusDatabaseContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
