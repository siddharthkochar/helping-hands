using AutoMapper;
using BloodPlus.API.Models;
using BloodPlus.Database.Entities;

namespace BloodPlus.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto.Response>().ReverseMap();
            CreateMap<State, StateDto.Response>().ReverseMap();
            CreateMap<Donor, DonorDto.Response>().ReverseMap();
            CreateMap<LookupValue, LookupDto.Reponse>().ReverseMap();
        }
    }
}
