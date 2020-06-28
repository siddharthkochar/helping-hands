using BloodPlus.Database;

namespace BloodPlus.API.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly BloodPlusDatabaseContext DbContext;

        protected BaseRepository(BloodPlusDatabaseContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
