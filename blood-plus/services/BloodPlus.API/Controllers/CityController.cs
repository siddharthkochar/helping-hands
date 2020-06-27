using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BloodPlus.API.Models;
using BloodPlus.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloodPlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public CityController(
            IMapper mapper,
            ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        [HttpGet("{stateId}")]
        public async Task<IEnumerable<CityDto>> Get(int stateId)
        {
            var cities = await _cityRepository.GetByState(stateId);
            return _mapper.Map<IEnumerable<CityDto>>(cities);
        }
    }
}