using AutoMapper;
using TravelApp.Contracts.KorisnikDestinacija.Request;
using TravelApp.Models;

namespace TravelApp.Mappings
{
    public class KorisnikDestinacijaMapping : Profile
    {
        public KorisnikDestinacijaMapping()
        {
            CreateMap<KorisnikDestinacijaRequest, KorisnikDestinacija>();
        }
    }
}
