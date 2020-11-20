using AutoMapper;
using BloodPlus.API.Models;
using BloodPlus.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodPlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public StatesController(IMapper mapper, IStateRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<StateDto.Response>> Get()
        {
            const int INDIA = 1;
            var states = await _stateRepository.GetByCountryAsync(INDIA);
            return _mapper.Map<IEnumerable<StateDto.Response>>(states);
        }
    }
}