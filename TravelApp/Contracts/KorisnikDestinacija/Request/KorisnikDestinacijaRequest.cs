using System.ComponentModel.DataAnnotations.Schema;
using TravelApp.Models;

namespace TravelApp.Contracts.KorisnikDestinacija.Request
{
    public class KorisnikDestinacijaRequest
    {
      
        public int KorisnikId { get; set; }
        public int DestinacijaId { get; set; }
    }
}
