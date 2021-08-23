using System.Collections.Generic;
using BloodPlus.Database;
using BloodPlus.Database.Entities;
using System.Linq;
using System.Threading.Tasks;
using BloodPlus.Services;
using BloodPlus.Services.Model;
using RestSharp;

namespace BloodPlus.API.Repositories
{
    public interface IMigrationRepository
    {
        Task MigrateStates();
        Task MigrateCities();
        Task MigrateDuplicateDonors();
        Task MigrateDuplicateDonorCities();
    }

    public class MigrationRepository : BaseRepository, IMigrationRepository
    {
        private readonly bloodplusoldContext _oldDbContext = new bloodplusoldContext();
        private readonly ICityRepository _cityRepository;
        private readonly IStateRepository _stateRepository;
        private readonly GeoDB geo = new GeoDB();

        public MigrationRepository(BloodPlusDatabaseContext dbContext,
            ICityRepository cityRepository,
            IStateRepository stateRepository) : base(dbContext)
        {
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
        }

        public async Task MigrateDuplicateDonors()
        {
            var duplicateDonors =
                (from d in _oldDbContext.OldDonors
                 let duplicateContact =
                     from dup in _oldDbContext.OldDonors
                     where (dup.Contact.StartsWith("6") || dup.Contact.StartsWith("7") ||
                            dup.Contact.StartsWith("8") || dup.Contact.StartsWith("9"))
                           &&
                           dup.Contact.Length == 10
                     group dup by dup.Contact
                     into grp
                     where grp.Count() > 1
                     select grp.Key
                 where duplicateContact.Contains(d.Contact)
                 orderby d.Contact
                 select new
                 {
                     d.Name,
                     d.Age,
                     d.Gender,
                     d.Bloodgroup,
                     d.Contact,
                     d.Availability
                 }).ToList();

            var donors =
                from d in duplicateDonors
                join glv in DbContext.LookupValues on d.Gender equals glv.Value
                join blv in DbContext.LookupValues on d.Bloodgroup equals blv.Value
                join alv in DbContext.LookupValues on d.Availability equals alv.Value
                where glv.LookupTypeId == 1 && blv.LookupTypeId == 2 && alv.LookupTypeId == 3
                group d by new
                {
                    d.Name,
                    d.Age,
                    GenderId = glv.Id,
                    BloodGroupId = blv.Id,
                    d.Contact,
                    StatusId = alv.Id
                }
                into grp
                select new Donor
                {
                    Age = grp.Key.Age,
                    Name = grp.Key.Name,
                    Contact = grp.Key.Contact,
                    BloodGroupId = grp.Key.BloodGroupId,
                    StatusId = grp.Key.StatusId,
                    GenderId = grp.Key.GenderId
                };

            await DbContext.Donors.AddRangeAsync(donors);
            await DbContext.SaveChangesAsync();
        }

        public async Task MigrateDuplicateDonorCities()
        {
            var donors = DbContext.Donors.Select(x => new { x.Id, x.Contact }).ToList();

            var duplicateDonors =
                (from d in _oldDbContext.OldDonors
                 join c in _oldDbContext.Cities on d.City equals c.Id
                 join s in _oldDbContext.States on d.State equals s.Id
                 let duplicateContact =
                     from dup in _oldDbContext.OldDonors
                     where (dup.Contact.StartsWith("6") || dup.Contact.StartsWith("7") ||
                            dup.Contact.StartsWith("8") || dup.Contact.StartsWith("9"))
                           &&
                           dup.Contact.Length == 10
                     group dup by dup.Contact
                     into grp
                     where grp.Count() > 1
                     select grp.Key
                 where duplicateContact.Contains(d.Contact)
                 orderby d.Contact
                 select new
                 {
                     d.Contact,
                     City = c.Name,
                     State = s.Name
                 }).ToList();

            var donorCities =
                from donor in donors
                join duplicateDonor in duplicateDonors on donor.Contact equals duplicateDonor.Contact
                join c in DbContext.Cities on duplicateDonor.City equals c.Name
                join s in DbContext.States on duplicateDonor.State equals s.Name
                where c.StateId == s.Id
                select new DonorCity { CityId = c.Id, StateId = s.Id, DonorId = donor.Id };

            await DbContext.DonorCities.AddRangeAsync(donorCities);
            await DbContext.SaveChangesAsync();
        }

        public async Task MigrateAllDonors()
        {
            var donors = from d in _oldDbContext.OldDonors
                         join c in _oldDbContext.Cities on d.City equals c.Id
                         join s in _oldDbContext.States on d.State equals s.Id
                         join glv in DbContext.LookupValues on d.Gender equals glv.Value
                         join blv in DbContext.LookupValues on d.Bloodgroup equals blv.Value
                         join alv in DbContext.LookupValues on d.Availability equals alv.Value

                         where 
                            (d.Contact.StartsWith("6") || d.Contact.StartsWith("7") || d.Contact.StartsWith("8") || d.Contact.StartsWith("9"))
                            && glv.LookupTypeId == 1 && blv.LookupTypeId == 2 && alv.LookupTypeId == 3
                            && d.Contact != "9826600940"
                         select new
                         {
                             Name = d.Name,
                             GenderId = glv.Id,
                             BloodGroupId = blv.Id,
                             StatusId = alv.Id,
                             Age = d.Age,
                             Contact = d.Contact
                         };
        }

        public async Task MigrateStates()
        {
            string next = string.Empty;
            while (true)
            {
                var regions = geo.GetRegions("IN", next);
                var states = regions.Data.Data.Select(x => x.Name);
                await _stateRepository.Add(states);

                var url = regions.Data.Links.FirstOrDefault(x => x.Rel == "next");
                if (url != null)
                {
                    next = url.Href;
                    continue;
                }

                break;
            }
        }

        public async Task MigrateCities()
        {
            var cityStates = new List<(string Name, string Region)>();
            await foreach (var regions in geo.GetCities())
            {
                if (regions.Name == null || regions.Region == null)
                    continue;

                cityStates.Add((regions.Name, regions.Region));

                if (cityStates.Count >= 10)
                {
                    await _cityRepository.Add(cityStates);
                    cityStates.Clear();
                }
            }
        }
    }
}
