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
    public class CountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountryController(
            IMapper mapper,
            ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDto>> Get()
        {
            var countries = await _countryRepository.GetAll();
            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }
    }
}