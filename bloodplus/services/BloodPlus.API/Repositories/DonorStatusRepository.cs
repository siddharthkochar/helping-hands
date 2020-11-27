using BloodPlus.Database;
using BloodPlus.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodPlus.API.Repositories
{
    public interface IDonorStatusRepository
    {
        public Task<IEnumerable<DonorStatus>> Get();
    }

    public class DonorStatusRepository : BaseRepository, IDonorStatusRepository
    {
        public DonorStatusRepository(BloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<DonorStatus>> Get() 
            => await DbContext.DonorStatus.ToListAsync();
    }
}
