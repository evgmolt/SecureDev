using AutoMapper;
using DebetCards.Models;

namespace DebetCards.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardForReport>()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("CardNumber", opt => opt.MapFrom(c => c.CardNumber.ToString()))
                .ForMember("CVC", opt => opt.MapFrom(c => c.CVC.ToString().PadLeft(3, '0')))
                .ForMember("ValidUntil", opt => opt.MapFrom(c => 
                    c.ValidUntilMonth.ToString().PadLeft(2, '0') + "/" + 
                    c.ValidUntilYear.ToString().PadLeft(2, '0')));
        }
    }
}
