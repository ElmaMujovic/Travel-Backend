using AutoMapper;
using Travel.Contracts.Komentar.Request;
using Travel.Models;

namespace Travel.Mappings
{
    public class KomentarMappingProfile : Profile
    {
        public KomentarMappingProfile()
        {
            CreateMap<KomentarCreateRequest, Komentar>();
        }
    }
}
