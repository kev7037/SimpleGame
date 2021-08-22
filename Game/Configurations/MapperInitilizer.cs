using AutoMapper;
using Game.Data;
using Game.DTOs;

namespace Game.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<GameData, GameDataDto>().ReverseMap();
        }
    }
}
