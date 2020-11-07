using AutoMapper;
using BloodPlus.API.Models;
using BloodPlus.Database.Entities;

namespace BloodPlus.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
