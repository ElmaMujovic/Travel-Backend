namespace Travel.Models
{
    public class Destinacija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string ImagePath { get; set; }
        
        public double Cena { get; set; }
        public List<KorisnikDestinacija> korisnikDestinacijas { get; set; }
        public List<Komentar> Komentari { get; set; }

    }
}
