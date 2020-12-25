using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodPlus.API.Constants;
using BloodPlus.Database;
using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodPlus.API.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetByStateAsync(int stateId);
        Task AddAsync(IEnumerable<(string city, string state)> data);
        Task<string> GetRepresentative(int cityId, int stateId);
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

        public async Task AddAsync(IEnumerable<(string city, string state)> data)
        {
            await _stateRepository.Add(data.Select(x => x.state).Distinct());

            var cities =
                from d in data.Distinct()
                join s in DbContext.States on d.state equals s.Name
                where !DbContext.Cities.Any(x => x.Name.ToLower() == d.city.ToLower())
                select new City {Name = d.city, StateId = s.Id};

            await DbContext.Cities.AddRangeAsync(cities);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetByStateAsync(int stateId)
            => await DbContext.Cities
                .Where(x => x.StateId == stateId)
                .ToListAsync();

        public async Task<string> GetRepresentative(int cityId, int stateId)
        {
            var city = await DbContext.Cities
                .Include(x => x.State)
                .FirstOrDefaultAsync(x => x.Id == cityId && x.StateId == stateId);

            return CityRepresentative.Get(city.Name, city.State.Name);
        }
    }
}
