using System.Collections.Generic;
using System.Threading.Tasks;
using BloodPlus.API.Models;
using BloodPlus.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloodPlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupRepository _lookupRepository;

        public LookupController(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<LookupDto.Reponse>> Get()
        {
            return await _lookupRepository.GetValuesByType();
        }
    }
}