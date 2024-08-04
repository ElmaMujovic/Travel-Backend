using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        [ForeignKey("KorisnikId")]
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        [ForeignKey("DestinacijaId")]
        public int DestinacijaId { get; set; }
        public Destinacija Destinacija { get; set; }

        public string Tekst { get; set; }
        public string Datum { get; set; }

        // Dodaj ostale atribute koji su relevantni za komentar
    }
}
