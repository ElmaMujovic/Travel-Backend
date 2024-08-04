using AutoMapper;
using Travel.Contracts.KorisnikDestinacija.Request;
using Travel.Models;

namespace Travel.Mappings
{
    public class KorisnikDestinacijaMapping : Profile
    {
        public KorisnikDestinacijaMapping()
        {
            CreateMap<KorisnikDestinacijaRequest, KorisnikDestinacija>();
        }
    }
}
