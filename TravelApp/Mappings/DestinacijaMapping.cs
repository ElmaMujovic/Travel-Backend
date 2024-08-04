using AutoMapper;
using TravelApp.Contracts.Destinacija.Request;
using TravelApp.Models;

namespace TravelApp.Mappings
{
    public class DestinacijaMapping : Profile
    {
        public DestinacijaMapping()
        {
            CreateMap<DestinacijaCreateRequest, Destinacija>();
            CreateMap<DestinacijaUpdateRequest, Destinacija>();
        }
    }
}
