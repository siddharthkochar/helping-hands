using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodPlus.Database;
using BloodPlus.Database.Entities;

namespace BloodPlus.API.Repositories
{
    public interface IStateRepository
    {
        Task Add(IEnumerable<string> stateNames);
    }

    public class StateRepository : BaseRepository, IStateRepository
    {
        public StateRepository(BloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task Add(IEnumerable<string> stateNames)
        {
            var statesToAdd = (from stateName in stateNames
                               let exists = DbContext.States.FirstOrDefault(x => x.Name == stateName)
                               where exists == null
                               select new State { CountryId = 1, Name = stateName }).ToList();

            if (statesToAdd == null)
                return;

            await DbContext.States.AddRangeAsync(statesToAdd);
            await DbContext.SaveChangesAsync();
        }
    }
}
