using BloodPlus.API.Models;
using BloodPlus.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodPlus.API.Repositories
{
    public interface ILookupRepository
    {
        Task<IEnumerable<LookupDto.Reponse>> GetValues();
    }

    public class LookupRepository : BaseRepository, ILookupRepository
    {
        public LookupRepository(BloodPlusDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<LookupDto.Reponse>> GetValues() 
            => await DbContext.LookupValues
                .Select(x => new LookupDto.Reponse
                {
                    Id = x.Id,
                    Value = x.Value,
                    Type = x.LookupType.Name
                })
                .ToListAsync();
    }
}
