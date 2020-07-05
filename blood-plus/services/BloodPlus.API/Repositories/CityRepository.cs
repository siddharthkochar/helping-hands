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
            await _stateRepository.Add(data.Select(x => x.state).Distinct());

            var cities =
                from d in data.Distinct()
                join s in DbContext.States on d.state equals s.Name
                where !DbContext.Cities.Any(x => x.Name.ToLower() == d.city.ToLower())
                select new City {Name = d.city, StateId = s.Id};

            await DbContext.Cities.AddRangeAsync(cities);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetByState(int stateId)
            => await DbContext.Cities
                .Where(x => x.StateId == stateId)
                .ToListAsync();
    }
}
