using System.Collections.Generic;
using System.Threading.Tasks;
using BloodPlus.Database;
using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodPlus.API.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();
    }

    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(IBloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Country>> GetAll()
            => await DbContext.Countries.ToListAsync();
    }
}
