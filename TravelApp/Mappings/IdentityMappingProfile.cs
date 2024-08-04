using AutoMapper;
using Travel.Contracts.User.Request;
using Travel.Models;

namespace RentACar.Mappings
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<UserRegister, Korisnik>();
        }
    }
}
