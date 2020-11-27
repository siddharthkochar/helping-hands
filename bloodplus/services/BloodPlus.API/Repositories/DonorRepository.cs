﻿using BloodPlus.API.Models;
using BloodPlus.Database;
using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;
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
            var donor = DbContext.Donors
                .Include(x => x.Cities)
                .FirstOrDefault(x => x.Contact == request.Contact);

            if (donor == null)
            {
                await DbContext.Donors.AddAsync(new Donor
                {
                    Contact = request.Contact,
                    Cities = DbContext.Cities.Where(x => x.Id == request.CityId).ToList(),
                    BirthDate = request.BirthDate,
                    BloodGroupId = request.BloodGroupId,
                    GenderId = request.GenderId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DonorStatus = DbContext.DonorStatus.First(x => x.Id == request.StatusId)
                });

                await DbContext.SaveChangesAsync();
                return;
            }

            var cityExists = donor.Cities.Any(x => x.Id == request.CityId);

            if (!cityExists)
            {
                var cityToAdd = await DbContext.Cities.FirstAsync(x => x.Id == request.CityId);
                donor.Cities.Add(cityToAdd);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
