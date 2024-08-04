using AutoMapper;
using TravelApp.Contracts.User.Request;
using TravelApp.Models;

namespace TravelApp.Mappings
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<UserRegister, Korisnik>();
        }
    }
}
