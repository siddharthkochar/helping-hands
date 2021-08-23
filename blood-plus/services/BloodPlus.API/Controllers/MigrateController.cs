using System.Threading.Tasks;
using BloodPlus.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloodPlus.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MigrateController : ControllerBase
    {
        private readonly IMigrationRepository _migrationRepository;

        public MigrateController(IMigrationRepository migrationRepository)
        {
            _migrationRepository = migrationRepository;
        }

        [HttpGet]
        public async Task State() => await _migrationRepository.MigrateStates();

        [HttpGet]
        public async Task City() => await _migrationRepository.MigrateCities();

        [HttpGet]
        public async Task Donors() => await _migrationRepository.MigrateDuplicateDonors();

        [HttpGet]
        public async Task DonorCities() => await _migrationRepository.MigrateDuplicateDonorCities();
    }
}