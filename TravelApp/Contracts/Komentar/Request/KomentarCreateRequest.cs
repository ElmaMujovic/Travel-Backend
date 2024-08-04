using System.ComponentModel.DataAnnotations.Schema;
using Travel.Models;

namespace Travel.Contracts.Komentar.Request
{
    public class KomentarCreateRequest
    {
        
        public int KorisnikId { get; set; }
        public int DestinacijaId { get; set; }

        public string Tekst { get; set; }
        public string Datum { get; set; }
    }
}
