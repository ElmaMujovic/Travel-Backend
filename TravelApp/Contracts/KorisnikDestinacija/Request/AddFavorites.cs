using TravelApp.Contracts.Destinacija.Request;
using TravelApp.Models;

namespace TravelApp.Contracts.KorisnikDestinacija.Request
{
    public class AddFavorites
    {
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public int DestinacijaId { get; set; }
        public DestinacijaCreateRequest Destinacija { get; set; }
    }
}
