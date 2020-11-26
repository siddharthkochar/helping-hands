using BloodPlus.API.Models;
using BloodPlus.Database;
using BloodPlus.Database.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BloodPlus.API.Repositories
{
    public interface IDonorRepository
    {
        Task<Donor> GetAsync(int cityId, int bloodGroupId);

        Task AddAsync(DonorDto.Request request);
    }

    public class DonorRepository : BaseRepository, IDonorRepository
    {
        public DonorRepository(BloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public Task<Donor> GetAsync(int cityId, int bloodGroupId)
        {
            var donors = (from d in DbContext.Donors
                       where d.BloodGroupId == bloodGroupId && d.Cities.Any(c => c.Id == cityId)
                       orderby Guid.NewGuid()
                       select d).FirstOrDefault();

            return Task.FromResult(donors);
        }
        public async Task AddAsync(DonorDto.Request request)
        {
            var donor = new Donor
            {
                Contact = request.Contact,
                Cities = DbContext.Cities.Where(x => x.Id == request.CityId).ToList(),
                BirthDate = request.BirthDate,
                BloodGroupId = request.BloodGroupId,
                GenderId = request.GenderId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                StatusId = request.StatusId
            };

            await DbContext.Donors.AddAsync(donor);
            await DbContext.SaveChangesAsync();
        }
    }
}
