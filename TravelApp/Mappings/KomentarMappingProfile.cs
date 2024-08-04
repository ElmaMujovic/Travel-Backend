using AutoMapper;
using TravelApp.Contracts.Komentar.Request;
using TravelApp.Models;

namespace TravelApp.Mappings
{
    public class KomentarMappingProfile : Profile
    {
        public KomentarMappingProfile()
        {
            CreateMap<KomentarCreateRequest, Komentar>();
        }
    }
}
