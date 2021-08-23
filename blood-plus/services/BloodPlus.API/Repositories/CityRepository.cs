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
        Task Add(IEnumerable<(string city, string state)> data);
    }

    public class CityRepository : BaseRepository, ICityRepository
    {
        private readonly IStateRepository _stateRepository;
        public CityRepository(
            BloodPlusDatabaseContext dbContext,
            IStateRepository stateRepository) : base(dbContext)
        {
            _stateRepository = stateRepository;
        }

        public async Task Add(IEnumerable<(string city, string state)> data)
        {
            var distinctStates = data.Select(x => x.state).Distinct();
            await _stateRepository.Add(distinctStates);

            var citiesToAdd = (from d in data.Distinct()
                               let city = DbContext.Cities.FirstOrDefault(x => x.Name == d.city)
                               where city == null
                               let state = DbContext.States.First(x => x.Name == d.state)
                               select new City { Name = d.city, StateId = state.Id }).ToList();

            if (citiesToAdd == null)
                return;

            await DbContext.Cities.AddRangeAsync(citiesToAdd);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetByState(int stateId)
            => await DbContext.Cities
                .Where(x => x.StateId == stateId)
                .ToListAsync();
    }
}
