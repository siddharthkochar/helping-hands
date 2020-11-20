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
        Task<Donor> GetAsync(DonorDto.Request request);
    }

    public class DonorRepository : BaseRepository, IDonorRepository
    {
        public DonorRepository(BloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public Task<Donor> GetAsync(DonorDto.Request request)
        {
            var donors = (from d in DbContext.Donors
                         join dc in DbContext.DonorCities on d.Id equals dc.DonorId
                         let bloodGroup = DbContext.LookupValues
                            .First(x => x.LookupTypeId == 2 && x.Value == request.BloodGroup)
                         where d.BloodGroupId == bloodGroup.Id && dc.CityId == request.CityId
                         orderby Guid.NewGuid()
                         select d).First();

            return Task.FromResult(donors);
        }
    }
}
