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
    public class DonorStatusController : ControllerBase
    {
        private readonly IDonorStatusRepository _donorStatusRepository;
        private readonly IMapper _mapper;

        public DonorStatusController(IDonorStatusRepository donorStatusRepository, IMapper mapper)
        {
            _donorStatusRepository = donorStatusRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DonorStatusDto.Response>> Get()
        {
            var statuses = await _donorStatusRepository.Get();
            return _mapper.Map<IEnumerable<DonorStatusDto.Response>>(statuses);
        }
    }
}