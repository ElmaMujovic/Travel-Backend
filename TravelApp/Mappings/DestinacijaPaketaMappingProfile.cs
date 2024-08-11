using AutoMapper;
using TravelApp.Contracts.DestinacijePaketa.Requests;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Mappings
{
    public class DestinacijaPaketaMappingProfile : Profile
    {
        public DestinacijaPaketaMappingProfile()
        {
            // Mapiranje iz DestinacijaPaketaCreateRequest na DestinacijaPaketa
            CreateMap<DestinacijaPaketaCreateRequest, DestinacijaPaketa>()
                .ForMember(dest => dest.Slika, opt => opt.MapFrom(src => src.Slika)); // Mapiranje putanje slike

            // Mapiranje iz DestinacijaPaketa na DestinacijaPaketaCreateRequest
            CreateMap<DestinacijaPaketa, DestinacijaPaketaCreateRequest>()
                .ForMember(dest => dest.Slika, opt => opt.MapFrom(src => src.Slika)); // Mapiranje putanje slike

            // Mapiranje iz DestinacijaPaketaUpdateRequest na DestinacijaPaketa
            CreateMap<DestinacijaPaketaUpdateRequest, DestinacijaPaketa>()
                .ForMember(dest => dest.Slika, opt => opt.MapFrom(src => src.Slika)); // Mapiranje putanje slike

            // Mapiranje iz DestinacijaPaketa na DestinacijaPaketaUpdateRequest
            CreateMap<DestinacijaPaketa, DestinacijaPaketaUpdateRequest>()
                .ForMember(dest => dest.Slika, opt => opt.MapFrom(src => src.Slika)); // Mapiranje putanje slike
        }
    }
}
