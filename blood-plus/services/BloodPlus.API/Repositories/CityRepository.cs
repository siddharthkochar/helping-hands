using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodPlus.Database;
using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodPlus.API.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetByState(int stateId);
    }

    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(IBloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<City>> GetByState(int stateId)
            => await DbContext.Cities
                .Where(x => x.StateId == stateId)
                .ToListAsync();
    }
}
