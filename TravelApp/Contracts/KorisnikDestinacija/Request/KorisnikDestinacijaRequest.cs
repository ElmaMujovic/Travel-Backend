using System.ComponentModel.DataAnnotations.Schema;
using Travel.Models;

namespace Travel.Contracts.KorisnikDestinacija.Request
{
    public class KorisnikDestinacijaRequest
    {
      
        public int KorisnikId { get; set; }
        public int DestinacijaId { get; set; }
    }
}
