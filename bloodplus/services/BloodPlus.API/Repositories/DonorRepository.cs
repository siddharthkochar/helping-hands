using BloodPlus.API.Models;
using BloodPlus.Database;
using BloodPlus.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BloodPlus.API.Repositories
{
    public interface IDonorRepository
    {
        Task<Donor> GetAsync(int cityId, string bloodGroup);
    }

    public class DonorRepository : BaseRepository, IDonorRepository
    {
        public DonorRepository(BloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public Task<Donor> GetAsync(int cityId, string bloodGroup)
        {
            var donors = (from d in DbContext.Donors
                         join dc in DbContext.DonorCities on d.Id equals dc.DonorId
                         let bloodGroupValue = DbContext.LookupValues
                            .First(x => x.LookupTypeId == 2 && x.Value == bloodGroup)
                         where d.BloodGroupId == bloodGroupValue.Id && dc.CityId == cityId
                         orderby Guid.NewGuid()
                         select d).First();

            return Task.FromResult(donors);
        }
    }
}
