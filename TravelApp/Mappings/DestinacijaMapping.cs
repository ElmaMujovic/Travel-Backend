using AutoMapper;
using Travel.Contracts.Destinacija.Request;
using Travel.Models;

namespace Travel.Mappings
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
