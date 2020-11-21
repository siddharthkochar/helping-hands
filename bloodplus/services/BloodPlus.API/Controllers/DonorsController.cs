using System.Threading.Tasks;
using AutoMapper;
using BloodPlus.API.Models;
using BloodPlus.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloodPlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDonorRepository _donorRepository;

        public DonorsController(IMapper mapper, IDonorRepository donorRepository)
        {
            _mapper = mapper;
            _donorRepository = donorRepository;
        }

        [HttpGet]
        public async Task<DonorDto.Response> Get([FromQuery] int cityId, [FromQuery] string bloodGroup)
        {
            var donor = await _donorRepository.GetAsync(cityId, bloodGroup);
            return _mapper.Map<DonorDto.Response>(donor);
        }
    }
}