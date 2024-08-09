using AutoMapper;
using TravelApp.Contracts.Paketi.Requests;
using TravelApp.Models;

namespace TravelApp.Mappings
{
    public class PaketMappingProfile : Profile
    {
        public PaketMappingProfile()
        {
            // Mapiranje iz PaketiCreateRequests na Paket
            CreateMap<PaketiCreateRequests, Paket>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.StringPath.FileName)); // Mapiranje samo naziva fajla ili drugog relevantnog atributa

            // Mapiranje iz Paket na PaketiCreateRequests
            CreateMap<Paket, PaketiCreateRequests>()
                .ForMember(dest => dest.StringPath, opt => opt.Ignore()); // Ignorišemo ako ne koristimo direktno

            // Mapiranje iz PaketiUpdateRequest na Paket
            CreateMap<PaketiUpdateRequest, Paket>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.StringPath.FileName)); // Mapiranje samo naziva fajla ili drugog relevantnog atributa

            // Mapiranje iz Paket na PaketiUpdateRequest
            CreateMap<Paket, PaketiUpdateRequest>()
                .ForMember(dest => dest.StringPath, opt => opt.Ignore()); 
        }
    }
}
