﻿using System.Collections.Generic;
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
            var states =
                from stateName in stateNames
                where !DbContext.States.Any(x=> x.Name.ToLower() == stateName.ToLower())
                select new State {CountryId = 1, Name = stateName};

            await DbContext.States.AddRangeAsync(states);
            await DbContext.SaveChangesAsync();
        }
    }
}
