using AutoMapper;
using TravelApp.Contracts.User.Request;
using TravelApp.Contracts.User.Response;
using TravelApp.Models;

namespace TravelApp.Mappings
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<UserRegister, Korisnik>();

            CreateMap<Korisnik, UserResponse>();

            CreateMap<UpdateUserRequest, Korisnik>();

        }
    }
}
