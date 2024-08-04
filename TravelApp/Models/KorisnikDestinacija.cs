using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Models
{
    public class KorisnikDestinacija
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        [ForeignKey(nameof(Destinacija))]
        public int DestinacijaId { get; set; }
        public Destinacija Destinacija { get; set; }
    }
}
